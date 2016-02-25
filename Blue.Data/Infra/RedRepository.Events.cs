 

namespace Red.Data.Infra
{
    public partial class RedRepository
    {

        public override void OnAfterDelete(object poco)
        {
            //Logger.Log("OnAfterDelete", "OnAfterDelete [{0}]", Logger.LogType.Info, poco);
            base.OnAfterDelete(poco);
        }

        public override void OnAfterInsert(object poco)
        {
            //Logger.Log("OnAfterInsert", "OnAfterInsert [{0}]", Logger.LogType.Info, poco);
            base.OnAfterInsert(poco);
        }

        public override void OnBeforeDelete(object poco)
        {
            //Logger.Log("OnBeforeDelete", "OnBeforeDelete [{0}]", Logger.LogType.Info, poco);
            base.OnBeforeDelete(poco);
        }

        public override void OnBeforeUpdate(object poco)
        {
            //Logger.Log("OnBeforeUpdate", "OnBeforeUpdate [{0}]", Logger.LogType.Info, poco);
            base.OnBeforeUpdate(poco);
        }

        public override void OnAfterUpdate(object poco)
        {
            //Logger.Log("OnAfterUpdate", "OnAfterUpdate [{0}]", Logger.LogType.Info, poco);
            base.OnAfterUpdate(poco);
        }

        public override void OnBeforeInsert(object poco)
        {
            //Logger.Log("OnBeforeInsert", "OnBeforeInsert [{0}]", Logger.LogType.Info, poco);
            base.OnBeforeInsert(poco);
        }

        
        
    }
}
