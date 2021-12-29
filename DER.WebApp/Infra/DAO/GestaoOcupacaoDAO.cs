using Dapper;
using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.DTO;
using DER.WebApp.Infra.DAL;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DER.WebApp.Helper;
using DER.WebApp.Common.Helper;
using DER.WebApp.Models.Enum;

namespace DER.WebApp.Infra.DAO
{
    public class GestaoOcupacaoDAO : BaseDAO<GestaoOcupacao>
    {
        private Logger _logger;
        public GestaoOcupacaoDAO(DerContext context) : base(context)
        {
            _logger = new Logger("Gestão Ocupação", context);
        }
        public List<GestaoOcupacaoWorkflowViewModel> GetListaOcupacaoWorkflow(int workflowId)
        //-- Description:	Busca uma lista de Gestão de Ocupações Workflow
        //PROC: STP_SEL_GESTAO_OCUPACAO_WORKFLOW_LISTA
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<GestaoOcupacaoWorkflowViewModel>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_OCUPACAO_WORKFLOW_LISTA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@workflowId", workflowId));
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            var gestao = new GestaoOcupacaoWorkflowViewModel();
                            gestao.OcupacaoId = result["OcupacaoId"] == null ? 0 : Convert.ToInt32(result["OcupacaoId"]);
                            gestao.Sequencia = result["Sequencia"] == null ? 0 : Convert.ToInt32(result["Sequencia"]);
                            gestao.Ativo = result["Ativo"] == null ? false : Convert.ToBoolean(result["Ativo"]);
                            gestao.WorkflowId = result["WorkflowId"] == null ? 0 : Convert.ToInt32(result["WorkflowId"]);
                            gestao.SituacaoValor = (result["SituacaoValor"] == null ? string.Empty : result["SituacaoValor"].ToString());
                            gestao.OrigemId = result["OrigemId"] == null ? 0 : Convert.ToInt32(result["OrigemId"]);
                            gestao.OrigemValor = (result["OrigemValor"] == null ? string.Empty : result["OrigemValor"].ToString());
                            gestao.DataCadastro = result["DataCadastro"] == null ? DateTime.MinValue : Convert.ToDateTime(result["DataCadastro"]);
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
        public List<ListaGestaoOcupacaoDTO> GetListGestaoOcupacao(int UsuarioPerfilId, int UsuarioEmpresaIdSessao, int UsuarioIdSessao)
        //-- Description:	Busca uma lista de Gestão de Ocupações
        //PROC: STP_SEL_GESTAO_OCUPACAO_LISTA
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<ListaGestaoOcupacaoDTO>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_OCUPACAO_LISTA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@usuarioIdSessao", UsuarioIdSessao));
                        command.Parameters.Add(new SqlParameter("@perfilAdmin", UsuarioPerfilId));
                        command.Parameters.Add(new SqlParameter("@usuarioEmpresaIdSessao", UsuarioEmpresaIdSessao));
                        SqlDataReader result = command.ExecuteReader();                                              
                        
