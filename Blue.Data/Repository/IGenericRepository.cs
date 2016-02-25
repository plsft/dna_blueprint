 
using Blue.Data.Infra;

namespace Blue.Data.Repositories
{
    public interface IGenericRepository<T> where T : class, IAppRepository
    {
    }
}
