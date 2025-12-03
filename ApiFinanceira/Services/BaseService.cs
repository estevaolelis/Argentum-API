using Microsoft.Extensions.Logging;
using Supabase;

namespace ApiFinanceira.Services
{
    public abstract class BaseService
    {
        protected readonly ILogger _logger;
        protected readonly Client _supabase;

        protected BaseService(ILogger logger, Client supabase)
        {
            _logger = logger;
            _supabase = supabase;
        }

        protected void LogInfo(string message)
        {
            _logger.LogInformation("[SERVICE] " + message);
        }

        protected void LogError(Exception ex, string context = "")
        {
            _logger.LogError(ex, $"[SERVICE ERROR] {context} -> {ex.Message}");
        }

        protected void LogWarn(string message)
        {
            _logger.LogWarning("[SERVICE WARNING] " + message);
        }

        protected async Task<T?> TryExecuteAsync<T>(Func<Task<T>> action, string context)
        {
            try
            {
                LogInfo($"{context} iniciado...");
                var result = await action();
                LogInfo($"{context} concluído.");
                return result;
            }
            catch (Exception ex)
            {
                LogError(ex, context);
                return default;
            }
        }
    }
}
