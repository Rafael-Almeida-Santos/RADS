using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RADS.DAL
{
    public class SqlServerPermissao
    {
        private MapPermissao Mapear(SqlDataReader row)
        {
            MapPermissao mapeamento = new MapPermissao();
            if (row != null)
            {
                mapeamento.id = Convert.ToInt32(row["id"]);
                mapeamento.idUsuario = Convert.ToInt32(row["idUsuario"]);
                mapeamento.idRotina = Convert.ToInt32(row["idRotina"]);
                mapeamento.administrador = Convert.ToBoolean(row["administrador"]);
                mapeamento.inserir = Convert.ToBoolean(row["inserir"]);
                mapeamento.editar = Convert.ToBoolean(row["editar"]);
                mapeamento.excluir = Convert.ToBoolean(row["excluir"]);
                mapeamento.acao = Convert.ToBoolean(row["acao"]);
                mapeamento.imprimir = Convert.ToBoolean(row["imprimir"]);
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
            sql.Append("idRotina as idRotina,");
            sql.Append("administrador as administrador,");
            sql.Append("inserir as inserir,");
            sql.Append("editar as editar,");
            sql.Append("excluir as excluir,");
            sql.Append("acao as acao,");
            sql.Append("imprimir as imprimir,");
            sql.Append("dataCadastro as dataCadastro, ");
            sql.Append("dataAlteracao as dataAlteracao");
            sql.Append(" from [Sistema].[Permissao] ");

            return sql.ToString();
        }

        #endregion

        #region Selecionar

        public IList<MapPermissao> ObterTodasPermissoes()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(ObterSql());
            sql.Append("Order by id");

            ConexaoBanco conexao = new ConexaoBanco();
            SqlDataReader dr = conexao.ConexaoSql(sql.ToString(), null).ExecuteReader();
            IList<MapPermissao> lista = new List<MapPermissao>();

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

        public MapPermissao ObterPermissao(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(ObterSql());
            sql.Append("where ");
            sql.Append("id = @id");

            SqlCommand parametro = new SqlCommand();
            parametro.Parameters.Add("id", SqlDbType.Int).Value = id;

            ConexaoBanco conexao = new ConexaoBanco();
            SqlDataReader dr = conexao.ConexaoSql(sql.ToString(), parametro).ExecuteReader();
            MapPermissao item = new MapPermissao();

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

        public int InserirPermissao(MapPermissao permissao)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Insert into [Sistema].[Permissao] (");
            sql.Append("idUsuario,");
            sql.Append("idRotina,");
            sql.Append("administrador,");
            sql.Append("inserir,");
            sql.Append("editar,");
            sql.Append("excluir,");
            sql.Append("acao,");
            sql.Append("imprimir,");
            sql.Append("dataCadastro,");
            sql.Append("dataAlteracao");
            sql.Append(") values (");
            sql.Append("@idUsuario,");
            sql.Append("@idRotina,");
            sql.Append("@administrador,");
            sql.Append("@inserir,");
            sql.Append("@editar,");
            sql.Append("@excluir,");
            sql.Append("@acao,");
            sql.Append("@imprimir,");
            sql.Append("@dataCadastro,");
            sql.Append("@dataAlteracao");
            sql.Append(")");

            SqlCommand parametro = new SqlCommand();
            parametro.Parameters.Add("idUsuario", SqlDbType.Int).Value = permissao.idUsuario;
            parametro.Parameters.Add("idRotina", SqlDbType.Int).Value = permissao.idRotina;
            parametro.Parameters.Add("administrador", SqlDbType.Bit).Value = permissao.administrador;
            parametro.Parameters.Add("inserir", SqlDbType.Bit).Value = permissao.inserir;
            parametro.Parameters.Add("editar", SqlDbType.Bit).Value = permissao.editar;
            parametro.Parameters.Add("excluir", SqlDbType.Bit).Value = permissao.excluir;
            parametro.Parameters.Add("acao", SqlDbType.Bit).Value = permissao.acao;
            parametro.Parameters.Add("imprimir", SqlDbType.Bit).Value = permissao.imprimir;
            parametro.Parameters.Add("dataCadastro", SqlDbType.DateTime).Value = permissao.dataCadastro;
            parametro.Parameters.Add("dataAlteracao", SqlDbType.DateTime).Value = permissao.dataAlteracao;

            ConexaoBanco conexao = new ConexaoBanco();
            int resultado = conexao.ConexaoSql(sql.ToString(), parametro).ExecuteNonQuery();

            return resultado;
        }

        #endregion

        #region Alterar

        public int AlterarPermissao(MapPermissao permissao)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Update [Sistema].[Permissao] set ");
            sql.Append("idUsuario = @idUsuario,");
            sql.Append("idRotina = @idRotina,");
            sql.Append("administrador = @administrador,");
            sql.Append("inserir = @inserir,");
            sql.Append("editar = @editar,");
            sql.Append("excluir = @excluir,");
            sql.Append("acao = @acao,");
            sql.Append("imprimir = @imprimir,");
            sql.Append("dataCadastro = @dataCadastro,");
            sql.Append("dataAlteracao = @dataAlteracao");
            sql.Append(" where ");
            sql.Append("id = @id");

            SqlCommand parametro = new SqlCommand();
            parametro.Parameters.Add("idUsuario", SqlDbType.Int).Value = permissao.idUsuario;
            parametro.Parameters.Add("idRotina", SqlDbType.Int).Value = permissao.idRotina;
            parametro.Parameters.Add("administrador", SqlDbType.Bit).Value = permissao.administrador;
            parametro.Parameters.Add("inserir", SqlDbType.Bit).Value = permissao.inserir;
            parametro.Parameters.Add("editar", SqlDbType.Bit).Value = permissao.editar;
            parametro.Parameters.Add("excluir", SqlDbType.Bit).Value = permissao.excluir;
            parametro.Parameters.Add("acao", SqlDbType.Bit).Value = permissao.acao;
            parametro.Parameters.Add("imprimir", SqlDbType.Bit).Value = permissao.imprimir;
            parametro.Parameters.Add("dataCadastro", SqlDbType.DateTime).Value = permissao.dataCadastro;
            parametro.Parameters.Add("dataAlteracao", SqlDbType.DateTime).Value = permissao.dataAlteracao;

            ConexaoBanco conexao = new ConexaoBanco();
            int resultado = conexao.ConexaoSql(sql.ToString(), parametro).ExecuteNonQuery();

            return resultado;
        }

        #endregion

        #region Excluir

        public int ExcluirPermissao(MapPermissao permissao)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Delete from [Sistema].[Permissao] where ");
            sql.Append("id = @id");

            SqlCommand parametro = new SqlCommand();
            parametro.Parameters.Add("id", SqlDbType.Int).Value = permissao.id;

            ConexaoBanco conexao = new ConexaoBanco();
            int resultado = conexao.ConexaoSql(sql.ToString(), parametro).ExecuteNonQuery();

            return resultado;
        }

        #endregion
    }
}