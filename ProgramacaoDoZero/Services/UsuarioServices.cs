using ProgramacaoDoZero.Common;
using ProgramacaoDoZero.Models;
using ProgramacaoDoZero.Repository;

namespace ProgramacaoDoZero.Services
{
    public class UsuarioService
    {
        private string _connectionString;

        public UsuarioService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public LoginResult Login(string email, string senha)
        {
            var result = new LoginResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario != null)
            {
                if (usuario.Senha == senha)
                {
                    //faz login
                    result.sucesso = true;
                    result.UsuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    result.sucesso = false;
                    result.mensagem = "Usuário ou senha inválidos";
                }
            }
            else
            {
                result.sucesso = false;
                result.mensagem = "Usuário ou senha inválidos";
            }

            return result;
        }


        public CadastroResult Cadastro(
            string nome,
            string sobrenome,
            string telefone,
            string genero,
            string email,
            string senha)
        {
            var result = new CadastroResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario != null)
            {
                result.sucesso = false;
                result.mensagem = "Usuário já existe no sistema";
            }
            else
            {
                usuario = new Usuario();

                usuario.Nome = nome;
                usuario.Sobrenome = sobrenome;
                usuario.Telefone = telefone;
                usuario.Email = email;
                usuario.Genero = genero;
                usuario.Senha = senha;
                usuario.UsuarioGuid = Guid.NewGuid();

                var affectedRows = usuarioRepository.Inserir(usuario);

                if (affectedRows > 0)
                {
                    result.sucesso = true;
                    result.UsuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    result.sucesso = false;
                    result.mensagem = "Erro ao inserir usuário. Tente novamente";
                }
            }

            return result;
        }


        public EsqueceuSenhaResult EsqueceuSenha(string email)
        {
            var result = new EsqueceuSenhaResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario == null)
            {
                result.sucesso = false;
                result.mensagem = "Usuário não existe para esse e-mail";
            }
            else
            {
                var emailSender = new EmailSender();

                var assunto = "Recuperação de Senha";
                var corpo = "Sua senha é " + usuario.Senha;

                emailSender.Enviar(
                    assunto,
                    corpo,
                    usuario.Email
                );

                result.sucesso = true;
                result.mensagem = "E-mail enviado com sucesso";
            }

            return result;
        }

        public Usuario ObterUsuario(Guid usuarioGuid)
        {
            var usuario = new UsuarioRepository(_connectionString).ObterPorGuid(usuarioGuid);

            return usuario;
        }
    }
}