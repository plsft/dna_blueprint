using System;
using System.Linq;
using Blue.Data.Constants;
using Blue.Data.Controllers;
using Blue.Data.Models;
using Blue.General;

namespace Blue.Data.Infra
{
    public sealed class DataLocker
    {
        private readonly ControllerContainer.LockController _controller;
        public string Token { get; set;  }
        public int UserId { get; set;  }


        public DataLocker()
        {
            _controller = new ControllerContainer.LockController();

        }

        public DataLocker(string token, int userId) : this()
        {
            Token = token;
            UserId = userId;
        }

        public DataLocker(string token) : this()
        {
            Token = token; 
        }

        public void Add<T>(T type) where T : class
        {
            var uniqueObjectKey = Convert.ToString(typeof(T).GetProperty("UniqueObjectKey")?.GetValue(type));
            var rowVer = Convert.ToString(typeof(T).GetProperty("RowVer")?.GetValue(type));
            var objectType = Convert.ToString(typeof(T).GetProperty("ModelName")?.GetValue(type));

            _controller.Save(new Lock
            {
                Token = Token, 
                UserId = UserId,
                Expires = BlueConstants.BlueCurrentDate.AddMinutes(AppSettings.RecordLockExpirationInMin),
                ObjectId = uniqueObjectKey,
                ObjectType = objectType, 
                RowVer = rowVer
            });
        }

        public bool Validate<T>(T type) where T : class
        {
            var uniqueObjectKey = Convert.ToString(typeof(T).GetProperty("UniqueObjectKey")?.GetValue(type));
            var rowVer = Convert.ToString(typeof(T).GetProperty("RowVer")?.GetValue(type));
            var objectType = Convert.ToString(typeof(T).GetProperty("ModelName")?.GetValue(type));

            var l = _controller.Select("where objectId=@0 and objectType=@1", uniqueObjectKey, objectType).FirstOrDefault();

            if (l == null)
                return true;

            return l.RowVer == rowVer && !l.Expired;
        }

        public bool Remove<T>(T type) where T : class
        {
            var uniqueObjectKey = Convert.ToString(typeof(T).GetProperty("UniqueObjectKey")?.GetValue(type));
            var objectType = Convert.ToString(typeof(T).GetProperty("ModelName")?.GetValue(type));

            var l = _controller.Select("where objectId=@0 and objectType=@1", uniqueObjectKey, objectType).FirstOrDefault();
            return l != null && _controller.Destroy(l.ID);
        }

        public bool Expire<T>(T type) where T : class
        {
            var uniqueObjectKey = Convert.ToString(typeof (T).GetProperty("UniqueObjectKey")?.GetValue(type));
            var objectType = Convert.ToString(typeof (T).GetProperty("ModelName")?.GetValue(type));

            var l = _controller.Select("where objectId=@0 and objectType=@1", uniqueObjectKey, objectType).FirstOrDefault();
            l.Expires = DateTime.Now.AddMinutes(-1);
            return _controller.Save(l) != 0;
        }
    }
}
