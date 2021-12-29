using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.GestaoInteressados;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DER.WebApp.Infra.DAO
{
    public class PerfilDAO : BaseDAO<Perfil>
    {
        public PerfilDAO(DerContext context) : base(context)
        {

        }
        public Perfil ObtemPorNome(string nome, int idPerfil)
        //-- Description:	Busca um Perfil pelo Nome ou Nome e ID.
        //PROC: STP_SEL_PERFIS_NOME_ID
        {
            return (idPerfil == 0) ? db.Perfil.FirstOrDefault(x => x.Nome == nome) : db.Perfil.FirstOrDefault(x => x.Nome == nome && x.Id != idPerfil);
        }

        public PerfilAcessoViewModel ObtemPerfilUsuario(int UsuarioSessaoId)
        //-- Description:	Busca O Perfil do Usuario Logado
        //PROC: STP_SEL_PERFIL_USUARIO_SESSAO
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var gestao = new PerfilAcessoViewModel();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_PERFIL_USUARIO_SESSAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@usuarioSessaoId", UsuarioSessaoId));
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            gestao.PerfilUsuario = (result["PerfilUsuario"].ToString() == null ? String.Empty : result["PerfilUsuario"].ToString());
                            gestao.UsuarioEmpresaId = result["UsuarioEmpresaId"] is DBNull ? 0 : Convert.ToInt32(result["UsuarioEmpresaId"]);
                            gestao.UsuarioPerfilId = result["UsuarioPerfilId"] is DBNull ? 0 : Convert.ToInt32(result["UsuarioPerfilId"]);
                        }
                        conn.Close();
                    }
                }
                return gestao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ConsultarValidadeCredenciamentoLogin(int id)
        //-- Description:	Busca a validade de credenciamento de um interessado pelo ID do usuario.
        //PROC: [STP_SEL_GESTAO_INTERESSADO_VALIDADE_LOGIN_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var gestao = new GestaoInteressadosViewModel();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_INTERESSADO_VALIDADE_LOGIN_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@id", id));
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            gestao.ExisteValidade = (result["ExisteValidade"].ToString() == null ? String.Empty : result["ExisteValidade"].ToString());
                        }
                        conn.Close();
                    }
                }
                return gestao.ExisteValidade;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}