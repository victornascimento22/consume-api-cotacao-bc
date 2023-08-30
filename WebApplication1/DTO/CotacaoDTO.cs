using Newtonsoft.Json;
using NPOI.SS.Util;
using System.ComponentModel.DataAnnotations;

public class CotacaoDTO
{


    [JsonProperty("cotacaoCompra")]
    public decimal CotacaoCompra { get; set; }

[JsonProperty("cotacaoVenda")]
public decimal CotacaoVenda { get; set; }

    [JsonProperty("dataHoraCotacao")]
    public string DataHoraCotacao { get; set; }
}

public class OlindaResponse 
{
    [JsonProperty("@odata.context")]
    public string Context { get; set; }

    [JsonProperty("value")]
    public List<CotacaoDTO> Cotacoes { get; set; }
}
