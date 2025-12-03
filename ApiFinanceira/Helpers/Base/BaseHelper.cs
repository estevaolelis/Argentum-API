namespace ApiFinanceira.Helpers.Base
{
    public static class BaseHelper
    {
        public static bool IsNullOrEmpty(params string?[] valores)
        {
            return valores.Any(v => string.IsNullOrWhiteSpace(v));
        }

        public static bool IsAnyNull(params object?[] valores)
        {
            return valores.Any(v => v is null);
        }

        public static string NewGuid() => Guid.NewGuid().ToString();

        public static string ToUpperSafe(string? value)
        {
            return value?.ToUpper().Trim() ?? "";
        }

        public static decimal ToDecimalSafe(string? value)
        {
            if (decimal.TryParse(value, out var result))
                return result;

            return 0;
        }

        public static DateTime Now() => DateTime.UtcNow;
    }
}
