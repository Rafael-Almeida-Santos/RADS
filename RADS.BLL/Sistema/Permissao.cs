using System;
using RADS.DAL;

namespace RADS.BLL
{
    public class Permissao
    {
        MapPermissao _dados = new MapPermissao();

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

        public int IdRotina
        {
            get { return _dados.idRotina; }
            set { _dados.idRotina = value; }
        }

        public bool Administrador
        {
            get { return _dados.administrador; }
            set { _dados.administrador = value; }
        }

        public bool Inserir1
        {
            get { return _dados.inserir; }
            set { _dados.inserir = value; }
        }

        public bool Editar
        {
            get { return _dados.editar; }
            set { _dados.editar = value; }
        }

        public bool Excluir1
        {
            get { return _dados.excluir; }
            set { _dados.excluir = value; }
        }

        public bool Acao
        {
            get { return _dados.acao; }
            set { _dados.acao = value; }
        }

        public bool Imprimir
        {
            get { return _dados.imprimir; }
            set { _dados.imprimir = value; }
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