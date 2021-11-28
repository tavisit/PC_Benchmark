namespace Benchmark.Backend.Utilities
{
    public static class StringExtensions
    {
        public static bool EqualsLower(this string value, string comparisonString)
        {
            return value.ToLower().Equals(comparisonString.ToLower());
        }

        public static bool ContainsLower(this string value, string containsString)
        {
            return value.ToLower().Contains(containsString.ToLower());
        }
    }
}
