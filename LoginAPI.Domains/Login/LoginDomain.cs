using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginAPI.Models.Login;
using Microsoft.Extensions.Configuration;

namespace LoginAPI.Domains.Login
{
    public class LoginDomain: ILoginDomain
    {
        public IConfiguration _config;

        public LoginDomain(IConfiguration config)
        {
            _config = config;
        }

        public int Login(Credencial credencial)
        {
            var connection = ConnectionSQL(_config.GetSection("ServerConnection").Value);
            return ExecutaLogin(connection, credencial, "verificaLOGIN_V1");

        }

        private SqlConnection ConnectionSQL(string connection)
        {
            return new SqlConnection(connection);
        }

        private int ExecutaLogin(SqlConnection connection, Credencial credencial, string procedure)
        {
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedure;

            cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar);
            cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar);

            cmd.Parameters["@USERNAME"].Value = credencial.Username;
            cmd.Parameters["@PASSWORD"].Value = credencial.Password;

            cmd.Parameters.Add("@ERRO", SqlDbType.Int).Direction = ParameterDirection.Output;


            SqlDataReader dr = cmd.ExecuteReader();
            var ERRO = cmd.Parameters["@ERRO"].Value;

            connection.Close();

            return Convert.ToInt32(ERRO);
        }
    }
}
