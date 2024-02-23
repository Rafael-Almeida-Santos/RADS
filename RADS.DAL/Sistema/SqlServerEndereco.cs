using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RADS.DAL
{
    public class SqlServerEndereco
    {
        private MapEndereco Mapear(SqlDataReader row)
        {
            MapEndereco mapeamento = new MapEndereco();
            if (row != null)
            {
                mapeamento.id = Convert.ToInt32(row["id"]);
                mapeamento.idUsuario = Convert.ToInt32(row["idUsuario"]);
                mapeamento.idInquilino = Convert.ToInt32(row["idInquilino"]);
                mapeamento.idImovel = Convert.ToInt32(row["idImovel"]);
                mapeamento.endereco = Convert.ToString(row["endereco"]);
                mapeamento.numero = Convert.ToString(row["numero"]);
                mapeamento.complemento = Convert.ToString(row["complemento"]);
                mapeamento.bairro = Convert.ToString(row["bairro"]);
                mapeamento.cidade = Convert.ToString(row["cidade"]);
                mapeamento.uf = Convert.ToString(row["uf"]);
                mapeamento.pais = Convert.ToString(row["pais"]);
                mapeamento.principal = Convert.ToBoolean(row["principal"]);
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
            sql.Append("idInquilino as idInquilino,");
            sql.Append("idImovel as idImovel,");
            sql.Append("endereco as endereco,");
            sql.Append("numero as numero,");
            sql.Append("complemento as complemento,");
            sql.Append("bairro as bairro,");
            sql.Append("cidade as cidade,");
            sql.Append("uf as uf,");
            sql.Append("pais as pais,");
            sql.Append("principal as principal,");
            sql.Append("dataCadastro as dataCadastro, ");
            sql.Append("dataAlteracao as dataAlteracao");
            sql.Append(" from [Sistema].[Endereco] ");

            return sql.ToString();
        }

        #endregion

        #region Selecionar

        public IList<MapEndereco> ObterTodosEnderecos()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(ObterSql());
            sql.Append("Order by id");

            ConexaoBanco conexao = new ConexaoBanco();
            SqlDataReader dr = conexao.ConexaoSql(sql.ToString(), null).ExecuteReader();
            IList<MapEndereco> lista = new List<MapEndereco>();

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

        public MapEndereco ObterEndereco(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(ObterSql());
            sql.Append("where ");
            sql.Append("id = @id");

            SqlCommand parametro = new SqlCommand();
            parametro.Parameters.Add("id", SqlDbType.Int).Value = id;

            ConexaoBanco conexao = new ConexaoBanco();
            SqlDataReader dr = conexao.ConexaoSql(sql.ToString(), parametro).ExecuteReader();
            MapEndereco item = new MapEndereco();

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

        public MapEndereco ObterEnderecoUsuario(int idUsuario)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(ObterSql());
            sql.Append("where ");
            sql.Append("idUsuario = @idUsuario");

            SqlCommand parametro = new SqlCommand();
            parametro.Parameters.Add("idUsuario", SqlDbType.Int).Value = idUsuario;

            ConexaoBanco conexao = new ConexaoBanco();
            SqlDataReader dr = conexao.ConexaoSql(sql.ToString(), parametro).ExecuteReader();
            MapEndereco item = new MapEndereco();

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

        public MapEndereco ObterEnderecoInquilino(int idInquilino)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(ObterSql());
            sql.Append("where ");
            sql.Append("idInquilino = @idInquilino");

            SqlCommand parametro = new SqlCommand();
            parametro.Parameters.Add("idInquilino", SqlDbType.Int).Value = idInquilino;

            ConexaoBanco conexao = new ConexaoBanco();
            SqlDataReader dr = conexao.ConexaoSql(sql.ToString(), parametro).ExecuteReader();
            MapEndereco item = new MapEndereco();

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

        public MapEndereco ObterEnderecoImovel(int idImovel)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(ObterSql());
            sql.Append("where ");
            sql.Append("idImovel = @idImovel");

            SqlCommand parametro = new SqlCommand();
            parametro.Parameters.Add("idImovel", SqlDbType.Int).Value = idImovel;

            ConexaoBanco conexao = new ConexaoBanco();
            SqlDataReader dr = conexao.ConexaoSql(sql.ToString(), parametro).ExecuteReader();
            MapEndereco item = new MapEndereco();

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

        public int InserirEndereco(MapEndereco endereco)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Insert into [Sistema].[Endereco] (");
            sql.Append("idUsuario,");
            sql.Append("idInquilino,");
            sql.Append("idImovel,");
            sql.Append("endereco,");
            sql.Append("numero,");
            sql.Append("complemento,");
            sql.Append("bairro,");
            sql.Append("cidade,");
            sql.Append("uf,");
            sql.Append("pais,");
            sql.Append("principal,");
            sql.Append("dataCadastro,");
            sql.Append("dataAlteracao");
            sql.Append(") values (");
            sql.Append("@idUsuario,");
            sql.Append("@idInquilino,");
            sql.Append("@idImovel,");
            sql.Append("@endereco,");
            sql.Append("@numero,");
            sql.Append("@complemento,");
            sql.Append("@bairro,");
            sql.Append("@cidade,");
            sql.Append("@uf,");
            sql.Append("@pais,");
            sql.Append("@principal,");
            sql.Append("@dataCadastro,");
            sql.Append("@dataAlteracao");
            sql.Append(")");

            SqlCommand parametro = new SqlCommand();
            parametro.Parameters.Add("idUsuario", SqlDbType.Int).Value = endereco.idUsuario;
            parametro.Parameters.Add("idInquilino", SqlDbType.Int).Value = endereco.idInquilino;
            parametro.Parameters.Add("idImovel", SqlDbType.Int).Value = endereco.idImovel;
            parametro.Parameters.Add("endereco", SqlDbType.VarChar).Value = endereco.endereco;
            parametro.Parameters.Add("numero", SqlDbType.VarChar).Value = endereco.numero;
            parametro.Parameters.Add("complemento", SqlDbType.VarChar).Value = endereco.complemento;
            parametro.Parameters.Add("bairro", SqlDbType.VarChar).Value = endereco.bairro;
            parametro.Parameters.Add("cidade", SqlDbType.VarChar).Value = endereco.cidade;
            parametro.Parameters.Add("uf", SqlDbType.VarChar).Value = endereco.uf;
            parametro.Parameters.Add("pais", SqlDbType.VarChar).Value = endereco.pais;
            parametro.Parameters.Add("principal", SqlDbType.Bit).Value = endereco.principal;
            parametro.Parameters.Add("dataCadastro", SqlDbType.DateTime).Value = endereco.dataCadastro;
            parametro.Parameters.Add("dataAlteracao", SqlDbType.DateTime).Value = endereco.dataAlteracao;

            ConexaoBanco conexao = new ConexaoBanco();
            int resultado = conexao.ConexaoSql(sql.ToString(), parametro).ExecuteNonQuery();

            return resultado;
        }

        #endregion

        #region Alterar

        public int AlterarEndereco(MapEndereco endereco)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Update [Sistema].[Endereco] set ");
            sql.Append("idUsuario = @idUsuario,");
            sql.Append("idInquilino = @idInquilino,");
            sql.Append("idImovel = @idImovel,");
            sql.Append("endereco = @endereco,");
            sql.Append("numero = @numero,");
            sql.Append("complemento = @complemento,");
            sql.Append("bairro = @bairro,");
            sql.Append("cidade = @cidade,");
            sql.Append("uf = @uf,");
            sql.Append("pais = @pais,");
            sql.Append("principal = @principal,");
            sql.Append("dataCadastro = @dataCadastro,");
            sql.Append("dataAlteracao = @dataAlteracao");
            sql.Append(" where ");
            sql.Append("id = @id");

            SqlCommand parametro = new SqlCommand();
            parametro.Parameters.Add("idUsuario", SqlDbType.Int).Value = endereco.idUsuario;
            parametro.Parameters.Add("idInquilino", SqlDbType.Int).Value = endereco.idInquilino;
            parametro.Parameters.Add("idImovel", SqlDbType.Int).Value = endereco.idImovel;
            parametro.Parameters.Add("endereco", SqlDbType.VarChar).Value = endereco.endereco;
            parametro.Parameters.Add("numero", SqlDbType.VarChar).Value = endereco.numero;
            parametro.Parameters.Add("complemento", SqlDbType.VarChar).Value = endereco.complemento;
            parametro.Parameters.Add("bairro", SqlDbType.VarChar).Value = endereco.bairro;
            parametro.Parameters.Add("cidade", SqlDbType.VarChar).Value = endereco.cidade;
            parametro.Parameters.Add("uf", SqlDbType.VarChar).Value = endereco.uf;
            parametro.Parameters.Add("pais", SqlDbType.VarChar).Value = endereco.pais;
            parametro.Parameters.Add("principal", SqlDbType.Bit).Value = endereco.principal;
            parametro.Parameters.Add("dataCadastro", SqlDbType.DateTime).Value = endereco.dataCadastro;
            parametro.Parameters.Add("dataAlteracao", SqlDbType.DateTime).Value = endereco.dataAlteracao;

            ConexaoBanco conexao = new ConexaoBanco();
            int resultado = conexao.ConexaoSql(sql.ToString(), parametro).ExecuteNonQuery();

            return resultado;
        }

        #endregion

        #region Excluir

        public int ExcluirEndereco(MapEndereco endereco)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Delete from [Sistema].[Endereco] where ");
            sql.Append("id = @id");

            SqlCommand parametro = new SqlCommand();
            parametro.Parameters.Add("id", SqlDbType.Int).Value = endereco.id;

            ConexaoBanco conexao = new ConexaoBanco();
            int resultado = conexao.ConexaoSql(sql.ToString(), parametro).ExecuteNonQuery();

            return resultado;
        }

        #endregion
    }
}