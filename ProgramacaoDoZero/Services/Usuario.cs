namespace ProgramacaoDoZero.Services
{
    public class Usuario
    {
        public Usuario()
        {

        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Genero { get; set; }
        public string Senha { get; set; }
        public Guid UsuarioGuid { get; set; }
    }
}