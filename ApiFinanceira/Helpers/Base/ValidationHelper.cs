namespace ApiFinanceira.Helpers.Base
{
    public static class ValidationHelper
    {
        public static void ThrowIfNull(object? value, string fieldName)
        {
            if (value is null)
                throw new ArgumentException($"O campo {fieldName} é obrigatório.");
        }

        public static void ThrowIfEmpty(string? value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"O campo {fieldName} é obrigatório.");
        }
    }
}
