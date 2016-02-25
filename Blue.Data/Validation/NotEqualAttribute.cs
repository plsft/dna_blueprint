using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Blue.Data.Validation
{
    public sealed class NotEqualAttribute : ValidationAttribute
    {
        public string Value { get; set; }

        public NotEqualAttribute(string value)
        {
            Value = value; 
        }


        public override bool IsValid(object value)
        {
            return IsValid(value as string);
        }

        public bool IsValid(string value)
        {
            return string.IsNullOrEmpty(value) || new Regex(string.Format("^{0}", Value), RegexOptions.Compiled).IsMatch(value);
        }
    }
}
