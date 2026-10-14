using Microsoft.AspNetCore.Mvc;

namespace ProgramacaoDoZero.Controllers
{
    [Route("api/aula8")]
    [ApiController]
    public class Aula8Controller : ControllerBase
    {
        [Route("olaMundo")]
        [HttpGet]
        public string OlaMundo()
        {
            var mensagem = "Olá mundo via API Julia";

            return mensagem;
        }
        //-----------------------
        [Route("olaMundoPersonalizado")]
        [HttpGet]
        public string OlaMundoPersonalizado(string nome)
        {
            var mensagem = "Olá mundo via API " + nome;

            return mensagem;
        }
        //-------------------
        [Route("somar")]
        [HttpGet]
        public string Somar(int valor1, int valor2)
        {
            var soma = valor1 + valor2;

            var mensagem = " A soma é " + soma;

            return mensagem;
        }
        //----------------------
        [Route("media")]
        [HttpGet]

        public string Media(int nota1, int nota2)
        {
            var soma = nota1 + nota2;

            var media = soma / 2;

            var mensagem = " A média é " + media;

            return mensagem;

        }
        //-------------------
        [Route("terreno")]
        [HttpGet]

        public string Terreno(int largura, int comprimento, int valor)
        {
            var soma = largura * comprimento;

            var total = soma * valor;

            var mensagem = " O terreno tem " + soma + " metros quadrados é custa R$ " + total;

            return mensagem;
        }
        //--------------------
        [Route("troco")]
        [HttpGet]

        public string Troco(int produto, int quantidade, int valorPg)
        {
            var vlCompra = produto * quantidade;

            var troco = valorPg - vlCompra;

            if (troco < 0)
            {
                return " O valor pago é insuficiente para pagar a compra. ";
            }
            return "O troco do cliente é de R$ " + troco;
        }
        //---------------------------------

        [Route("salario")]
        [HttpGet]

        public string Salario(string funcionario, int valorHr, int horas)
        {
            var soma = valorHr * horas;

            var mensagem = "O " + funcionario + ", têm a receber o valor de " + soma;

            return mensagem;

        }
        //------------------------------------
        [Route("consumo")]
        [HttpGet]

        public string Consumo(int distancia, int litros)
        {
            var soma = distancia / litros;

            var mensagem = "O veiculo faz " + soma + " por litro de combustivel!";

            return mensagem;
        }


    }
}
