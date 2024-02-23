using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RADS.DAL
{
    public class SqlServerSenha
    {
        private MapSenha Mapear(SqlDataReader row)
        {
            MapSenha mapeamento = new MapSenha();
            if (row != null)
            {
                mapeamento.id = Convert.ToInt32(row["id"]);
                mapeamento.idUsuario = Convert.ToInt32(row["idUsuario"]);
                mapeamento.senha = Convert.ToString(row["senha"]);
                mapeamento.alterar = Convert.ToBoolean(row["alterar"]);
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
            sql.Append("idUsuario as idUsuario,");
            sql.Append("senha as senha,");
            sql.Append("alterar as alterar,");
            sql.Append("dataCadastro as dataCadastro, ");
            sql.Append("dataAlteracao as dataAlteracao");
            sql.Append(" from [Sistema].[Senha] ");

            return sql.ToString();
        }

        #endregion

        #region Selecionar

        public IList<MapSenha> ObterTodasSenhas()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(ObterSql());
            sql.Append("Order by id");

            ConexaoBanco conexao = new ConexaoBanco();
            SqlDataReader dr = conexao.ConexaoSql(sql.ToString(), null).ExecuteReader();
            IList<MapSenha> lista = new List<MapSenha>();

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

        public MapSenha ObterSenha(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(ObterSql());
            sql.Append("where ");
            sql.Append("id = @id");

            SqlCommand parametro = new SqlCommand();
            parametro.Parameters.Add("id", SqlDbType.Int).Value = id;

            ConexaoBanco conexao = new ConexaoBanco();
            SqlDataReader dr = conexao.ConexaoSql(sql.ToString(), parametro).ExecuteReader();
            MapSenha item = new MapSenha();

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

        public MapSenha ObterSenha(int idUsuario, string senha)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(ObterSql());
            sql.Append("where ");
            sql.Append("idUsuario = @idUsuario and");
            sql.Append("senha = @senha");

            SqlCommand parametro = new SqlCommand();
            parametro.Parameters.Add("idUsuario", SqlDbType.Int).Value = idUsuario;
            parametro.Parameters.Add("senha", SqlDbType.VarChar).Value = senha;

            ConexaoBanco conexao = new ConexaoBanco();
            SqlDataReader dr = conexao.ConexaoSql(sql.ToString(), parametro).ExecuteReader();
            MapSenha item = new MapSenha();

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

        public int InserirSenha(MapSenha senha)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Insert into [Sistema].[Senha] (");
            sql.Append("idUsuario,");
            sql.Append("senha,");
            sql.Append("alterar,");
            sql.Append("dataCadastro,");
            sql.Append("dataAlteracao");
            sql.Append(") values (");
            sql.Append("@idUsuario,");
            sql.Append("@senha,");
            sql.Append("@alterar,");
            sql.Append("@dataCadastro,");
            sql.Append("@dataAlteracao");
            sql.Append(")");

            SqlCommand parametro = new SqlCommand();
            parametro.Parameters.Add("idUsuario", SqlDbType.Int).Value = senha.idUsuario;
            parametro.Parameters.Add("senha", SqlDbType.VarChar).Value = senha.senha;
            parametro.Parameters.Add("alterar", SqlDbType.Bit).Value = senha.alterar;
            parametro.Parameters.Add("dataCadastro", SqlDbType.DateTime).Value = senha.dataCadastro;
            parametro.Parameters.Add("dataAlteracao", SqlDbType.DateTime).Value = senha.dataAlteracao;

            ConexaoBanco conexao = new ConexaoBanco();
            int resultado = conexao.ConexaoSql(sql.ToString(), parametro).ExecuteNonQuery();

            return resultado;
        }

        #endregion

        #region Alterar

        public int AlterarSenha(MapSenha senha)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Update [Sistema].[Senha] set ");
            sql.Append("idUsuario = @idUsuario,");
            sql.Append("senha = @senha,");
            sql.Append("alterar = @alterar,");
            sql.Append("dataCadastro = @dataCadastro,");
            sql.Append("dataAlteracao = @dataAlteracao");
            sql.Append(" where ");
            sql.Append("id = @id");

            SqlCommand parametro = new SqlCommand();
            parametro.Parameters.Add("id", SqlDbType.Int).Value = senha.id;
            parametro.Parameters.Add("idUsuario", SqlDbType.Int).Value = senha.idUsuario;
            parametro.Parameters.Add("senha", SqlDbType.VarChar).Value = senha.senha;
            parametro.Parameters.Add("alterar", SqlDbType.Bit).Value = senha.alterar;
            parametro.Parameters.Add("dataCadastro", SqlDbType.DateTime).Value = senha.dataCadastro;
            parametro.Parameters.Add("dataAlteracao", SqlDbType.DateTime).Value = senha.dataAlteracao;

            ConexaoBanco conexao = new ConexaoBanco();
            int resultado = conexao.ConexaoSql(sql.ToString(), parametro).ExecuteNonQuery();

            return resultado;
        }

        #endregion

        #region Excluir

        public int ExcluirSenha(MapSenha senha)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Delete from [Sistema].[Senha] where ");
            sql.Append("id = @id");

            SqlCommand parametro = new SqlCommand();
            parametro.Parameters.Add("id", SqlDbType.Int).Value = senha.id;

            ConexaoBanco conexao = new ConexaoBanco();
            int resultado = conexao.ConexaoSql(sql.ToString(), parametro).ExecuteNonQuery();

            return resultado;
        }

        #endregion
    }
}