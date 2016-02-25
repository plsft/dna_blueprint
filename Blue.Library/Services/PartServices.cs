using System;
using System.Linq;

using Blue.Data.Constants;
using Blue.Data.Controllers;
using Blue.Data.Models;
using Blue.Data.ViewModels;
using Blue.Library.Exceptions;
using Blue.Library.Requests;
using Blue.Library.Responses;

namespace Blue.Library.Services
{
    public sealed class PartServices
    {
        private readonly ControllerContainer.PartController _partController;
        private readonly ControllerContainer.PartHistoryController _partHistoryController;
        private readonly ControllerContainer.StockController _stockController;

        private CustomerInvociePartView _view;
        private readonly string _token;

        public PartServices(string token)
        {
            _partController = new ControllerContainer.PartController();
            _partHistoryController = new ControllerContainer.PartHistoryController();
            _stockController = new ControllerContainer.StockController();

            _token = token;
        }

        public PartsDataResponse GetPartByCustomer(int customerId)
        {
            _view = new CustomerInvociePartView(customerId);

            return new PartsDataResponse
            {
                Message = BlueConstants.SUCCESS,
                CustomerParts = _view.View.ToList(),
                Parts = null,
                Success = true,

            };
        }

        public PartsDataResponse All()
        {
            return new PartsDataResponse
            {
                Parts = _partController.All().ToList(),
                CustomerParts = null,
                Message = BlueConstants.SUCCESS,
                Success = true,

            };
        }

        public PartsDataResponse Search(string search)
        {
            return new PartsDataResponse
            {
                Parts = _partController.All().ToList().Where(p => p.Description.Contains(search)),
                CustomerParts = null,
                Message = BlueConstants.SUCCESS,
                Success = true,

            };
        }

        public PartsDataResponse AdvancedSearch(PartAdvancedSearchRequest request)
        {
            var view = new PartsAdvancedSearchView(request.Sql);
            var list = view.Results.ToList().ConvertAll(o => (Part) o);

            return new PartsDataResponse
            {
                Parts = list,
                CustomerParts = null,
                Message = BlueConstants.SUCCESS,
                Success = true,

            };
        }

        public PartsDataResponse Get(int id)
        {
            return new PartsDataResponse
            {
                Parts = _partController.Select("where id=@0", id).ToList(),
                CustomerParts = null,
                Message = BlueConstants.SUCCESS,
                Success = true,

            };
        }

        public PartsDataResponse Stock(int partId)
        {
            return new PartsDataResponse
            {
                Results = _stockController.Select("where partId=@0", partId).ToList().ConvertAll(o => (IModel) o),
                Message = BlueConstants.SUCCESS,
                Success = true,

            };
        }

        public PartsDataResponse ReturnOrBorrow(int partId, bool returned = false)
        {
            var p = _partController.Select(partId);
            var s = _stockController.Select("where partId=@0", partId).FirstOrDefault();
            p.Borrowed = !p.Borrowed;
            p.LastUpdate = BlueConstants.BlueCurrentDate;
            s.LastUpdate = BlueConstants.BlueCurrentDate;
            var units = s.Units;
            s.Units = returned ? units-- : units++;

            s.LastUpdate = BlueConstants.BlueCurrentDate;
            _partController.Save(p);
            _stockController.Save(s);

            return new PartsDataResponse
            {
                Results = _stockController.Select("where partId=@0", partId).ToList().ConvertAll(o => (IModel) o),
                Message = BlueConstants.SUCCESS,
                Success = true,

            };
        }



        public PartsDataResponse History(int id)
        {
            return new PartsDataResponse
            {
                Parts = _partController.Select("where id=@0", id).ToList(),
                Results = _partHistoryController.Select("where partId=@0", id),
                CustomerParts = null,
                Message = BlueConstants.SUCCESS,
                Success = true,

            };

        }

        public PartsDataResponse SaveImage(int partId, string baseString)
        {
            try
            {
                var id = _partController.Save(new Part()
                {
                    ImagePath = baseString,
                    ID = partId
                });

                return new PartsDataResponse
                {
                    Parts = _partController.Select("where id=@0", id).ToList(),
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

        public PartsDataResponse Save(IModel i)
        {
            try
            {
                var o = i as Part;
                var id = _partController.Save(o, true, transID: _token, endPoint: "part/save");

                _stockController.Save(new Stock
                {
                    PartId = id,
                    Units = 1,
                    LastUpdate = BlueConstants.BlueCurrentDate
                });

                return new PartsDataResponse
                {
                    Parts = _partController.Select("where id=@0", id).ToList(),
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

        public PartsDataResponse Delete(int id)
        {
            _partController.Destroy(id);

            return new PartsDataResponse
            {
                Parts = null,
                Message = BlueConstants.SUCCESS,
                Success = true,

            };
        }
    }
}
