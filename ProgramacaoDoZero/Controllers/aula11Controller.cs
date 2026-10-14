using Microsoft.AspNetCore.Mvc;
using ProgramacaoDoZero.Models;

namespace ProgramacaoDoZero.Controllers
{
    [Route("api/aula11")]
    [ApiController]
    public class Aula11Controller : ControllerBase
    {
        [Route("obterVeiculo")]
        [HttpGet]
        public Veiculo obterVeiculo()
        {
            var meuVeiculo = new Veiculo();

            meuVeiculo.Cor = "Branco";
            meuVeiculo.Marca = "Renault";
            meuVeiculo.Modelo = "Duster";
            meuVeiculo.Placa = "SGZ-1599";

            meuVeiculo.Acelerar();
            meuVeiculo.Acelerar();
            meuVeiculo.Acelerar();
            meuVeiculo.Acelerar(); 
            meuVeiculo.Acelerar();
            meuVeiculo.Acelerar();

            return meuVeiculo;
        }

        [Route("obterCarro")]
        [HttpGet]

        public Carro obterCarro()
        {
            var meuCarro = new Carro();

            meuCarro.Marca = "Honda";
            meuCarro.Modelo = "Civic";
            meuCarro.Placa = "FRE1254";
            meuCarro.Cor = "Vermelho";

            meuCarro.Acelerar();
            meuCarro.Acelerar();
            meuCarro.Acelerar();
            meuCarro.Acelerar();
            meuCarro.Acelerar();

            return meuCarro;

        }

        [Route("obterMoto")]
        [HttpGet]

        public Moto ObterMoto()
        {
            var minhaMoto = new Moto();

            minhaMoto.Marca = "Honda";
            minhaMoto.Modelo = "CG Fan";
            minhaMoto.Placa = "FWE1254";
            minhaMoto.Cor = "Verde";

            minhaMoto.Acelerar();
            minhaMoto.Acelerar();
            minhaMoto.Acelerar();
            minhaMoto.Acelerar();
            minhaMoto.Acelerar();

            return minhaMoto;

        }
    }
}
