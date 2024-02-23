using System.Data.SqlClient;
using System.Data;

namespace RADS.DAL
{
    class ConexaoBanco
    {
        private string BancoDados()
        {
            return Properties.Settings.Default.BancoDev;
        }

        public SqlCommand ConexaoSql(string consulta, SqlCommand parametros)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = BancoDados();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;

            con.Open();

            if (parametros != null)
            {
                cmd = parametros;
            }

            cmd.CommandText = consulta;

            cmd.Connection = con;

            return cmd;
        }
    }
}