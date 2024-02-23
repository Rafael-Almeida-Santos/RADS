using System;

namespace RADS.DAL
{
    public class MapUsuario
    {
        public int id;
        public string nome;
        public string sobrenome;
        public string cpf;
        public DateTime dataNascimento;
        public string email;
        public string telefone;
        public string celular;
        public bool status;
        public DateTime dataCadastro;
        public DateTime dataAlteracao;
    }

    public class MapSenha
    {
        public int id;
        public int idUsuario;
        public string senha;
        public bool alterar;
        public DateTime dataCadastro;
        public DateTime dataAlteracao;
    }

    public class MapPermissao
    {
        public int id;
        public int idUsuario;
        public int idRotina;
        public bool administrador;
        public bool inserir;
        public bool editar;
        public bool excluir;
        public bool acao;
        public bool imprimir;
        public DateTime dataCadastro;
        public DateTime dataAlteracao;
    }

    public class MapEndereco
    {
        public int id;
        public int idUsuario;
        public int idInquilino;
        public int idImovel;
        public string endereco;
        public string numero;
        public string complemento;
        public string bairro;
        public string cidade;
        public string uf;
        public string pais;
        public bool principal;
        public DateTime dataCadastro;
        public DateTime dataAlteracao;
    }
}