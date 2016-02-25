using Blue.Data.Models;
using Blue.Library.Api;


namespace Blue.Library.Services
{
    public interface IDomainServices
    {
        IDataResult All();
        IDataResult Get(int id);
        IDataResult Save(IModel c);
        IDataResult Delete(int id);
    }
}