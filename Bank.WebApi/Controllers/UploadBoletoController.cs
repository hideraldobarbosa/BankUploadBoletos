using Bank.Application.Interfaces;
using Bank.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Bank.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadBoletoController : ControllerBase
    {
        private readonly ICarteiraAtivosClienteService _carteiraAtivosClienteService;

        public UploadBoletoController(ICarteiraAtivosClienteService carteiraAtivosClienteService)
        {
            _carteiraAtivosClienteService = carteiraAtivosClienteService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file.ContentType != "text/plain")
            {
                return BadRequest("Tipo formato inválido");

            }

            List<CarteiraAtivosPorCliente> carteiras = new();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {

                var texto = reader.ReadToEnd();

                if (!(texto.Contains("0#RV") && texto.Contains("99#RV")))
                {
                    return BadRequest("Tipo formato inválido");
                }

            }

            using (var reader = new StreamReader(file.OpenReadStream()))
            {

                while (reader.Peek() >= 0)
                {
                    var ativosNegociados = await reader.ReadLineAsync();
                    if (!String.IsNullOrWhiteSpace(ativosNegociados))
                    {
                        if (!(ativosNegociados.Contains("0#RV") || ativosNegociados.Contains("99#RV")))
                        {
                            var ativo = ativosNegociados.Split("#");

                            CarteiraAtivosPorCliente carteira = new(
                                DateTime.ParseExact(ativo[1], "yyyyMMdd", CultureInfo.InvariantCulture),
                                ativo[2],
                                ativo[3],
                                ativo[4],
                                ativo[5],
                                ativo[6],
                                ativo[7] != "" ? int.Parse(ativo[7]) : 0,
                                ativo[8] != "" ? decimal.Parse(ativo[8]) : 0);

                            carteiras.Add(carteira);
                        }
                    }
                }
            }

            var response = await _carteiraAtivosClienteService.InserirDadosCarteira(carteiras);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUpload()
        {

            await _carteiraAtivosClienteService.DeleteDadosCarteira();
            return Ok();

        }
    }
}