using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.DTO;
using DER.WebApp.Infra.DAL;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using DER.WebApp.ViewModels.GestaoInteressados;
using DER.WebApp.Common.Helper;
using System;
using DER.WebApp.Helper;
using DER.WebApp.ViewModels.GestaoOcupacoes;

namespace DER.WebApp.Infra.DAO
{
    public class GestaoInteressadoDAO : BaseDAO<GestaoInteressado>
    {
        
        private GestaoInteressadoTipoDeConcessaoDAO gestaoInteressadoTipoDeConcessaoDAO;

        public GestaoInteressadoDAO(DerContext context) : base(context)
        {
            
            gestaoInteressadoTipoDeConcessaoDAO = new GestaoInteressadoTipoDeConcessaoDAO(context);
        }

        public List<RetornoInteressadoOcupacaoViewModel> GetInteressadoByParams(InteressadoOcupacaoParansDTO viewModel, string UsuarioAtualizacao)
        //Retorna uma lista específica de Interessados.
        //PROC: STP_SEL_GESTAO_INTERESSADO_PARAMS
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<RetornoInteressadoOcupacaoViewModel>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_INTERESSADO_PARAMS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                                               
                        command.Parameters.Add(new SqlParameter("@interessado", viewModel.Interessado));
                        command.Parameters.Add(new SqlParameter("@documento", viewModel.Documento));
                        command.Parameters.Add(new SqlParameter("@idMunicipio", viewModel.IdMunicipio));
                        command.Parameters.Add(new SqlParameter("@idEstado", viewModel.IdEstado));
                        command.Parameters.Add(new SqlParameter("@idTipo", viewModel.IdTipo));
                        command.Parameters.Add(new SqlParameter("@idNatureza", viewModel.IdNatureza));
                        command.Parameters.Add(new SqlParameter("@UsuarioAtualizacao", UsuarioAtualizacao));


                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            var gestao = new RetornoInteressadoOcupacaoViewModel();
                            gestao.IdInteressado = result["IdInteressado"] is DBNull ? 0 : Convert.ToInt32(result["IdInteressado"]);
                            gestao.Interessado = (result["Interessado"] == null ? string.Empty : result["Interessado"].ToString());
                            gestao.Documento = result["Documento"] is DBNull ? string.Empty : result["Documento"].ToString();
                            gestao.Tipo = result["Tipo"] is DBNull ? string.Empty : result["Tipo"].ToString();
                            gestao.Natureza = result["Natureza"] is DBNull ? string.Empty : result["Natureza"].ToString();
                            gestao.TipoConcessoes = gestaoInteressadoTipoDeConcessaoDAO.GetByGestaoId(gestao.IdInteressado);
                            
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
        }

        public List<ListaGestaoInteressadoDTO> GetListGestaoInteressados(int UsuarioPerfilId, int UsuarioEmpresaId, int UsuarioId)
        //Retorna a Lista Completa de Interessados
        //PROC: STP_SEL_GESTAO_INTERESSADO_LISTA
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<ListaGestaoInteressadoDTO>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_INTERESSADO_LISTA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@usuarioIdSessao", PerfilUsuario.UsuarioId));
                        command.Parameters.Add(new SqlParameter("@perfilAdmin", PerfilUsuario.UsuarioPerfilId));
                        command.Parameters.Add(new SqlParameter("@usuarioEmpresaIdSessao", PerfilUsuario.UsuarioEmpresaId));                        

                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            DateTime? VariavelDateNula = null;

