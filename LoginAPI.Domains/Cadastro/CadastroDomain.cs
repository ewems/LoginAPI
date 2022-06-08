using LoginAPI.Models.Cadastro;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace LoginAPI.Domains.Cadastro
{
    public class CadastroDomain: ICadastroDomain
    {
        public IConfiguration _config;

        public CadastroDomain(IConfiguration config)
        {
            _config = config;
        }

        public void Cadastro(Usuario usuario)
        {
            var connection = ConnectionSQL(_config.GetSection("ServerConnection").Value);
            ExecutaCadastro(connection, usuario, "cadastraUSUARIO_V1");
        }

        private SqlConnection ConnectionSQL (string connection)
        {
            return new SqlConnection(connection);
        }

        private void ExecutaCadastro (SqlConnection connection, Usuario usuario, string procedure)
        {
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedure;

            cmd.Parameters.Add("@NOME", SqlDbType.VarChar);
            cmd.Parameters.Add("@DTNASC", SqlDbType.SmallDateTime);
            cmd.Parameters.Add("@CPF", SqlDbType.VarChar);
            cmd.Parameters.Add("@NATURAL", SqlDbType.VarChar);
            cmd.Parameters.Add("@UF", SqlDbType.VarChar);
            cmd.Parameters.Add("@TEL", SqlDbType.VarChar);
            cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar);
            cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar);
            cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar);

            cmd.Parameters["@NOME"].Value = usuario.Nome;
            cmd.Parameters["@DTNASC"].Value = usuario.DtNascimento;
            cmd.Parameters["@CPF"].Value = usuario.CPF;
            cmd.Parameters["@NATURAL"].Value = usuario.Natural;
            cmd.Parameters["@UF"].Value = usuario.UF;
            cmd.Parameters["@TEL"].Value = usuario.Tel;
            cmd.Parameters["@EMAIL"].Value = usuario.Email;
            cmd.Parameters["@USERNAME"].Value = usuario.Username;
            cmd.Parameters["@PASSWORD"].Value = usuario.Password;

            SqlDataReader dr = cmd.ExecuteReader();

            connection.Close();
        }
    }
}
