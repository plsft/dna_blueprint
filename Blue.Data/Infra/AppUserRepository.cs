using Helix.Data;

namespace Blue.Data.Infra
{
    public abstract class AppUserRepository : HelixPetaRepository, IAppRepository
    {
        protected AppUserRepository() : base("UserDbConnection")
        {
        }
    }
}
