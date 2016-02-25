using System;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Blue.General;

namespace Blue.Data.Extentions 
{
    public static class StringExtensionsMethods
    {
        public static string Pluralize(this string name)
        {
            return name == null ? string.Empty : PluralizationService.CreateService(new CultureInfo(AppSettings.Culture)).Pluralize(name);
        }

        public static string ToTitleCase(this string name)
        {
            return name == null ? string.Empty : new CultureInfo(AppSettings.Culture, false).TextInfo.ToTitleCase(name);
        }

        public static string ToCamelCase(this string c)
        {
            return Char.ToLowerInvariant(c[0]) + c.Substring(1);
        }

        public static string ToProperCase(this string name)
        {
            return ToTitleCase(name);
        }

        public static string ToUpperCase(this string name)
        {
            return name == null ? string.Empty : new CultureInfo(AppSettings.Culture, false).TextInfo.ToUpper(name);
        }

        public static string ToLowerCase(this string name)
        {
            return name == null ? string.Empty : new CultureInfo(AppSettings.Culture, false).TextInfo.ToLower(name);
        }

        public static string ToEncryptedString(this string plainText)
        {
            return plainText == null ? string.Empty : Helix.Security.Crypto.Encrypt(plainText);
        }

        public static string MaxLen(this string name, int max)
        {
            return name == null ? string.Empty : name.Length < max ? name.Substring(0, name.Length) : name.Substring(0, max);
        }

        public static string ToNonNull(this string str)
        {
            return str == null ? string.Empty : Convert.ToString(str);
        }

        public static int ToRoundedInt(this double val)
        {
            return (int) Math.Round(val, 0);

        }

        public static string RemoveTrailingComma(this string val)
        {
            if (val == null)
                return string.Empty;

            if (!val.EndsWith(","))
                return val;

            return val.Remove(val.Length - 1, 1);
        }

        public static string RemoveTrailingPipe(this string val)
        {
            if (val == null)
                return string.Empty;

            if (!val.EndsWith("|"))
                return val;

            return val.Remove(val.Length - 1, 1);
        }

        public static string ToVariableName(this string str, int id = 0, int respTypeId = 0)
        {
            var re = new Regex("[();.\\\\/:*?\"<>|&',]0123456789");
            return "_r_" + id + "_" + respTypeId + "_" + re.Replace(str, "").Replace(" ", "").Replace("?", "");
        }

        public static string ToTableName(this string str)
        {
            var re = new Regex("[();\\\\/:*?\"<>|&',]0123456789");
            return re.Replace(str, "").Replace(" ", "").Replace("?", "").Replace(".", "");
        }

        public static string ToSafeFileName(this string str)
        {
            var re = new Regex("[();\\\\/:*?\"<>|&',]0123456789");
            return re.Replace(str, "").Replace(" ", "").Replace("?", "").Replace(".", "");
        }

        public static short ToInt16(this string val)
        {
            short returned = 0;
            return short.TryParse(val, out returned) ? returned : (short) -1;
        }

        public static float ToSingle(this string val)
        {
            float returned = 0f;
            return float.TryParse(val, out returned) ? returned : (float) -1f;
        }

        public static int ToInt32(this string val)
        {
            var returned = 0;
            return int.TryParse(val, out returned) ? returned : -1;
        }

        public static long ToInt64(this string val)
        {
            long returned = 0;
            return long.TryParse(val, out returned) ? returned : -1;
        }

        public static string ToChecksum(this string val)
        {
            var byteToCalculate = Encoding.ASCII.GetBytes(val);
            var checksum = byteToCalculate.Aggregate(0, (current, b) => current + b);
            checksum &= 0xff;
            return checksum.ToString("X2");
        }
    }
}

