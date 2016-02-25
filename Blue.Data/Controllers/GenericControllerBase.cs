using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Helix.Infra.Peta;
using Blue.Data.Extentions;
using Blue.Data.Infra;
using Blue.Data.Repositories;
using Blue.Data.Validation;

namespace Blue.Data.Controllers
{
    public abstract class GenericControllerBase<T> where T : class
    {
        private readonly IRepository _repository;
        public string TableName { get; set; }

        protected GenericControllerBase(IRepository repository)
        {
            _repository = repository;
        }

        protected GenericControllerBase(IRepository repository, string tableName)
        {
            TableName = tableName;
            _repository = repository;
        }


        public virtual int Save(T type, bool validateEntity = false, string endPoint = "", string transID = "")
        {
            var compositeKeys = typeof (T).GetProperties().Any(p => p.GetCustomAttributes(typeof (CompositeKeyColumnAttribute), true).Length != 0);
            var identityPropertyName = typeof(T).GetProperties().SingleOrDefault(t => t.Name.ToLower().StartsWith("id")) == null ? "ID"
                : typeof(T).GetProperties().SingleOrDefault(t => t.Name.ToLower().StartsWith("id")).Name;
            
            var id = Convert.ToInt32(typeof(T).GetProperty(identityPropertyName).GetValue(type, null)); 
            var v = id > 0 && !compositeKeys ? _repository.Single<T>(id) : null;

            if (validateEntity)
            {
                var validator = new Validation.EntityValidator<T>();
                var vr = validator.Validate(type);

                if (vr.HasError)
                {
                    throw new Exception("Validation: " + vr.ErrorList);
                }
            }
            try
            {
                if (compositeKeys)
                {
                    if (!string.IsNullOrEmpty(endPoint) && !string.IsNullOrEmpty(transID) && typeof(T).Name != "Audit")
                    {
                        Auditor.Add<T>(new Auditor.AuditAction
                        {
                            Endpoint = endPoint,
                            Operation = v == null ? "insert" : "update",
                            TransactionID = transID,
                        }, type, type, "id", "created");
                    }

                    return (int)_repository.Update(TableName, type);
                }
                else
                {
                    if (!string.IsNullOrEmpty(endPoint) && !string.IsNullOrEmpty(transID) && typeof(T).Name != "Audit")
                    {
                        Auditor.Add<T>(new Auditor.AuditAction
                        {
                            Endpoint = endPoint,
                            Operation = v == null ? "insert" : "update",
                            TransactionID = transID,
                        }, v, type, "id", "created");
                    }

                    var result = v == null ? _repository.Insert(type) : _repository.Update(type, id);
                    return (result == null || result.Equals(0)) ? 0 : (v == null) ? Convert.ToInt32(result) : id;
                }
            }
            catch (SqlException sx)
            {
                throw new Exception(new ValidationExceptionParser(TableName, sx).ValidationErrorMessage, sx);
            }
            finally
            {
                _repository.Dispose();
            }
        }

        //"Insert" method to directly save objects with composite keys
        public virtual int Add(T type, bool validateEntity = false, string endPoint = "", string transID = "")
        {
            //var compositeKeys = typeof(T).GetProperties().Any(p => p.GetCustomAttributes(typeof(CompositeKeyColumnAttribute), true).Length != 0);
            //var identityPropertyName = typeof(T).GetProperties().SingleOrDefault(t => t.Name.ToLower().StartsWith("id")) == null ? "ID"
             //   : typeof(T).GetProperties().SingleOrDefault(t => t.Name.ToLower().StartsWith("id")).Name;
            //var id = Convert.ToInt32(typeof(T).GetProperty(identityPropertyName).GetValue(type, null));
            //var v = id > 0 && !compositeKeys ? _repository.Single<T>(id) : null;

            if (validateEntity)
            {
                var validator = new Validation.EntityValidator<T>();
                var vr = validator.Validate(type);

                if (vr.HasError)
                {
                    throw new Exception("Validation: " + vr.ErrorList);
                }
            }
            try
            {
                if (!string.IsNullOrEmpty(endPoint) && !string.IsNullOrEmpty(transID) && typeof(T).Name != "Audit")
                {
                    Auditor.Add<T>(new Auditor.AuditAction
                    {
                        Endpoint = endPoint,
                        Operation = "insert" ,
                        TransactionID = transID,
                    }, type, type, "id", "created");
                }

                var result = _repository.Insert(type);
                return (result == null || result.Equals(0)) ? 0 : Convert.ToInt32(result);
            }
            catch (SqlException sx)
            {
                throw new Exception(new ValidationExceptionParser(TableName, sx).ValidationErrorMessage, sx);
            }
            finally
            {
                _repository.Dispose();
            }
        }

