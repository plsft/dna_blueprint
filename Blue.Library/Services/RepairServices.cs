using System;
using System.Linq;

using Blue.Data.Constants;
using Blue.Data.Controllers;
using Blue.Data.Models.Repair;
using Blue.Data.ViewModels;
using Blue.Library.Exceptions;
using Blue.Library.Requests;
using Blue.Library.Responses;

namespace Blue.Library.Services
{
    public sealed class RepairServices
    {
        private readonly ControllerContainerRepair.VREROMS_HEADERController _VREROMS_HEADERController;
        private readonly string _token;

        public RepairServices(string token)
        {
            _VREROMS_HEADERController = new ControllerContainerRepair.VREROMS_HEADERController();
            _token = token;
        }

        public DataResponse FindOrders(string documentNo)
        {
            string domainSql = "";
            if (documentNo.Length < 11)
            {
                documentNo += "%";
                domainSql = "where RO_NUMBER like @0";
            }
            else
            {
                domainSql = "where RO_NUMBER = @0";
            }

            return new DataResponse
            {
                Results = _VREROMS_HEADERController.Select(domainSql, documentNo),
                Message = BlueConstants.SUCCESS,
                Success = true,
            };
        }
    }
}
