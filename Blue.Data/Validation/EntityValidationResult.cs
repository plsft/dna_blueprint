using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Blue.Data.Validation
{
    public sealed class EntityValidationResult
    {
        public IList<ValidationResult> Errors { get; set;  }

        public string ErrorList
        {
            get
            {
                return Errors.Aggregate(" ", (current, e) => current + e.ErrorMessage);
            }
        }

        public bool HasError => Errors != null && Errors.Count > 0;

        public EntityValidationResult(IList<ValidationResult> errors)
        {
            Errors = errors;
        }

        

    }
}
