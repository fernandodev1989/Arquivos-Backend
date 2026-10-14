using System;
using MySql.Data.MySqlClient;
using ProgramacaoDoZero.Services; // Certifique-se de que a classe Usuario está visível neste namespace/projeto

namespace ProgramacaoDoZero.Repository
{
    public class UsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Inserir(Usuario usuario)
        {
            using (var cnn = new MySqlConnection(_connectionString))
            {
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandText = @"INSERT INTO usuario
                        (nome, sobrenome, telefone, email, genero, senha, usuarioGuid)
                        VALUES
                        (@nome, @sobrenome, @telefone, @email, @genero, @senha, @usuarioGuid)";

                    cmd.Parameters.AddWithValue("@nome", usuario.Nome);
                    cmd.Parameters.AddWithValue("@sobrenome", usuario.Sobrenome);
                    cmd.Parameters.AddWithValue("@telefone", usuario.Telefone);
                    cmd.Parameters.AddWithValue("@email", usuario.Email);
                    cmd.Parameters.AddWithValue("@genero", usuario.Genero);
                    cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                    cmd.Parameters.AddWithValue("@usuarioGuid", usuario.UsuarioGuid);

                    cnn.Open();

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public Usuario ObterUsuarioPorEmail(string email)
        {
            using (var cnn = new MySqlConnection(_connectionString))
            {
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandText = "SELECT * FROM usuario WHERE email = @email";
                    cmd.Parameters.AddWithValue("@email", email);

                    cnn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var usuario = new Usuario();

                            usuario.Nome = reader["nome"].ToString();
                            usuario.Sobrenome = reader["sobrenome"].ToString();
                            usuario.Telefone = reader["telefone"].ToString();
                            usuario.Email = reader["email"].ToString();
                            usuario.Genero = reader["genero"].ToString();
                            usuario.Senha = reader["senha"].ToString();

                            var usuarioGuid = reader["usuarioGuid"].ToString();
                            usuario.UsuarioGuid = new Guid(usuarioGuid);

                            return usuario;
                        }

                        return null;
                    }
                }
            }
        }

        public Usuario ObterPorGuid(Guid usuarioGuid)
        {
            using (var cnn = new MySqlConnection(_connectionString))
            {
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandText = "SELECT * FROM usuario WHERE usuarioGuid = @usuarioGuid";
                    cmd.Parameters.AddWithValue("@usuarioGuid", usuarioGuid);

                    cnn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var usuario = new Usuario();

                            usuario.Nome = reader["nome"].ToString();
                            usuario.Sobrenome = reader["sobrenome"].ToString();
                            usuario.Telefone = reader["telefone"].ToString();
                            usuario.Email = reader["email"].ToString();
                            usuario.Genero = reader["genero"].ToString();
                            usuario.Senha = reader["senha"].ToString();

                            var guid = reader["usuarioGuid"].ToString();
                            usuario.UsuarioGuid = new Guid(guid);

                            return usuario;
                        }

                        return null;
                    }
                }
            }
        }
    }
}