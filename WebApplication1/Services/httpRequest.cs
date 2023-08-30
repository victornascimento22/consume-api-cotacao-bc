using Newtonsoft.Json;
using System.Net.Http.Headers;

public class OlindaRequest
{
    public OlindaResponse Olinda(string datainicio, string datafim)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.ConnectionClose = false;

                var viewModel = new
                {
                    datainicio = datainicio,
                    datafim = datafim
                };

                var json = JsonConvert.SerializeObject(viewModel);
 

                // Construa a URL com os parâmetros de consulta
                string apiUrl = "https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/CotacaoMoedaPeriodoFechamento(codigoMoeda=@codigoMoeda,dataInicialCotacao=@dataInicialCotacao,dataFinalCotacao=@dataFinalCotacao)?@codigoMoeda='EUR'&@dataInicialCotacao=" + datainicio + "&@dataFinalCotacao=" + datafim + "&$format=json&$select=cotacaoCompra,cotacaoVenda,dataHoraCotacao";

                var response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    var obj = JsonConvert.DeserializeObject<OlindaResponse>(result);
                    

                    return obj;
                }
                else
                {
                    // Lida com a resposta de erro aqui, se necessário.
                    Console.WriteLine("A solicitação não teve sucesso. Status code: " + response.StatusCode);
                    return null;
                }
            }
        }
        catch (Exception ex)
        {
            // Lida com exceções aqui, se ocorrerem durante a solicitação.
            Console.WriteLine("Ocorreu uma exceção: " + ex.Message);
            return null;
        }
    }
}