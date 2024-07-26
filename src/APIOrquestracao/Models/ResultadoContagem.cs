namespace APIOrquestracao.Models;

public class ResultadoOrquestracao
{
    public string? Horario { get; set; }
    public ResultadoContagem? ContagemPostgres { get; set; }
    public ResultadoContagemExterna? ContagemExterna { get; set; }
}

public class ResultadoContagem
{
    public int ValorAtual { get; set; }
    public string? Producer { get; set; }
    public string? Kernel { get; set; }
    public string? Framework { get; set; }
    public string? Mensagem { get; set; }
}

public class ResultadoContagemExterna
{
    public int ValorAtual { get; set; }
    public string? Local { get; set; }
    public string? Kernel { get; set; }
    public string? Framework { get; set; }
    public string? Mensagem { get; set; }
}