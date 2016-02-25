using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Blue.Data.Validation
{
    public class EntityValidator<T> where T : class 
    {
        public EntityValidationResult Validate(T entity)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(entity, null, null);

            Validator.TryValidateObject(entity, context, results, true);

            return new EntityValidationResult(results);
        }
    }
}
