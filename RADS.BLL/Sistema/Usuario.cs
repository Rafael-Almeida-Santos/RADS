using System;
using RADS.DAL;

namespace RADS.BLL
{
    public class Usuario
    {
        MapUsuario _dados = new MapUsuario();

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

        public string Nome
        {
            get { return _dados.nome; }
            set { _dados.nome = value; }
        }

        public string Sobrenome
        {
            get { return _dados.sobrenome; }
            set { _dados.sobrenome = value; }
        }

        public string Cpf
        {
            get { return _dados.cpf; }
            set { _dados.cpf = value; }
        }

        public DateTime DataNascimento
        {
            get { return _dados.dataNascimento; }
            set { _dados.dataNascimento = value; }
        }

        public string Email
        {
            get { return _dados.email; }
            set { _dados.email = value; }
        }

        public string Telefone
        {
            get { return _dados.telefone; }
            set { _dados.telefone = value; }
        }

        public string Celular
        {
            get { return _dados.celular; }
            set { _dados.celular = value; }
        }

        public bool Status
        {
            get { return _dados.status; }
            set { _dados.status = value; }
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