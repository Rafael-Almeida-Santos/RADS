using System.Collections.Generic;
using RADS.DAL;

namespace RADS.BLL
{
    public class ModuloSistema
    {
        #region Usuario

        #region Selecionar

        public IList<Usuario> ObterTodosUsuarios()
        {
            IList<MapUsuario> dados = new SqlServerUsuario().ObterTodosUsuarios();

            IList<Usuario> lista = new List<Usuario>();

            if (dados != null || dados.Count > 0)
            {
                foreach (var linha in dados)
                {
                    Usuario dado = new Usuario();
                    dado.Id = linha.id;
                    dado.Nome = linha.nome;
                    dado.Sobrenome = linha.sobrenome;
                    dado.Cpf = linha.cpf;
                    dado.DataNascimento = linha.dataNascimento;
                    dado.Email = linha.email;
                    dado.Telefone = linha.telefone;
                    dado.Celular = linha.celular;
                    dado.Status = linha.status;
                    dado.DataCadastro = linha.dataCadastro;
                    dado.DataAlteracao = linha.dataAlteracao;

                    lista.Add(dado);
                }
            }
            else
            {
                lista = null;
            }

            return lista;
        }

        public Usuario ObterUsuario(int id)
        {
            MapUsuario dados = new SqlServerUsuario().ObterUsuario(id);

            Usuario dado = new Usuario();

            if (dados != null)
            {
                dado.Id = dados.id;
                dado.Nome = dados.nome;
                dado.Sobrenome = dados.sobrenome;
                dado.Cpf = dados.cpf;
                dado.DataNascimento = dados.dataNascimento;
                dado.Email = dados.email;
                dado.Telefone = dados.telefone;
                dado.Celular = dados.celular;
                dado.Status = dados.status;
                dado.DataCadastro = dados.dataCadastro;
                dado.DataAlteracao = dados.dataAlteracao;
            }
            else
            {
                dado = null;
            }

            return dado;
        }

        public Usuario ObterUsuario(string cpf)
        {
            MapUsuario dados = new SqlServerUsuario().ObterUsuario(cpf);

            Usuario dado = new Usuario();

            if (dados != null)
            {
                dado.Id = dados.id;
                dado.Nome = dados.nome;
                dado.Sobrenome = dados.sobrenome;
                dado.Cpf = dados.cpf;
                dado.DataNascimento = dados.dataNascimento;
                dado.Email = dados.email;
                dado.Telefone = dados.telefone;
                dado.Celular = dados.celular;
                dado.Status = dados.status;
                dado.DataCadastro = dados.dataCadastro;
                dado.DataAlteracao = dados.dataAlteracao;
            }
            else
            {
                dado = null;
            }

            return dado;
        }

        #endregion

        #region Inserir, Alterar e Excluir

        public int SalvarUsuario(Usuario usuario)
        {
            int resultado = 0;
            MapUsuario dado = new MapUsuario();
            dado.id = usuario.Id;
            dado.nome = usuario.Nome;
            dado.sobrenome = usuario.Sobrenome;
            dado.cpf = usuario.Cpf;
            dado.dataNascimento = usuario.DataNascimento;
            dado.email = usuario.Email;
            dado.telefone = usuario.Telefone;
            dado.celular = usuario.Celular;
            dado.status = usuario.Status;
            dado.dataCadastro = usuario.DataCadastro;
            dado.dataAlteracao = usuario.DataAlteracao;

            if (usuario.Inserir)
            {
                resultado = new SqlServerUsuario().InserirUsuario(dado);
            }
            else if (usuario.Alterar)
            {
                resultado = new SqlServerUsuario().AlterarUsuario(dado);
            }
            else if (usuario.Excluir)
            {
                resultado = new SqlServerUsuario().ExcluirUsuario(dado);
            }

            return resultado;
        }

        #endregion

        #endregion

        #region Senha

        #region Selecionar

        public IList<Senha> ObterTodasSenhas()
        {
            IList<MapSenha> dados = new SqlServerSenha().ObterTodasSenhas();

            IList<Senha> lista = new List<Senha>();

            if (dados != null || dados.Count > 0)
            {
                foreach (var linha in dados)
                {
                    Senha dado = new Senha();
                    dado.Id = linha.id;
                    dado.IdUsuario = linha.idUsuario;
                    dado.Senha1 = linha.senha;
                    dado.Alterar1 = linha.alterar;
                    dado.DataCadastro = linha.dataCadastro;
                    dado.DataAlteracao = linha.dataAlteracao;

                    lista.Add(dado);
                }
            }
            else
            {
                lista = null;
            }

            return lista;
        }

