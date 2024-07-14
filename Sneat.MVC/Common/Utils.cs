using System.Text.RegularExpressions;
using System.Text;
using System.Web;

namespace Sneat.MVC.Common
{
    public class Utils
    {
        #region Encode-Decode
        public static string GenPass(string pass)
        {
            return BCrypt.Net.BCrypt.HashPassword(pass, 10);
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
    }
}