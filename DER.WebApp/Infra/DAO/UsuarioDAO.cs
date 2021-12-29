using DER.WebApp.Common.Helper;
using DER.WebApp.Domain.Business;
using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Models;
using DER.WebApp.Models.Enum;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.Validadores;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;

namespace DER.WebApp.Infra.DAO
{
    public class UsuarioDAO : BaseDAO<Usuario>
    {
        PermissaoBLL permissaoBLL;
        public UsuarioDAO(DerContext derContext) : base(derContext)
        {
            permissaoBLL = new PermissaoBLL();
        }
        public UsuarioViewModel ValidarLogin(UsuarioViewModel paramUsuario)
        //Descrição: Busca um usuário pelo LOGIN.
        //PROC: STP_SEL_USUARIO_VALIDA_LOGIN
        {


            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            //var usuario = new Usuario();

            try
            {

                var usuario = db.Usuario
                    .FirstOrDefault(x =>
                        x.Login == paramUsuario.usu_login &&
                        x.StatusAprovacaoId == (int)StatusAprovacaoEnum.Aprovado &&
                        x.Ativo == true &&
                        x.Excluido == false);

                //using (var conn = new SqlConnection(connectionString))
                //{
                //    using (var command = new SqlCommand("STP_SEL_USUARIO_VALIDA_LOGIN", conn))
                //    {
                //        command.CommandType = CommandType.StoredProcedure;
                //        conn.Open();

                //        command.Parameters.Add(new SqlParameter("@usu_login", paramUsuario.usu_login));
                //        SqlDataReader result = command.ExecuteReader();

                //        while (result.Read())
                //        {
                //            DateTime? VariavelDateNula = null;

                //            usuario.Id = result["USU_ID"] is DBNull ? 0 : Convert.ToInt32(result["USU_ID"]);
                //            usuario.Ativo = Convert.ToBoolean(result["USU_ATIVO"]);
                //            usuario.Externo = Convert.ToBoolean(result["USU_EXTERNO"]);
                //            usuario.Nome = (result["USU_NOME"].ToString() == null ? String.Empty : result["USU_NOME"].ToString());
                //            usuario.Cargo = (result["USU_CARGO"].ToString() == null ? String.Empty : result["USU_CARGO"].ToString());
                //            usuario.Login = (result["USU_LOGIN"].ToString() == null ? String.Empty : result["USU_LOGIN"].ToString());
                //            usuario.Senha = (result["USU_SENHA"].ToString() == null ? String.Empty : result["USU_SENHA"].ToString());
                //            usuario.Email = (result["USU_EMAIL"].ToString() == null ? String.Empty : result["USU_EMAIL"].ToString());
                //            usuario.RegionalId = result["DMV_ID_REGIONAL"] is DBNull ? 0 : Convert.ToInt32(result["DMV_ID_REGIONAL"]);
                //            usuario.DDD = (result["USU_DDD"].ToString() == null ? String.Empty : result["USU_DDD"].ToString());
                //            usuario.TelefoneRamal = (result["USU_TELEFONERAMAL"].ToString() == null ? String.Empty : result["USU_TELEFONERAMAL"].ToString());
                //            usuario.DataCriacao = result["USU_DATACRIACAO"] != DBNull.Value ? Convert.ToDateTime(result["USU_DATACRIACAO"]) : VariavelDateNula;
                //            usuario.StatusAprovacaoId = result["STA_ID"] is DBNull ? 0 : Convert.ToInt32(result["STA_ID"]);
                //        }
                //        conn.Close();
                //    }
                //}
                if (usuario != null)
                {
                    if (Criptografar.Encrypt(paramUsuario.usu_senha) == usuario.Senha)
                    {
                        paramUsuario.Permissoes = new List<string>();

                        foreach (var grupo in usuario.Grupos)
                        {
                            var permissoes = permissaoBLL.ObtemListaPermissoes(grupo.Perfil.Permissoes.ToList());
                            foreach (var permissao in permissoes)
                            {
                                paramUsuario.Permissoes.AddRange(obtemListaPermissoes(permissao));
                            }
                        }

                        paramUsuario.usu_nome = usuario.Nome;
                        paramUsuario.usu_id = usuario.Id;
                        return paramUsuario;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UsuarioInternoViewModel GetByLogin(string Login)
        //-- Description:	Busca um Usuario pelo ID
        //PROC: STP_SEL_USUARIO_VALIDA_LOGIN
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var usuario = new UsuarioInternoViewModel();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_USUARIO_VALIDA_LOGIN", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@usu_login", Login));
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            DateTime? VariavelDateNula = null;

                            usuario.Id = result["USU_ID"] is DBNull ? 0 : Convert.ToInt32(result["USU_ID"]);
                            usuario.Ativo = Convert.ToBoolean(result["USU_ATIVO"]);
                            usuario.Externo = Convert.ToBoolean(result["USU_EXTERNO"]);
                            usuario.Nome = (result["USU_NOME"].ToString() == null ? String.Empty : result["USU_NOME"].ToString());
                            usuario.Cargo = (result["USU_CARGO"].ToString() == null ? String.Empty : result["USU_CARGO"].ToString());
                            usuario.Login = (result["USU_LOGIN"].ToString() == null ? String.Empty : result["USU_LOGIN"].ToString());
                            usuario.Senha = (result["USU_SENHA"].ToString() == null ? String.Empty : result["USU_SENHA"].ToString());
                            usuario.Email = (result["USU_EMAIL"].ToString() == null ? String.Empty : result["USU_EMAIL"].ToString());
                            usuario.RegionalId = result["DMV_ID_REGIONAL"] is DBNull ? 0 : Convert.ToInt32(result["DMV_ID_REGIONAL"]);
                            usuario.DDD = (result["USU_DDD"].ToString() == null ? String.Empty : result["USU_DDD"].ToString());
                            usuario.TelefoneRamal = (result["USU_TELEFONERAMAL"].ToString() == null ? String.Empty : result["USU_TELEFONERAMAL"].ToString());
                            usuario.DataCriacao = result["USU_DATACRIACAO"] != DBNull.Value ? Convert.ToDateTime(result["USU_DATACRIACAO"]) : VariavelDateNula;
                            usuario.StatusAprovacaoId = result["STA_ID"] is DBNull ? 0 : Convert.ToInt32(result["STA_ID"]);
                        }
                        conn.Close();
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> obtemListaPermissoes(ListaPermissaoViewModel permissao)
        {
            var retorno = new List<string>() { permissao.Codigo };
            if (permissao.PermissaoFilho != null)
            {
                foreach (var permissaoFilho in permissao.PermissaoFilho)
                {
                    permissaoFilho.Codigo = permissao.Codigo + permissaoFilho.Codigo;
                    retorno.AddRange(obtemListaPermissoes(permissaoFilho));
                }
            }
            return retorno;
        }

        public IQueryable<Usuario> GetByEmail(string email)
        {
            var retorno = db.Usuario.Where(x => x.Email == email);
            return retorno;
        }

        public UsuarioInternoViewModel GetByDocumento(string Documento)
        //-- Description:	Busca um usuário pelo NUMERO DO DOCUMENTO.
        //PROC: STP_SEL_USUARIO_DOCUMENTO
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var usuario = new UsuarioInternoViewModel();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_USUARIO_DOCUMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@documento", Documento));
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            DateTime? VariavelDateNula = null;

                            usuario.Id = result["USU_ID"] is DBNull ? 0 : Convert.ToInt32(result["USU_ID"]);
                            usuario.Ativo = Convert.ToBoolean(result["USU_ATIVO"]);
                            usuario.Externo = Convert.ToBoolean(result["USU_EXTERNO"]);
                            usuario.Nome = (result["USU_NOME"].ToString() == null ? String.Empty : result["USU_NOME"].ToString());
                            usuario.Cargo = (result["USU_CARGO"].ToString() == null ? String.Empty : result["USU_CARGO"].ToString());
                            usuario.Login = (result["USU_LOGIN"].ToString() == null ? String.Empty : result["USU_LOGIN"].ToString());
                            usuario.Senha = (result["USU_SENHA"].ToString() == null ? String.Empty : result["USU_SENHA"].ToString());
                            usuario.Email = (result["USU_EMAIL"].ToString() == null ? String.Empty : result["USU_EMAIL"].ToString());
                            usuario.RegionalId = result["DMV_ID_REGIONAL"] is DBNull ? 0 : Convert.ToInt32(result["DMV_ID_REGIONAL"]);
                            usuario.DDD = (result["USU_DDD"].ToString() == null ? String.Empty : result["USU_DDD"].ToString());
                            usuario.TelefoneRamal = (result["USU_TELEFONERAMAL"].ToString() == null ? String.Empty : result["USU_TELEFONERAMAL"].ToString());
                            usuario.DataCriacao = result["USU_DATACRIACAO"] != DBNull.Value ? Convert.ToDateTime(result["USU_DATACRIACAO"]) : VariavelDateNula;
                            usuario.StatusAprovacaoId = result["STA_ID"] is DBNull ? 0 : Convert.ToInt32(result["STA_ID"]);
                        }
                        conn.Close();
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool AlterarSenha(int idUsuario, string senhaAtual, string senhaNova)
        {
            var usuario = db.Usuario.Find(idUsuario);
            if (senhaAtual != senhaNova && usuario.Senha == Criptografar.Encrypt(senhaAtual))
            {
                usuario.Senha = Criptografar.Encrypt(senhaNova);
                usuario.Ativo = true;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }




        public UsuarioValidatorViewModel VerificaJaCadastrado(Usuario usuario)
        {
            var usuarioVerificador = db.Usuario.Where(x => (x.CPF == usuario.CPF || x.Email == usuario.Email || x.Login == usuario.Login) && x.Id != usuario.Id);

            return new UsuarioValidatorViewModel()
            {
                anyCPF = usuarioVerificador.Any(x => x.CPF == usuario.CPF),
                anyEmail = usuarioVerificador.Any(x => x.Email == usuario.Email),
                anyLogin = usuarioVerificador.Any(x => x.Login == usuario.Login),
                valid = !usuarioVerificador.Any()
            };
        }

        public UsuarioValidatorViewModel VerificaEnvioDocumentos(Usuario usuario)
        {
            if (usuario.RegionalId != null)
                return new UsuarioValidatorViewModel { valid = true };

            return new UsuarioValidatorViewModel()
            {
                anyDocumento = (usuario.Id == 00 && string.IsNullOrEmpty(usuario.DocumentoFoto)) ? false : true,
                anyProcuracao = (usuario.Id == 00 && string.IsNullOrEmpty(usuario.Procuracao)) ? false : true,
                valid = ((usuario.Id == 00 && string.IsNullOrEmpty(usuario.DocumentoFoto)) || (usuario.Id == 00 && string.IsNullOrEmpty(usuario.Procuracao))) ? false : true
            };
        }

        public bool AlterarSenha(AlteraSenhaViewModel alteraSenha)
        {
            var alterarSenha = VerificaToken(alteraSenha.token);
            if (alterarSenha != null)
            {
                var usuario = alterarSenha.Usuario;
                usuario.Senha = Criptografar.Encrypt(alteraSenha.senha);
                alterarSenha.JaUtilizado = true;
                usuario.Ativo = true;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }


        public object AlterarSenhaComValidacao(AlteraSenhaViewModel alteraSenha)
        {
            var usuario = VerificaToken(alteraSenha.token);

            if (usuario != null)
            {
                var user = usuario.Usuario;
                var senhaAntiga = Criptografar.Decrypt(user.Senha);
                if (alteraSenha.senha == senhaAntiga)
                {
                    return new { status = false, mensagem = "Está senha já foi utilizada!" };
                }


                if (alteraSenha.senha.Length < 5)
                {
                    return new { status = false, mensagem = "Sua senha deve ter pelo menos 5 (cinco) caracteres alfanurnericos!" };
                }

                if (alteraSenha.senha != alteraSenha.senhaRepeticao)
                {
                    return new { status = false, mensagem = "Senhas não coincidem" };
                }

                // bool existeCaracterEspecial = Regex.IsMatch(alteraSenha.senha, (@"[!""#$%&'()*+,-./:;?@[\\\]_`{|}~]"));
                bool existeCaracterEspecial = Regex.IsMatch(alteraSenha.senha, (@"[!""&'()+,./:;?[\\\]`{|}~]"));
                if (existeCaracterEspecial)
                {
                    return new { status = false, mensagem = @"Seguintes caracteres especiais não podem ser utilizados: [!""&'()+,./:;?[\\\]`{|}~]" };
                }

                var usuarioAlterado = usuario.Usuario;
                usuarioAlterado.Senha = Criptografar.Encrypt(alteraSenha.senha);
                usuario.JaUtilizado = true;
                usuarioAlterado.Ativo = true;
                db.SaveChanges();

                return new { status = true, mensagem = "" };
            }
            else
            {
                return new { status = false, mensagem = "Usuário não encontrado!" };
            }


        }


        public AlterarSenha VerificaToken(string token)
        {
            var retorno = db.AlteraSenha.Where(x => x.Id == new Guid(token) && x.JaUtilizado == false).FirstOrDefault();
            return retorno.DataExpiracao > DateTime.Now ? retorno : null;
        }


        public bool VerificaSenhaDiferenteAnterior(string token, string senha)
        {
            var retorno = db.AlteraSenha.Where(x => x.Id == new Guid(token)).FirstOrDefault();

            if (retorno != null)
            {
                var usuario = db.Usuario.Where(x => x.Id == retorno.UsuarioId).FirstOrDefault();

                if (usuario != null)
                {
                    var senhaAntiga = Criptografar.Decrypt(usuario.Senha);

                    if (senhaAntiga != senha)
                        return true;
                }
            }

            return false;
        }


        public Usuario ObtemPeloToken(string token)
        {
            return db.Usuario.Where(x => x.AlteracaoGuid == new Guid(token) && x.StatusAprovacaoId == (int)StatusAprovacaoEnum.Reprovado).FirstOrDefault();
        }

        public void solicitaAlteracaoSenha(AlterarSenha alterarSenha)
        {
            db.AlteraSenha.Add(alterarSenha);
            db.SaveChanges();
        }

        public Usuario ObtemUsuarioExterno(int id)
        {
            var idArquivos = new List<int>();

            var arquivosId = db.Arquivo
                    .Where(x => x.usu_id == id)
                    .GroupBy(x => x.TipoArquivo)
                    .Select(x => new { id = x.Max(p => p.Id) }).ToList();

            foreach (var item in arquivosId)
            {
                idArquivos.Add(item.id);
            }

            var arquivos = db.Arquivo.Where(x => idArquivos.Contains(x.Id)).ToList();

            var usuario = db.Usuario.Find(id);

            foreach (var item in arquivos)
            {
                if (item.TipoArquivo == TipoArquivoEnum.Foto)
                {
                    usuario.DocumentoFoto = item.ArquivoNome;
                }
                else
                {
                    usuario.Procuracao = item.ArquivoNome;
                }
            }

            return usuario;
        }
    }
}