        public Senha ObterSenha(int id)
        {
            MapSenha dados = new SqlServerSenha().ObterSenha(id);

            Senha dado = new Senha();

            if (dados != null)
            {
                dado.Id = dados.id;
                dado.IdUsuario = dados.idUsuario;
                dado.Senha1 = dados.senha;
                dado.Alterar1 = dados.alterar;
                dado.DataCadastro = dados.dataCadastro;
                dado.DataAlteracao = dados.dataAlteracao;
            }
            else
            {
                dado = null;
            }

            return dado;
        }

        public Senha ObterSenha(int idUsuario, string senha)
        {
            MapSenha dados = new SqlServerSenha().ObterSenha(idUsuario, senha);

            Senha dado = new Senha();

            if (dados != null)
            {
                dado.Id = dados.id;
                dado.IdUsuario = dados.idUsuario;
                dado.Senha1 = dados.senha;
                dado.Alterar1 = dados.alterar;
                dado.DataCadastro = dados.dataCadastro;
                dado.DataAlteracao = dados.dataAlteracao;
            }
            else
            {
                dado = null;
            }

            return dado;
        }

        #endregion

        #region Inserir, Alterar e Excluir

        public int SalvarSenha(Senha senha)
        {
            int resultado = 0;
            MapSenha dado = new MapSenha();
            dado.id = senha.Id;
            dado.idUsuario = senha.IdUsuario;
            dado.senha = senha.Senha1;
            dado.alterar = senha.Alterar1;
            dado.dataCadastro = senha.DataCadastro;
            dado.dataAlteracao = senha.DataAlteracao;

            if (senha.Inserir)
            {
                resultado = new SqlServerSenha().InserirSenha(dado);
            }
            else if (senha.Alterar)
            {
                resultado = new SqlServerSenha().AlterarSenha(dado);
            }
            else if (senha.Excluir)
            {
                resultado = new SqlServerSenha().ExcluirSenha(dado);
            }

            return resultado;
        }

        #endregion

        #endregion

        #region Permissao

        #region Selecionar

        public IList<Permissao> ObterTodasPermissoes()
        {
            IList<MapPermissao> dados = new SqlServerPermissao().ObterTodasPermissoes();

            IList<Permissao> lista = new List<Permissao>();

            if (dados != null || dados.Count > 0)
            {
                foreach (var linha in dados)
                {
                    Permissao dado = new Permissao();
                    dado.Id = linha.id;
                    dado.IdUsuario = linha.idUsuario;
                    dado.IdRotina = linha.idRotina;
                    dado.Administrador = linha.administrador;
                    dado.Inserir = linha.inserir;
                    dado.Editar = linha.editar;
                    dado.Excluir = linha.excluir;
                    dado.Acao = linha.acao;
                    dado.Imprimir = linha.imprimir;
                    dado.DataCadastro = linha.dataCadastro;
                    dado.DataAlteracao = linha.dataAlteracao;

                    lista.Add(dado);
                }
            }
            else
            {
                lista = null;
            }

            return lista;
        }

        public Permissao ObterPermissao(int id)
        {
            MapPermissao dados = new SqlServerPermissao().ObterPermissao(id);

            Permissao dado = new Permissao();

            if (dados != null)
            {
                dado.Id = dados.id;
                dado.IdUsuario = dados.idUsuario;
                dado.IdRotina = dados.idRotina;
                dado.Administrador = dados.administrador;
                dado.Inserir = dados.inserir;
                dado.Editar = dados.editar;
                dado.Excluir = dados.excluir;
                dado.Acao = dados.acao;
                dado.Imprimir = dados.imprimir;
                dado.DataCadastro = dados.dataCadastro;
                dado.DataAlteracao = dados.dataAlteracao;
            }
            else
            {
                dado = null;
            }

            return dado;
        }

        #endregion

        #region Inserir, Alterar e Excluir

        public int SalvarPermissao(Permissao permissao)
        {
            int resultado = 0;
            MapPermissao dado = new MapPermissao();
            dado.id = permissao.Id;
            dado.idUsuario = permissao.IdUsuario;
            dado.idRotina = permissao.IdRotina;
            dado.administrador = permissao.Administrador;
            dado.inserir = permissao.Inserir;
            dado.editar = permissao.Editar;
            dado.excluir = permissao.Excluir;
            dado.acao = permissao.Acao;
            dado.imprimir = permissao.Imprimir;
            dado.dataCadastro = permissao.DataCadastro;
            dado.dataAlteracao = permissao.DataAlteracao;

            if (permissao.Inserir)
            {
                resultado = new SqlServerPermissao().InserirPermissao(dado);
            }
            else if (permissao.Alterar)
            {
                resultado = new SqlServerPermissao().AlterarPermissao(dado);
            }
            else if (permissao.Excluir)
            {
                resultado = new SqlServerPermissao().ExcluirPermissao(dado);
            }

            return resultado;
        }

        #endregion

        #endregion
    }
}