using Helix.Data;

namespace Blue.Data.Infra
{
    public abstract class AppDataRepository : HelixPetaRepository, IAppRepository
    {
        protected AppDataRepository() : base("DataDbConnection")
        {
        }
    }
}
