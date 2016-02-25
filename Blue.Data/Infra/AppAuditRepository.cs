using Helix.Data;

namespace Blue.Data.Infra
{
    public abstract class AppAuditRepository : HelixPetaRepository, IAppRepository
    {
        protected AppAuditRepository() : base("AuditDbConnection")
        {
        }
    }
}
