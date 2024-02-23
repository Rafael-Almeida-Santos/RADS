using System;
using RADS.DAL;

namespace RADS.BLL
{
    public class Endereco
    {
        MapEndereco _dados = new MapEndereco();

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

        public int IdInquilino
        {
            get { return _dados.idInquilino; }
            set { _dados.idInquilino = value; }
        }

        public int IdImovel
        {
            get { return _dados.idImovel; }
            set { _dados.idImovel = value; }
        }

        public string Endereco1
        {
            get { return _dados.endereco; }
            set { _dados.endereco = value; }
        }

        public string Numero
        {
            get { return _dados.numero; }
            set { _dados.numero = value; }
        }

        public string Complemento
        {
            get { return _dados.complemento; }
            set { _dados.complemento = value; }
        }

        public string Bairro
        {
            get { return _dados.bairro; }
            set { _dados.bairro = value; }
        }

        public string Cidade
        {
            get { return _dados.cidade; }
            set { _dados.cidade = value; }
        }

        public string Uf
        {
            get { return _dados.uf; }
            set { _dados.uf = value; }
        }

        public string Pais
        {
            get { return _dados.pais; }
            set { _dados.pais = value; }
        }

        public bool Principal
        {
            get { return _dados.principal; }
            set { _dados.principal = value; }
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