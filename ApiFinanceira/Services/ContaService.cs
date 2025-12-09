namespace ApiFinanceira.Services;

public class ContaService
{
    private readonly Supabase.Client _supabase;

    public ContaService(Supabase.Client supabase)
    {
        _supabase = supabase;
    }
    
    public async Task<List<conta>> GetContasAsync()
    {
        var response = await _supabase.From<conta>().Get();

        return response.Models;
    }
}