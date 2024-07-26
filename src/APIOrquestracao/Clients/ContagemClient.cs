using System.Net.Http.Headers;

namespace APIOrquestracao.Clients;

public class ContagemClient
{
    private readonly HttpClient _client;

    public ContagemClient(HttpClient client)
    {
        _client = client;
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        _client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
    }

    public async Task<T?> ObterContagemAsync<T>(string urlApi) =>
        await _client.GetFromJsonAsync<T>(urlApi)!;
}