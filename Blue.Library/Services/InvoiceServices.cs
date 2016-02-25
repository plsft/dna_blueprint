using System;
using System.Linq;

using Blue.Data.Constants;
using Blue.Data.Controllers;
using Blue.Data.Models;
using Blue.Library.Api;
using Blue.Library.Exceptions;
using Blue.Library.Responses;

namespace Blue.Library.Services
{
    public sealed class InvoiceServices : IDomainServices
    {
        private readonly ControllerContainer.InvoiceController _invoiceController;
        private readonly string _token; 

        public InvoiceServices(string token)
        {
            _invoiceController= new ControllerContainer.InvoiceController();
            _token = token;
        }

        public IDataResult All()
        {
            return new DataResponse
            {
                Results = _invoiceController.All().ToList(),
                Message = BlueConstants.SUCCESS,
                Success = true,
            };
        }
        public IDataResult Get(int id)
        {
            return new DataResponse
            {
                Results = _invoiceController.Select("where ID=@0", id),
                Message = BlueConstants.SUCCESS,
                Success = true,
            };
        }

        
        public IDataResult Save(IModel model)
        {
            try
            {
                var obj = model as Invoice;
                var id = _invoiceController.Save(obj, true, transID: _token, endPoint: "invoices/save"); // example with auditing 
                var list = _invoiceController.Select("where id=@0", id).ToList();

                return new DataResponse
                {
                    Results = list,
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

        public IDataResult Delete(int id)
        {
            _invoiceController.Destroy(id);

            return new DataResponse
            {
                Results = null,
                Message = BlueConstants.SUCCESS,
                Success = true,
            };
        }


    }
}
