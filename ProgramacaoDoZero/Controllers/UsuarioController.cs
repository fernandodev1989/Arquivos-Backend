using Microsoft.AspNetCore.Mvc;
using ProgramacaoDoZero.Models;
using ProgramacaoDoZero.Services;
using System.Configuration;

namespace ProgramacaoDoZero.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IConfiguration _configuration;

        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
            

        [Route("login")]
        [HttpPost]
        public LoginResult Login(LoginRequest request)
        {
            var result = new LoginResult();

            if (request == null)
            {
                result.sucesso = false;
                result.mensagem = "Request veio nulo";
            }
            else if (string.IsNullOrEmpty(request.email))
            {
                result.sucesso = false;
                result.mensagem = "Email obrigatório";
            }
            else if (string.IsNullOrEmpty(request.senha))
            {
                result.sucesso = false;
                result.mensagem = "Senha obrigatória";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.Login(request.email, request.senha);
            }

            return result;
        }

        [Route("cadastro")]
        [HttpPost]
        public CadastroResult Cadastro(CadastroRequest request)
        {
            var result = new CadastroResult();

            if (request == null ||
                string.IsNullOrWhiteSpace(request.nome) ||
                string.IsNullOrWhiteSpace(request.sobrenome) ||
                string.IsNullOrWhiteSpace(request.telefone) ||
                string.IsNullOrWhiteSpace(request.email) ||
                string.IsNullOrWhiteSpace(request.genero) ||
                string.IsNullOrWhiteSpace(request.senha))
            {
                result.sucesso = false;
                result.mensagem = "Todos os campos são obrigatórios!";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.Cadastro(request.nome, request.sobrenome, request.telefone, request.genero, request.email, request.senha);

            }
            return result;
        }

        [HttpPost]
        [Route("esqueceuSenha")]
        public EsqueceuSenhaResult EsqueceuSenha(EsqueceuSenhaRequest request)
        {
            var result = new EsqueceuSenhaResult();

            if (request == null || string.IsNullOrEmpty(request.email))

            {
                result.sucesso = false;
                result.mensagem = "E-mail obrigatorio!";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.EsqueceuSenha(request.email);
            }

            return result;
            }

        [HttpGet]
        [Route("obterUsuario")]
        public ObterUsuarioResult ObterUsuario(Guid usuarioGuid)
        {
            var result = new ObterUsuarioResult();

            if (usuarioGuid == null) 
            {
                result.mensagem = "Usuário Guid vazio";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

                var usuario = new UsuarioService(connectionString).ObterUsuario(usuarioGuid);

                if (usuario == null)
                {
                    result.mensagem = "Usuario não existe";
                }
                else
                {
                    result.sucesso = true;
                    result.nome = usuario.Nome;
                }
            }

            return result;
        }
     }
 }