                        while (result.Read())
                        {
                            var idRegional = result["IdRegional"].ToString();
                            var IdOrigem = result["IdOrigem"].ToString();

                            var gestao = new ListaGestaoOcupacaoDTO();
                            gestao.Id = result["Id"] == null ? 0 : Convert.ToInt32(result["Id"]);
                            gestao.NumeroProcesso = (result["NumeroProcesso"] == null ? string.Empty : result["NumeroProcesso"].ToString());
                            gestao.DataImplantacao = (result["DataImplantacao"] == null ? string.Empty : result["DataImplantacao"].ToString());
                            gestao.NumeroSPDOC = (result["NumeroSPDOC"] == null ? string.Empty : result["NumeroSPDOC"].ToString());
                            gestao.DataSolicitacao = (result["DataSolicitacao"] == null ? Convert.ToDateTime(result["DataSolicitacao"]) : Convert.ToDateTime(result["DataSolicitacao"]));
                            gestao.Interessado = (result["Interessado"] == null ? string.Empty : result["Interessado"].ToString());

                            if (result["IdRegional"] != null && !string.IsNullOrWhiteSpace(idRegional) ) 
                            {
                                gestao.IdRegional = Convert.ToInt32(result["IdRegional"]);
                            }
                            else
                            {
                                gestao.IdRegional = 0;
                            }


                            gestao.Regional = (result["Regional"] == null ? string.Empty : result["Regional"].ToString());



                            if (result["IdOrigem"] != null && !string.IsNullOrWhiteSpace(IdOrigem))
                            {
                                gestao.IdOrigem = Convert.ToInt32(result["IdOrigem"]);
                            }
                            else
                            {
                                gestao.IdOrigem = 0;
                            }

                            //gestao.IdOrigem = result["IdOrigem"] == null ? 0 : Convert.ToInt32(result["IdOrigem"]);
                            gestao.OrigemSolicitacao = (result["OrigemSolicitacao"] == null ? string.Empty : result["OrigemSolicitacao"].ToString());
                            gestao.SituacaoSolicitacao = (result["SituacaoSolicitacao"] == null ? string.Empty : result["SituacaoSolicitacao"].ToString());
                            gestao.SituacaoOcupacao = (result["SituacaoOcupacao"] == null ? string.Empty : result["SituacaoOcupacao"].ToString());                            
                            //gestao.UsuarioId = result["UsuarioId"] is DBNull ? 0 : Convert.ToInt32(result["UsuarioId"]);

                            gestao.WorkflowId= result["WorkflowId"] == null ? 0 : Convert.ToInt32(result["WorkflowId"]);
                            gestao.Sequencia= result["Sequencia"] == null ? 0 : Convert.ToInt32(result["Sequencia"]);

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

        public GestaoOcupacaoViewModel GetById(int id)
        //-- Description:	Busca um ID de Gestão de Ocupações
        //PROC: STP_SEL_GESTAO_OCUPACAO_ID
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var gestao = new GestaoOcupacaoViewModel();          

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_OCUPACAO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@id", id));
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            DateTime? VariavelDateNula = null;
                            
                            gestao.Id =                         result["Id"]                        is DBNull ? 0                 : Convert.ToInt32(result["Id"]);
                            gestao.InteressadoId =              result["InteressadoId"]             is DBNull ? 0                 : Convert.ToInt32(result["InteressadoId"]);
                            gestao.Interessado =                result["Interessado"]               is DBNull ? string.Empty      : result["Interessado"].ToString();
                            gestao.RegionalId =                 result["RegionalId"]                is DBNull ? 0                 : Convert.ToInt32(result["RegionalId"]);
                            gestao.NumeroSPDOC =                result["NumeroSPDOC"]               is DBNull ? string.Empty      : result["NumeroSPDOC"].ToString(); 
                            gestao.NumeroProcesso =             result["NumeroProcesso"]            is DBNull ? string.Empty      : result["NumeroProcesso"].ToString();
                            gestao.DataImplantacao =            result["DataImplantacao"]           is DBNull ? VariavelDateNula  : Convert.ToDateTime(result["DataImplantacao"]);
                            gestao.OrigemSolicitacaoId =        result["OrigemSolicitacaoId"]       is DBNull ? 0                 : Convert.ToInt32(result["OrigemSolicitacaoId"]);
                            gestao.SituacaoSolicitacaoId =      result["SituacaoSolicitacaoId"]     is DBNull ? 0                 : Convert.ToInt32(result["SituacaoSolicitacaoId"]);
                            gestao.SituacaoOcupacaoId =         result["SituacaoOcupacaoId"]        is DBNull ? 0                 : Convert.ToInt32(result["SituacaoOcupacaoId"]);
                            gestao.DataCadastro =               result["DataCadastro"]              is DBNull ? VariavelDateNula  : Convert.ToDateTime(result["DataCadastro"]); 
                            gestao.ResidenciaConservacaoId =    result["ResidenciaConservacaoId"]   is DBNull ? 0                 : Convert.ToInt32(result["ResidenciaConservacaoId"]);
                            gestao.InteressadoEmail =           result["InteressadoEmail"]          is DBNull ? string.Empty      : result["InteressadoEmail"].ToString();
                            gestao.WorkflowId =                 result["WorkflowId"]                is DBNull ? 0                 : Convert.ToInt32(result["WorkflowId"]);
                            gestao.Sequencia =                  result["Sequencia"]                 is DBNull ? 0                 : Convert.ToInt32(result["Sequencia"]);
                            //gestao.Ativo =                      result["Ativo"]                     is DBNull ? false             : Convert.ToBoolean(result["Ativo"]);

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
        public void UpdateParaInativo(int idOcupacao)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            const string sql = @"update TAB_GESTAO_OCUPACAO 
                                set [ocu_ativo] = 0  
                                where 
                                ocu_id = @idOcupacao";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var retorno = db.Execute(sql, new { idOcupacao = idOcupacao });
            }
        }
        public void Update(GestaoOcupacao domain)
        //-- Description:	Atualiza uma Ocupação
        //PROC: STP_UPD_GESTAO_OCUPACAO
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.Id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_GESTAO_OCUPACAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@interessadoId", domain.InteressadoId));
                        command.Parameters.Add(new SqlParameter("@regionalId", domain.RegionalId));
                        command.Parameters.Add(new SqlParameter("@numeroSPDOC", domain.NumeroSPDOC));
                        command.Parameters.Add(new SqlParameter("@numeroProcesso", domain.NumeroProcesso));
                        if (domain.DataImplantacao != null)
                        {
                            command.Parameters.Add(new SqlParameter("@dataImplantacao", domain.DataImplantacao));
                        }
                        else
                        {
                            command.Parameters.Add(new SqlParameter("@dataImplantacao", DBNull.Value));
                        }                        
                        command.Parameters.Add(new SqlParameter("@origemSolicitacaolId", domain.OrigemSolicitacaolId));
                        command.Parameters.Add(new SqlParameter("@situacaoSolicitacaoId", domain.SituacaoSolicitacaoId));
                        command.Parameters.Add(new SqlParameter("@situacaoOcupacaoId", domain.SituacaoOcupacaoId));
                        command.Parameters.Add(new SqlParameter("@dataCadastro", domain.DataCadastro));
                        command.Parameters.Add(new SqlParameter("@residenciaConservacaoId", domain.ResidenciaConservacaoId));
                        command.Parameters.Add(new SqlParameter("@id", domain.Id));

