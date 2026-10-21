using System.Text.RegularExpressions;

namespace Ichamn.Helpers
{

    public static class HtmValidationHelper
    {
        public static bool Validate(string p_s)
        {
            var tagRegex = new Regex(@"<\s*([^ >]+)[^>]*>.*?<\s*/\s*\1\s*>");
            return  !tagRegex.IsMatch(p_s.Replace("<br/>",""));
        }
    }
}