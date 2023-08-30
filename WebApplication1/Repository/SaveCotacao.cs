using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace WebApplication1.Repository
{
    public class CotacaoRepository
    {

        private readonly string _connection = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=187.108.201.70)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=capital)));Validate connection=true; User Id=dwu;Password=S7hHmdmz28i2;";
     

        public bool SaveCotacao(OlindaResponse cotacao)
        {
            try
            {
                var query = @"
                    INSERT INTO ETL_OLINDA_EURO (cotacaoCompra, cotacaoVenda, dataHoraCotacao)
                    VALUES (@CotacaoCompra, @CotacaoVenda, @DataHoraCotacao)";

                using (var connection = new OracleConnection(_connection))
                {


                    foreach (var cotacaoDTO in cotacao.Cotacoes)
                    {
                        var parametros = new
                        {
                            CotacaoCompra = cotacaoDTO.CotacaoCompra,
                            CotacaoVenda = cotacaoDTO.CotacaoVenda,
                            DataHoraCotacao = cotacaoDTO.DataHoraCotacao
                        };

                        connection.Execute(query, parametros);
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}