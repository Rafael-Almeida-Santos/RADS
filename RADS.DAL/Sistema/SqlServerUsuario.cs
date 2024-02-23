using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RADS.DAL
{
    public class SqlServerUsuario
    {
        private MapUsuario Mapear(SqlDataReader row)
        {
            MapUsuario mapeamento = new MapUsuario();
            if (row != null)
            {
                mapeamento.id = Convert.ToInt32(row["id"]);
                mapeamento.nome = Convert.ToString(row["nome"]);
                mapeamento.sobrenome = Convert.ToString(row["sobrenome"]);
                mapeamento.cpf = Convert.ToString(row["cpf"]);
                mapeamento.dataNascimento = Convert.ToDateTime(row["dataNascimento"]);
                mapeamento.email = Convert.ToString(row["email"]);
                mapeamento.telefone = Convert.ToString(row["telefone"]);
                mapeamento.celular = Convert.ToString(row["celular"]);
                mapeamento.status = Convert.ToBoolean(row["status"]);
                mapeamento.dataCadastro = Convert.ToDateTime(row["dataCadastro"]);
                mapeamento.dataAlteracao = Convert.ToDateTime(row["dataAlteracao"]);
            }

            return mapeamento;
        }

        #region Obter SQL

        private string ObterSql()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Select ");
            sql.Append("id as id,");
            sql.Append("nome as nome,");
            sql.Append("sobrenome as sobrenome,");
            sql.Append("cpf as cpf,");
            sql.Append("dataNascimento as dataNascimento,");
            sql.Append("email as email,");
            sql.Append("telefone as telefone,");
            sql.Append("celular as celular,");
            sql.Append("status as status,");
            sql.Append("dataCadastro as dataCadastro, ");
            sql.Append("dataAlteracao as dataAlteracao");
            sql.Append(" from [Sistema].[Usuario] ");

            return sql.ToString();
        }

        #endregion

        #region Selecionar

        public IList<MapUsuario> ObterTodosUsuarios()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(ObterSql());
            sql.Append("Order by id");

            ConexaoBanco conexao = new ConexaoBanco();
            SqlDataReader dr = conexao.ConexaoSql(sql.ToString(), null).ExecuteReader();
            IList<MapUsuario> lista = new List<MapUsuario>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lista.Add(Mapear(dr));
                }
            }
            else
            {
                lista = null;
            }

            return lista;
        }

        public MapUsuario ObterUsuario(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(ObterSql());
            sql.Append("where ");
            sql.Append("id = @id");

            SqlCommand parametro = new SqlCommand();
            parametro.Parameters.Add("id", SqlDbType.Int).Value = id;

            ConexaoBanco conexao = new ConexaoBanco();
            SqlDataReader dr = conexao.ConexaoSql(sql.ToString(), parametro).ExecuteReader();
            MapUsuario item = new MapUsuario();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    item = Mapear(dr);
                }
            }
            else
            {
                //item = null;
            }

            return item;
        }

        public MapUsuario ObterUsuario(string cpf)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(ObterSql());
            sql.Append("where ");
            sql.Append("cpf = @cpf");

            SqlCommand parametro = new SqlCommand();
            parametro.Parameters.Add("cpf", SqlDbType.VarChar).Value = cpf;

            ConexaoBanco conexao = new ConexaoBanco();
            SqlDataReader dr = conexao.ConexaoSql(sql.ToString(), parametro).ExecuteReader();
            MapUsuario item = new MapUsuario();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    item = Mapear(dr);
                }
            }
            else
            {
                //item = null;
            }

            return item;
        }

        #endregion

        #region Inserir

        public int InserirUsuario(MapUsuario usuario)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Insert into [Sistema].[Usuario] (");
            sql.Append("nome,");
            sql.Append("sobrenome,");
            sql.Append("cpf,");
            sql.Append("dataNascimento,");
            sql.Append("email,");
            sql.Append("telefone,");
            sql.Append("celular,");
            sql.Append("status,");
            sql.Append("dataCadastro,");
            sql.Append("dataAlteracao");
            sql.Append(") values (");
            sql.Append("@nome,");
            sql.Append("@sobrenome,");
            sql.Append("@cpf,");
            sql.Append("@dataNascimento,");
            sql.Append("@email,");
            sql.Append("@telefone,");
            sql.Append("@celular,");
            sql.Append("@status,");
            sql.Append("@dataCadastro,");
            sql.Append("@dataAlteracao");
            sql.Append(")");

            SqlCommand parametro = new SqlCommand();
            parametro.Parameters.Add("nome", SqlDbType.VarChar).Value = usuario.nome;
            parametro.Parameters.Add("sobrenome", SqlDbType.VarChar).Value = usuario.sobrenome;
            parametro.Parameters.Add("cpf", SqlDbType.VarChar).Value = usuario.cpf;
            parametro.Parameters.Add("dataNascimento", SqlDbType.Date).Value = usuario.dataNascimento;
            parametro.Parameters.Add("email", SqlDbType.VarChar).Value = usuario.email;
            parametro.Parameters.Add("telefone", SqlDbType.VarChar).Value = usuario.telefone;
            parametro.Parameters.Add("celular", SqlDbType.VarChar).Value = usuario.celular;
            parametro.Parameters.Add("status", SqlDbType.Bit).Value = usuario.status;
            parametro.Parameters.Add("dataCadastro", SqlDbType.DateTime).Value = usuario.dataCadastro;
            parametro.Parameters.Add("dataAlteracao", SqlDbType.DateTime).Value = usuario.dataAlteracao;

            ConexaoBanco conexao = new ConexaoBanco();
            int resultado = conexao.ConexaoSql(sql.ToString(), parametro).ExecuteNonQuery();

            return resultado;
        }

        #endregion

        #region Alterar

        public int AlterarUsuario(MapUsuario usuario)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Update [Sistema].[Usuario] set ");
            sql.Append("nome = @nome,");
            sql.Append("sobrenome = @sobrenome,");
            sql.Append("cpf = @cpf,");
            sql.Append("dataNascimento = @dataNascimento,");
            sql.Append("email = @email,");
            sql.Append("telefone = @telefone,");
            sql.Append("celular = @celular,");
            sql.Append("status = @status,");
            sql.Append("dataCadastro = @dataCadastro,");
            sql.Append("dataAlteracao = @dataAlteracao");
            sql.Append(" where ");
            sql.Append("id = @id");

            SqlCommand parametro = new SqlCommand();
            parametro.Parameters.Add("id", SqlDbType.Int).Value = usuario.id;
            parametro.Parameters.Add("nome", SqlDbType.VarChar).Value = usuario.nome;
            parametro.Parameters.Add("sobrenome", SqlDbType.VarChar).Value = usuario.sobrenome;
            parametro.Parameters.Add("cpf", SqlDbType.VarChar).Value = usuario.cpf;
            parametro.Parameters.Add("dataNascimento", SqlDbType.Date).Value = usuario.dataNascimento;
            parametro.Parameters.Add("email", SqlDbType.VarChar).Value = usuario.email;
            parametro.Parameters.Add("telefone", SqlDbType.VarChar).Value = usuario.telefone;
            parametro.Parameters.Add("celular", SqlDbType.VarChar).Value = usuario.celular;
            parametro.Parameters.Add("status", SqlDbType.Bit).Value = usuario.status;
            parametro.Parameters.Add("dataCadastro", SqlDbType.DateTime).Value = usuario.dataCadastro;
            parametro.Parameters.Add("dataAlteracao", SqlDbType.DateTime).Value = usuario.dataAlteracao;

            ConexaoBanco conexao = new ConexaoBanco();
            int resultado = conexao.ConexaoSql(sql.ToString(), parametro).ExecuteNonQuery();

            return resultado;
        }

        #endregion

        #region Excluir

        public int ExcluirUsuario(MapUsuario usuario)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Delete from [Sistema].[Usuario] where ");
            sql.Append("id = @id");

            SqlCommand parametro = new SqlCommand();
            parametro.Parameters.Add("id", SqlDbType.Int).Value = usuario.id;

            ConexaoBanco conexao = new ConexaoBanco();
            int resultado = conexao.ConexaoSql(sql.ToString(), parametro).ExecuteNonQuery();

            return resultado;
        }

        #endregion
    }
}