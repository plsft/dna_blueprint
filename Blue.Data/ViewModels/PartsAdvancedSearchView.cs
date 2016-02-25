using System.Collections.Generic;

namespace Blue.Data.ViewModels
{
    public sealed class PartsAdvancedSearchView  : ViewModelBase
    {
        public IEnumerable<dynamic> Results { get; set;  }

        public PartsAdvancedSearchView(string sql)
        {
            Results = db.Fetch<dynamic>(sql);
        }

        public PartsAdvancedSearchView(IEnumerable<dynamic> results)
        {
            Results = results;
        }
    }
}
