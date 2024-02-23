using System;
using RADS.DAL;

namespace RADS.BLL
{
    public class Senha
    {
        MapSenha _dados = new MapSenha();

        public bool Inserir
        {
            get; set;
        }

        public bool Alterar
        {
            get; set;
        }

        public bool Excluir
        {
            get; set;
        }

        #region Propriedades

        public int Id
        {
            get { return _dados.id; }
            set { _dados.id = value; }
        }

        public int IdUsuario
        {
            get { return _dados.idUsuario; }
            set { _dados.idUsuario = value; }
        }

        public string Senha1
        {
            get { return _dados.senha; }
            set { _dados.senha = value; }
        }

        public bool Alterar1
        {
            get { return _dados.alterar; }
            set { _dados.alterar = value; }
        }

        public DateTime DataCadastro
        {
            get { return _dados.dataCadastro; }
            set { _dados.dataCadastro = value; }
        }

        public DateTime DataAlteracao
        {
            get { return _dados.dataAlteracao; }
            set { _dados.dataAlteracao = value; }
        }

        #endregion

        #region SubClasse
        #endregion

        #region Propriedades Calculadas
        #endregion
    }
}