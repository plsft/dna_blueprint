using System;
using System.Linq;
using Blue.Data.Extentions;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models
{
    public abstract class ModelBase<T> where T : class
    {
        [Ignore]
        [JsonIgnore]
        public virtual string ModelName => typeof (T).Name;

        [Ignore]
        [JsonProperty("uniqueObjectKey")]
        public virtual string UniqueObjectKey => $"{ModelName.Substring(0, 3).ToUpper()}{ModelName.Substring(ModelName.Length-3,3).ToUpper()}{Key}";

        [Ignore]
        [JsonIgnore]
        public virtual string CompositeModelKey
            => typeof (T).GetProperties().Where(pi => pi.GetCustomAttributes(typeof (CompositeKeyColumnAttribute), true).Length != 0).Aggregate("", (current, pi) => current + pi.GetValue(this));

        [Ignore]
        [JsonIgnore]
        public virtual string Key => string.IsNullOrEmpty(CompositeModelKey) ? Convert.ToString(PrimaryKeyValue) : CompositeModelKey;

        [Ignore]
        [JsonIgnore]
        public virtual int PrimaryKeyValue => Convert.ToInt32((typeof (T).GetProperty("ID")?.GetValue(this)) ?? -1);

        [Ignore]
        [JsonIgnore]
        public virtual bool UsePrimaryKey => PrimaryKeyValue != -1;

        [Ignore]
        [JsonProperty("rowVer")]
        public virtual string RowVer => typeof(T).GetProperties().Where(pi => pi.GetCustomAttributes(typeof(RowVerColumnAttribute), true).Length != 0).Aggregate(":", (current, pi) => current + pi.GetValue(this)).ToChecksum();

    }
}
