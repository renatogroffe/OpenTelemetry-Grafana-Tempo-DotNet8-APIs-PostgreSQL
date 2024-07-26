using Microsoft.AspNetCore.Mvc;
using APIOrquestracao.Models;
using APIOrquestracao.Clients;

namespace APIOrquestracao.Controllers;

[ApiController]
[Route("[controller]")]
public class OrquestracaoController : ControllerBase
{
    private readonly ILogger<OrquestracaoController> _logger;
    private readonly IConfiguration _configuration;
    private readonly ContagemClient _contagemClient;

    public OrquestracaoController(ILogger<OrquestracaoController> logger,
        IConfiguration configuration, ContagemClient contagemClient)
    {
        _logger = logger;
        _configuration = configuration;
        _contagemClient = contagemClient;
    }

    [HttpGet]
    public async Task<ResultadoOrquestracao> Get()
    {
        var resultado = new ResultadoOrquestracao
        {
            Horario = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        };

        resultado.ContagemPostgres =
            await _contagemClient.ObterContagemAsync<ResultadoContagem>(
                _configuration["ApiContagem"]!);
        _logger.LogInformation($"Valor contagem PostgreSQL: {resultado.ContagemPostgres!.ValorAtual}");

        resultado.ContagemExterna =
            await _contagemClient.ObterContagemAsync<ResultadoContagemExterna>(
                _configuration["ApiContagemExterna"]!);
        _logger.LogInformation($"Valor contagem API externa: {resultado.ContagemExterna!.ValorAtual}");

        return resultado;
    }
}
