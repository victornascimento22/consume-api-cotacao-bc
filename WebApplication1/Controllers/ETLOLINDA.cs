using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repository;
using WebApplication1.VM;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ETLOlinda : ControllerBase
    {
        private readonly OlindaRequest _request;
        private readonly CotacaoRepository _repositorio = new();
        
        public ETLOlinda(OlindaRequest request)
        {
            _request = request;
        }

        [HttpGet("ETL")]
        public IActionResult Euro([FromQuery] Request datas)
        {
            var result = _request.Olinda(datas.Datainicio, datas.Datafim);

            
            if (result != null)
            {
                _repositorio.SaveCotacao(result);
                
                return Ok(result);
            }
            else
            {
                // Lida com o erro de solicitação aqui, se necessário.
                return BadRequest("A solicitação não teve sucesso.");
            }
        }
    }
}