        public virtual int Update(T type, bool validateEntity = false)
        {
            var identityPropertyName = typeof(T).GetProperties().SingleOrDefault(t => t.Name.ToLower().StartsWith("id")) == null ? "ID"
                : typeof(T).GetProperties().SingleOrDefault(t => t.Name.ToLower().StartsWith("id")).Name;

            var id = Convert.ToInt32(typeof(T).GetProperty(identityPropertyName).GetValue(type, null)); 

            if (id == 0)
                return Save(type, validateEntity);

            if (validateEntity)
            {
                var validator = new Validation.EntityValidator<T>();
                var vr = validator.Validate(type);

                if (vr.HasError)
                {
                    throw new Exception("Validation: " + vr.ErrorList);
                }
            }
            try
            {
                var result = _repository.Update(type, id);
                return (result == null || result.Equals(0)) ? 0 : id;
            }
            catch (SqlException sx)
            {
                throw new Exception(new ValidationExceptionParser(TableName, sx).ValidationErrorMessage, sx);
            }
            finally
            {
                _repository.Dispose();
            }
        }


        public virtual int Update(object o, int id, string primaryKeyName = "ID", string tableName = null)
        {
            try
            {
                var nameOfTable = tableName ?? (string.IsNullOrEmpty(TableName) ? (typeof(T).Name).Pluralize() : TableName);
                var result = _repository.Update(nameOfTable, primaryKeyName, o, id);
                return result == null || result.Equals(0) ? 0 : id; 
            }
            catch (SqlException sx)
            {
                throw new Exception(new ValidationExceptionParser(TableName, sx).ValidationErrorMessage, sx);
            }
            finally
            {
                _repository.Dispose();
            }
        }

        public virtual bool Destroy(string domainSql, params object[] args)
        {
            try
            {
                dynamic target = _repository.Query<T>(domainSql, args);

                if (target == null)
                    return false;

                foreach (var item in target)
                {
                    int id = Convert.ToInt32(item.ID);
                    _repository.Delete<T>(id);
                }

                return true;
            }
            finally
            {
                _repository.Dispose();
            }
        }

        public virtual T Select(int id)
        {
            try
            {
                return _repository.Query<T>("where ID=@0", id).FirstOrDefault();
            }
            finally
            {
                _repository.Dispose();
            }
        }

        public virtual IEnumerable<T> Select(string domainSql, params object[] args)
        {
            try
            {
                return _repository.Query<T>(domainSql, args);
            }
            finally
            {
                _repository.Dispose();
            }
        }

        public virtual IEnumerable<T> All()
        {
            try
            {
                return _repository.Query<T>("where 1=1");
            }
            finally
            {
                _repository.Dispose();
            }
        }

        public virtual Page<T> Paged(long page, long items, string domainSql, params object[] args)
        {
            try
            {
                return _repository.PagedQuery<T>(page, items, domainSql, args);
            }
            finally
            {
                _repository.Dispose();
            }
        }

        public virtual bool Destroy(int id)
        {
            try
            {
                return _repository.Delete<T>(id);
            }
            finally
            {
                _repository.Dispose();
            }
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}