                        var result = command.ExecuteNonQuery();

                        conn.Close();
                    }
                }
                var value = GetById(domain.Id);
                if(!value.Equals(oldValue))
                    _logger.salvarLog(TipoAlteracao.Edicao,domain.Id.ToString(),_logger.serializer.Serialize(oldValue)  , _logger.serializer.Serialize(value));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Inserir(GestaoOcupacao domain, string UsuarioAtualizacao, int UsuarioId)
        //-- Description:	Insere uma nova Ocupação
        //PROC>  STP_INS_GESTAO_OCUPACAO
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_GESTAO_OCUPACAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@interessadoId", domain.InteressadoId));
                        command.Parameters.Add(new SqlParameter("@regionalId", domain.RegionalId));
                        command.Parameters.Add(new SqlParameter("@numeroSPDOC", domain.NumeroSPDOC == null ? String.Empty : domain.NumeroSPDOC));                        
                        command.Parameters.Add(new SqlParameter("@numeroProcesso", domain.NumeroProcesso == null ? String.Empty : domain.NumeroProcesso));
                        if (domain.DataImplantacao != null)
                        {
                            command.Parameters.Add(new SqlParameter("@dataImplantacao", domain.DataImplantacao));
                        } 
                        else
                        {
                            command.Parameters.Add(new SqlParameter("@dataImplantacao", DBNull.Value));
                        }
                        command.Parameters.Add(new SqlParameter("@origemSolicitacaolId", domain.OrigemSolicitacaolId));
                        command.Parameters.Add(new SqlParameter("@situacaoSolicitacaoId", domain.SituacaoSolicitacaoId));
                        command.Parameters.Add(new SqlParameter("@situacaoOcupacaoId", domain.SituacaoOcupacaoId));
                        command.Parameters.Add(new SqlParameter("@dataCadastro", DateTime.Now));
                        command.Parameters.Add(new SqlParameter("@ocu_ativo", domain.Ativo));
                        command.Parameters.Add(new SqlParameter("@residencialId", domain.ResidenciaConservacaoId));
                        command.Parameters.Add(new SqlParameter("@usuarioAtualizacao", UsuarioAtualizacao));
                        command.Parameters.Add(new SqlParameter("@usuarioId", UsuarioId));
                        command.Parameters.Add(new SqlParameter("@workflowId", domain.WorkflowId));
                        command.Parameters.Add(new SqlParameter("@sequencia", domain.Sequencia));


                        var result = command.ExecuteScalar();

                        conn.Close();

                        var id = Convert.ToInt32(result); 
                        var value = GetById(id);
                        _logger.salvarLog(TipoAlteracao.Criacao,id.ToString(),""  , _logger.serializer.Serialize(value));
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(int id)
        //Deleta uma Ocupação
        //PROC: STP_DEL_GESTAO_OCUPACAO
        {
            var oldValue = GetById(id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_DEL_GESTAO_OCUPACAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@id", id));
                        conn.Open();
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                        conn.Close();

                        _logger.salvarLog(TipoAlteracao.Exclusao, id.ToString(), _logger.serializer.Serialize(oldValue), "");

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}