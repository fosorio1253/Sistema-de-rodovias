using Dapper;
using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.ViewModels.GestaoInteressados;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DER.WebApp.Helper;
using System;

namespace DER.WebApp.Infra.DAO
{
    public class GestaoInteressadoContatoDAO : BaseDAO<GestaoInteressadoContato>
    {
       
        public GestaoInteressadoContatoDAO(DerContext context) : base(context)
        {
         
        }

        public void ExcluirPorIdGestao(int idGestao)
        //    -- Description:	Deleta um ENDERECO em Gestão de Interessado.
        //PROC: [STP_DEL_GESTAO_INTERESSADO_ENDERECO]
        {
            var oldValue = GetByGestaoId(idGestao);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            const string sql = @"delete from tab_gestao_interessado_contato where int_id = @idGestao";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sql, new { idGestao = idGestao }, commandType: CommandType.Text).ToList();
                
            }
        }
        public List<UsuarioContatoConsultaViewModel> GetByParans(GestaoContatoViewModel viewModel)
        //-- Description:	Busca uma lista específica de Contatos na Gestão de Interessados
        //PROC: [STP_SEL_GESTAO_INTERESSADO_CONTATO_PARAMS]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<UsuarioContatoConsultaViewModel>();

            const string sql = @"select
	                                usu.usu_id as UsuarioId,
	                                usu.usu_nome as Nome,
	                                usu.usu_cargo as Cargo,
	                                usu.usu_email as Email
                                from tab_usuarios usu
                                left join tab_usuario_empresa emp on (emp.usu_id = usu.usu_id)
                                where usu.usu_excluido = 0
                                    and (@nome is null or (@nome is not null and usu.usu_nome = @nome))
                                    and (@login is null or (@login is not null and usu.usu_login = @login))
                                    and (@cargo is null or (@cargo is not null and usu.usu_cargo = @cargo))
                                    and (@email is null or (@email is not null and usu.usu_email = @email))
                                    and (@estado = 0 or (@estado > 0 and usu.dmv_id_regional = @estado))
                                    and (@empresa = 0 or (@empresa > 0 and emp.emp_id = @empresa))";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                retorno = conexao.Query<UsuarioContatoConsultaViewModel>(sql, new
                {
                    nome = viewModel.Nome,
                    login = viewModel.Login,
                    cargo = viewModel.Cargo,
                    email = viewModel.Email,
                    estado = viewModel.EstadoId,
                    empresa = viewModel.EmpresaId
                }, commandType: CommandType.Text).ToList();
            }

            return retorno;
        }

        public List<GestaoContatoViewModel> GetByGestaoId(int idGestao)
        //-- Description:	Busca um contato em Gestão de Interessados.
        //[STP_SEL_GESTAO_INTERESSADO_CONTATO_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<GestaoContatoViewModel>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_INTERESSADO_CONTATO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@idGestao", idGestao));

                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            var gestao = new GestaoContatoViewModel();
                            gestao.UsuarioId = result["UsuarioId"] is DBNull ? 0 : Convert.ToInt32(result["UsuarioId"]);
                            gestao.Login = (result["Login"] == null ? string.Empty : result["Login"].ToString());
                            gestao.Cargo = result["Cargo"] is DBNull ? string.Empty : result["Cargo"].ToString();
                            gestao.Email = result["Email"] is DBNull ? string.Empty : result["Email"].ToString();
                            gestao.Nome = result["Nome"] is DBNull ? string.Empty : result["Nome"].ToString();
                            gestao.Telefone = result["Telefone"] is DBNull ? string.Empty : result["Telefone"].ToString();
                            gestao.DDD = result["DDD"] is DBNull ? string.Empty : result["DDD"].ToString();

                            retorno.Add(gestao);
                        }
                        conn.Close();
                    }
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //const string sql = @"select
            //                        usu.usu_id as UsuarioId,
            //                        usu.usu_login as Login,
            //                        usu.usu_cargo as Cargo,
            //                        usu.usu_email as Email,
            //                        usu.usu_nome as Nome,
            //                        usu.usu_telefoneRamal as Telefone,
            //                        usu.usu_ddd as DDD
            //                    FROM tab_gestao_interessado_contato cont
            //                    INNER JOIN tab_usuarios usu on (cont.usu_id = usu.usu_id)
            //                    where int_id = @idGestao";

            //using (SqlConnection db = new SqlConnection(connectionString))
            //{
            //    retorno = db.Query<GestaoContatoViewModel>(sql, new { idGestao = idGestao }, commandType: CommandType.Text).ToList();
            //}

            //return retorno;
        }

        public void Inserir(GestaoInteressadoContato domain)
        //-- Description:	Insere um novo contato em Gestão de Interessados.
        //[STP_INS_GESTAO_INTERESSADO_CONTATO]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            //try
            //{
            //    using (var conn = new SqlConnection(connectionString))
            //    {
            //        using (var command = new SqlCommand("STP_INS_GESTAO_INTERESSADO", conn))
            //        {
            //            command.CommandType = CommandType.StoredProcedure;
            //            conn.Open();

            //            command.Parameters.Add(new SqlParameter("@numeroSPDOC", String.IsNullOrEmpty(domain.NumeroSPDOC) ? "" : domain.NumeroSPDOC));
            //            command.Parameters.Add(new SqlParameter("@naturezaJuridicaId", domain.NaturezaJuridicaId));
            //            command.Parameters.Add(new SqlParameter("@tipoDeInteressadoId", domain.TipoDeInteressadoId));
            //            command.Parameters.Add(new SqlParameter("@nome", domain.Nome));
            //            command.Parameters.Add(new SqlParameter("@telefone", domain.Telefone));
            //            command.Parameters.Add(new SqlParameter("@documento", domain.Documento));
            //            command.Parameters.Add(new SqlParameter("@matrizOuFilial", domain.MatrizOuFilial));
            //            command.Parameters.Add(new SqlParameter("@nomeFantasia", domain.NomeFantasia));
            //            command.Parameters.Add(new SqlParameter("@validoAte", domain.ValidoAte != null ? domain.ValidoAte : DateTime.Now));
            //            command.Parameters.Add(new SqlParameter("@statusSPDOC", .IsNullOrEmpty(domain.StatusSPDOC) ? "" : domain.StatusSPDOC));
            //            command.Parameters.Add(new SqlParameter("@usuarioAtualizStringacao", domain.UsuarioAtualizacao));
            //            command.Parameters.Add(new SqlParameter("@usuarioId", UsuarioId));
            //            command.Parameters.Add(new SqlParameter("@statusAprovacaoId", domain.StatusAprovacaoId != 0 ? domain.StatusAprovacaoId : 1));
            //            command.Parameters.Add(new SqlParameter("@dataCadastro", domain.DataCadastro));

            //            var result = command.ExecuteScalar();

            //            conn.Close();

            //            var id = Convert.ToInt32(result);
            //            var value = GetById(id);
            //            return Convert.ToInt32(result);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}

            string sqlUpdate = @"INSERT INTO tab_gestao_interessado_contato
                                VALUES( @gestaoInteressadoId,
                                        @principal,
                                        @usuarioId)";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sqlUpdate, new
                {
                    gestaoInteressadoId = domain.GestaoInteressadoId,
                    principal = domain.Principal,
                    usuarioId = domain.UsuarioId
                }, commandType: CommandType.Text);
            }
            
        }
    }
}