namespace BlogApp
{
    public static class Extensions
    {
        public static string GetFirst50Char(this string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            return $"{input.Substring(0, Math.Min(input.Length, 50))}...";
        }
    }
}
