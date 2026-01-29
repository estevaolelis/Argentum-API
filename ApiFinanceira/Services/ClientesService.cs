using ApiFinanceira.DTO.Exportacao;
using Supabase.Postgrest;
using Supabase.Postgrest.Models;

namespace ApiFinanceira.Services
{
    public class ClientesService
    {
        private readonly Supabase.Client _supabase;

        public ClientesService(Supabase.Client supabase)
        {
            _supabase = supabase;
        }
        
        public async Task<clientes> PostClientesAsync(string nome, string documento, string email)
        {
            var novoCliente = new clientes
            {
                nome = nome,
                documento = documento,
                email = email,
                status = true,
                data_criacao = DateTime.UtcNow
            };
            
            var response = await _supabase
                .From<clientes>()
                .Insert(novoCliente, new QueryOptions { Returning = QueryOptions.ReturnType.Representation });
            
            return response.Models.FirstOrDefault();
        }
        
        public async Task<List<clientes>> GetClientesAsync()
        {
            var response = await _supabase.From<clientes>().Where(c => c.status == true).Get();
            
            return response.Models; 
        }

        public async Task<clientes> GetClientesByIdAsync(int id)
        {
            var response = await _supabase.From<clientes>().Where(c => c.id == id && c.status == true).Get();
            return response.Models.FirstOrDefault();
        }

        public async Task<clientes> PutClientesAsync(int id, string nome, string documento, string email)
        {
            var response = await _supabase.From<clientes>().Where(c => c.id == id)
                .Set(c => c.nome, nome) 
                .Set(c => c.documento, documento)
                .Set(c => c.email, email)
                .Update();;
            
            return response.Models.FirstOrDefault();
        }

        public async Task<bool> DeleteClientesAsync(int id)
        {
            var cliente = await _supabase
                .From<clientes>()
                .Where(c => c.id == id)
                .Single();
            
            if (cliente == null) return false;
            
            await _supabase
                .From<clientes>()
                .Where(c => c.id == id)
                .Set(c => c.status, false)
                .Update();

            return true;
        }
        
        public async Task<ResultadoExportacao> ExportarClientesExcelAsync()
        {
            var response = await _supabase.From<clientes>().Get();
            var dados = response.Models;
            
            var config = new List<CsvColunaConfiguracao<clientes>>
            {
                new() { Cabecalho = "Nome", Formatador = c => c.nome },
                new() { Cabecalho = "Documento", Formatador = c => c.documento }
            };
            
            var exportacaoService = new ExportacaoService();
            return exportacaoService.ExportarPlanilha(dados, config, FormatoExportacao.xlsx);
        }
    }   
}