using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Change_Case_Excel_Add_In_v3
{
    public static class ChangeCaseFunctions
    {

        public static string ChangeMyCase(string ccType, string orgSourceString)
        {
            var result = "";

            if (string.IsNullOrEmpty(orgSourceString))
            {
                return result;
            }

            switch (ccType)
            {
                case AppStrings.UpperCase:
                    result = UCase(orgSourceString);
                    break;
                case AppStrings.LowerCase:
                    result = LCase(orgSourceString);
                    break;
                case AppStrings.ProperCaseAll:
                    result = PCase(orgSourceString, true);
                    break;
                case AppStrings.ProperCase:
                    result = PCase(orgSourceString);
                    break;
                case AppStrings.SentenceCase:
                    result = SCase(orgSourceString);
                    break;
                case AppStrings.ToggelCase:
                    result = Toggle(orgSourceString);
                    break;
                case AppStrings.AlternateCase:
                    result = ACase(orgSourceString);
                    break;
                default:
                    result = LCase(orgSourceString);
                    break;
            }

            return result;
        }


        private static string UCase(string sourceString)
        {
            string result;
            try
            {
                result = sourceString.ToUpper();
            }
            catch (Exception)
            {
                result = "";
            }
            return result;
        }

        private static string LCase(string sourceString)
        {
            string result;
            try
            {
                result = sourceString.ToLower();
            }
            catch (Exception)
            {
                result = "";
            }
            return result;
        }

        private static string PCase(string sourceString, bool all = false)
        {
            string result;
            try
            {
                result = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(all ? sourceString.ToLower() : sourceString);
            }
            catch (Exception)
            {
                result = "";
            }
            return result;
        }


        private static string SCase(string sourceString)
        {
            string result;
            try
            {
                var sentenceRegex = new Regex(@"(^[a-z])|[?!.:,;]\s+(.)", RegexOptions.ExplicitCapture);
                result = sentenceRegex.Replace(sourceString.ToLower(), s => s.Value.ToUpper());
                return result;
            }
            catch (Exception)
            {
                result = "";
            }
            return result;
        }


        private static string Toggle(string input)
        {
            var result = string.Empty;
            var inputArray = input.ToCharArray();
            foreach (var c in inputArray)
            {
                if (char.IsLetter(c))
                {
                    if (char.IsLower(c))
                        result += c.ToString().ToUpper();
                    else if (char.IsUpper(c))
                        result += c.ToString().ToLower();
                    else
                        result += c.ToString();
                }
                else
                {
                    result += c.ToString();
                }
            }
            return result;
        }

        public static string ACase(string input)
        {
            var result = string.Empty;
            var pCaps = true;
            var inputArray = input.ToCharArray();

            foreach (var c in inputArray)
            {
                if (char.IsLetter(c))
                {
                    if (pCaps)
                    {
                        result += c.ToString().ToLower();
                        pCaps = false;
                    }
                    else
                    {
                        result += c.ToString().ToUpper();
                        pCaps = true;
                    }
                }
                else
                {
                    result += c.ToString();
                }
            }
            return result;
        }


    }
}
