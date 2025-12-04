using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ApiFinanceira.Services
{
    public class ClientesService
    {
        private readonly Supabase.Client _supabase;
        public ClientesService(Supabase.Client supabase)
        {
            _supabase = supabase;
        }

        public async Task<List<clientes>> GetClientesAsync()
        {
            var clientesLista = await _supabase.From<clientes>().Get();
            return clientesLista.Models;
        }
    }   
}
