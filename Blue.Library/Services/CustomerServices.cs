using System;
using System.Collections.Generic;
using System.Linq;

using Blue.Data.Constants;
using Blue.Data.Controllers;
using Blue.Data.Models;
using Blue.Library.Api;
using Blue.Library.Exceptions;
using Blue.Library.Responses;

namespace Blue.Library.Services
{
    public class CustomerServices  : IDomainServices
    {
        private readonly ControllerContainer.CustomerController _customerController;
        private readonly string _token; 

        public CustomerServices(string token)
        {
            _customerController = new ControllerContainer.CustomerController();
            _token = token;
        }

        public virtual IDataResult All()
        {
            return new DataResponse
            {
                Results = _customerController.All().ToList(),
                Message = BlueConstants.SUCCESS,
                Success = true,
            };
        }

        public virtual IDataResult Get(int id)
        {
            return new DataResponse
            {
                Results = _customerController.Select("where id=@0", id).ToList(),
                Message = BlueConstants.SUCCESS,
                Success = true,
            };
        }

        public virtual IDataResult Save(IModel model)
        {
            try
            {
                var c = model as Customer;
                var id = _customerController.Save(c, true, transID: _token, endPoint: "customer/save");

                return new DataResponse
                {
                    Results = _customerController.Select("where id=@0", id).ToList(),
                    Message = BlueConstants.SUCCESS,
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                ExceptionsHandler.Process(ex);
            }

            return null; 
        }

        public virtual IDataResult Delete(int id)
        {
            _customerController.Destroy(id);

            return new DataResponse
            {
                Results = null,
                Message = BlueConstants.SUCCESS,
                Success = true,

            };
        }
    }
}
