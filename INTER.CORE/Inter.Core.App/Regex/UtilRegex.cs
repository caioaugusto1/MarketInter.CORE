namespace Inter.Core.App.Regex
{
    public static class UtilRegex
    {
        public static string RemoveSpecialCaracter(string input)
        {
            string pattern = @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\s]";

            string replacement = string.Empty;

            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern);

            return regex.Replace(input, replacement);
        }

    }
}
