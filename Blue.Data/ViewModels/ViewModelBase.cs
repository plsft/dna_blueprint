using Blue.General;
using Helix.Infra.Peta;

namespace Blue.Data.ViewModels
{
    public abstract class ViewModelBase
    {
        protected Database db;

        protected ViewModelBase()
        {
            db = new Database(Config.DbConnectionStringName);
        }
    }
}
