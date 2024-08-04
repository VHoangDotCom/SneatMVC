using System.Text.RegularExpressions;
using System.Text;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sneat.MVC.Common
{
    public class Utils
    {
        #region Encode-Decode
        public static string GenPass(string pass)
        {
            return BCrypt.Net.BCrypt.HashPassword(pass, 10);
        }

        public static bool CheckPass(string pass, string userPass)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(pass, userPass);
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Filtering
        public static string RemoveDiacritics(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            input = input.Replace("đ", "d").Replace("Đ", "D");

            string decomposed = input.Normalize(NormalizationForm.FormD);
            Regex nonDiacritic = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string withoutDiacritics = nonDiacritic.Replace(decomposed, string.Empty).Normalize(NormalizationForm.FormC);

            // Normalize whitespace characters
            string normalizedWhitespace = Regex.Replace(withoutDiacritics, @"\s+", " ");

            return normalizedWhitespace.Trim().ToLower();
        }
        #endregion

        #region Config System
        public static string getFullUrl()
        {
            if (HttpContext.Current == null)
                return "";
            var request = HttpContext.Current.Request;
            var url = request.Url.Scheme + "://" + request.Url.Authority;
            return url;
        }

        #endregion

        #region Handle DateTime
        public static DateTime? DefaultDateTime(DateTime? dt)
        {
            if (dt.HasValue)
            {
                if (dt.Value < new DateTime(1753, 1, 1))
                {
                    return new DateTime(1753, 1, 1);
                }
                return dt.Value;
            }
            return null;
        }
        #endregion

        #region Convert
        public static string ConvertListIntegerToString(List<int> listInt)
        {
            return string.Join(", ", listInt);
        }

        public static List<int> ConvertStringToListInteger(string str)
        {
            var list = str
                .Split(',')
                .Select(s => s.Trim())
                .Select(int.Parse)
                .ToList();

            return list;
        }

        #endregion
    }
}