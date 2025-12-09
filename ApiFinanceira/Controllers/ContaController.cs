using ApiFinanceira.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiFinanceira.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContaController : ControllerBase
{
    private readonly ContaService _contaService;

    public ContaController(ContaService contaService)
    {
        _contaService = contaService;
    }
    
    [HttpGet("listar-conta")]
    public async Task<IActionResult> ListarConta()
    {
        var listar = await _contaService.GetContasAsync();
        
        return Ok(listar);
    }
}