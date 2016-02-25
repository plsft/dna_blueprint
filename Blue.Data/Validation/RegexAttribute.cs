using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Blue.Data.Validation
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public sealed class RegexAttribute : ValidationAttribute
    {
        public string Pattern { get; set; }
        public RegexOptions Options { get; set; }

        public RegexAttribute(string pattern, RegexOptions options = RegexOptions.None)
        {
            Pattern = pattern;
            Options = options;
        }

        public RegexAttribute(string pattern)
        {
            Pattern = pattern;
            Options = RegexOptions.Compiled | RegexOptions.IgnoreCase;
        }

        public override bool IsValid(object value)
        {
            return IsValid(value as string);
        }

        public bool IsValid(string value)
        {
            return string.IsNullOrEmpty(value) || new Regex(Pattern, Options).IsMatch(value);
        }
    }
}