                            var gestao = new ListaGestaoInteressadoDTO();
                            gestao.Id = result["Id"] is DBNull ? 0 : Convert.ToInt32(result["Id"]);
                            gestao.Interessado = (result["Interessado"] == null ? string.Empty : result["Interessado"].ToString());
                            gestao.Documento = result["Documento"] is DBNull ? string.Empty : result["Documento"].ToString();
                            gestao.Telefone = result["Telefone"] is DBNull ? string.Empty : result["Telefone"].ToString();
                            gestao.Tipo = result["Tipo"] is DBNull ? string.Empty : result["Tipo"].ToString();
                            gestao.Natureza = result["NaturezaJuridica"] is DBNull ? string.Empty : result["NaturezaJuridica"].ToString();
                            gestao.Status = result["StatusNome"] is DBNull ? string.Empty : result["StatusNome"].ToString();
                            gestao.Validade = result["ValidoAte"] != DBNull.Value ? Convert.ToDateTime(result["ValidoAte"]) : VariavelDateNula;
                            gestao.Estado = result["Estado"] is DBNull ? string.Empty : result["Estado"].ToString();
                            gestao.Municipio = (result["Municipio"] == null ? string.Empty : result["Municipio"].ToString());
                            gestao.DataCadastro = result["DataCadastro"] != DBNull.Value ? Convert.ToDateTime(result["DataCadastro"]) : VariavelDateNula;
                            gestao.UsuarioId = result["UsuarioId"] is DBNull ? 0 : Convert.ToInt32(result["UsuarioId"]);

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
        }

        public void Update(GestaoInteressado domain)
        //-- Description:	Atualiza um novo Interessado.
        //PROC: STP_UPD_GESTAO_INTERESSADO
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.Id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_GESTAO_INTERESSADO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@numeroSPDOC", domain.NumeroSPDOC));
                        command.Parameters.Add(new SqlParameter("@statusSPDOC", domain.StatusSPDOC));
                        command.Parameters.Add(new SqlParameter("@nome", domain.Nome));
                        command.Parameters.Add(new SqlParameter("@naturezaJuridicaId", domain.NaturezaJuridicaId));
                        command.Parameters.Add(new SqlParameter("@documento", domain.Documento));
                        command.Parameters.Add(new SqlParameter("@matrizOuFilial", domain.MatrizOuFilial));
                        command.Parameters.Add(new SqlParameter("@validoAte", domain.ValidoAte != null ? domain.ValidoAte : null));
                        command.Parameters.Add(new SqlParameter("@nomeFantasia", domain.NomeFantasia));
                        command.Parameters.Add(new SqlParameter("@statusAprovacaoId", domain.StatusAprovacaoId));
                        command.Parameters.Add(new SqlParameter("@tipoDeInteressadoId", domain.TipoDeInteressadoId));
                        command.Parameters.Add(new SqlParameter("@telefone", domain.Telefone));
                        command.Parameters.Add(new SqlParameter("@int_id", domain.Id));
                        //command.Parameters.Add(new SqlParameter("@RequisicaoSite", true));


                        var result = command.ExecuteNonQuery();

                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Inserir(GestaoInteressado domain, int UsuarioId)
        //-- Description:	Insere um novo Interessado.
        //[STP_INS_GESTAO_INTERESSADO]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_GESTAO_INTERESSADO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@numeroSPDOC", String.IsNullOrEmpty(domain.NumeroSPDOC) ? "" : domain.NumeroSPDOC));
                        command.Parameters.Add(new SqlParameter("@naturezaJuridicaId", domain.NaturezaJuridicaId));
                        command.Parameters.Add(new SqlParameter("@tipoDeInteressadoId", domain.TipoDeInteressadoId));
                        command.Parameters.Add(new SqlParameter("@nome", domain.Nome));
                        command.Parameters.Add(new SqlParameter("@telefone", domain.Telefone));
                        command.Parameters.Add(new SqlParameter("@documento", domain.Documento));
                        command.Parameters.Add(new SqlParameter("@matrizOuFilial", domain.MatrizOuFilial));
                        command.Parameters.Add(new SqlParameter("@nomeFantasia", domain.NomeFantasia));
                        command.Parameters.Add(new SqlParameter("@statusSPDOC", String.IsNullOrEmpty(domain.StatusSPDOC) ? "" : domain.StatusSPDOC));
                        command.Parameters.Add(new SqlParameter("@usuarioAtualizacao", domain.UsuarioAtualizacao));
                        command.Parameters.Add(new SqlParameter("@usuarioId", UsuarioId));
                        command.Parameters.Add(new SqlParameter("@statusAprovacaoId", domain.StatusAprovacaoId != 0 ? domain.StatusAprovacaoId : 1));
                        command.Parameters.Add(new SqlParameter("@dataCadastro", domain.DataCadastro));

                        var result = command.ExecuteScalar();

                        conn.Close();

                        var id = Convert.ToInt32(result);
                        var value = GetById(id);
                        
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public string ConsultarValidade(int id)
        //-- Description:	Busca um interessado pelo ID.
        //PROC: [STP_SEL_GESTAO_INTERESSADO_VALIDADE_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var gestao = new GestaoInteressadosViewModel();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_INTERESSADO_VALIDADE_ID", conn))
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

        public GestaoInteressadosViewModel GetById(int id)
        //-- Description:	Busca um interessado pelo ID.
        //PROC: [STP_SEL_GESTAO_INTERESSADO_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var gestao = new GestaoInteressadosViewModel();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_INTERESSADO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@id", id));
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            DateTime? VariavelDateNula = null;

                            gestao.Id = (result["Id"]) == null ? 0 : Convert.ToInt32(result["Id"]);
                            gestao.NumeroSPDOC = (result["NumeroSPDOC"].ToString() == null ? String.Empty : result["NumeroSPDOC"].ToString());
                            gestao.NaturezaJuridicaId = Convert.ToInt32(result["NaturezaJuridicaId"]);
                            gestao.StatusId = Convert.ToInt32(result["StatusId"]);
                            gestao.TipoInteressadoId = Convert.ToInt32(result["TipoInteressadoId"]);
                            gestao.Nome = (result["Nome"].ToString() == null ? String.Empty : result["Nome"].ToString());
                            gestao.Documento = (result["Documento"].ToString() == null ? String.Empty : result["Documento"].ToString());
                            gestao.TipoEmpresaId = Convert.ToInt32(result["TipoEmpresaId"]);
                            gestao.NomeFantasia = (result["NomeFantasia"].ToString() == null ? String.Empty : result["NomeFantasia"].ToString());
                            gestao.Validade = (result["Validade"].ToString() == null ? String.Empty : result["Validade"].ToString());
                            gestao.StatusSPDOC = (result["StatusSPDOC"].ToString() == null ? String.Empty : result["StatusSPDOC"].ToString());
                            gestao.Telefone = (result["Telefone"].ToString() == null ? String.Empty : result["Telefone"].ToString());

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

        public void Excluir(int id)
        //-- Description:	Deleta um Interessado
        //PROC: [STP_DEL_GESTAO_INTERESSADO]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(id);
            

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_GESTAO_INTERESSADO", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id", id));
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    conn.Close();
                }
            }
        }
    }
}