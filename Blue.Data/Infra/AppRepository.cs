
using Helix.Data;

namespace Blue.Data.Infra
{
    public abstract partial class AppRepository : HelixPetaRepository, IAppRepository
    {
        protected AppRepository() : base("DbConnection") // This is the CORE (aka 'default') database connection 
        {
        }
    }
}
