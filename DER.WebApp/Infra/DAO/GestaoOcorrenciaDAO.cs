using Dapper;
using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.DTO;
using DER.WebApp.Helper;
using DER.WebApp.Infra.DAL;
using DER.WebApp.ViewModels.GestaoOcorrencias;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DER.WebApp.Infra.DAO
{
    public class GestaoOcorrenciaDAO : BaseDAO<GestaoOcorrencia>
    {
        Logger logger;

        public GestaoOcorrenciaDAO(DerContext context) : base(context)
        {
            logger = new Logger("Gestão Ocorrencia", context);
        }

        public List<ListaGestaoOcorrenciaDTO> ObtemListaGestaoOcorrencia(string UsuarioAtualizacao)
        //-- Description:	Busca uma lista de Gestão de Ocorrências
        //PROC: STP_SEL_GESTAO_OCORRENCIA_LISTA
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<ListaGestaoOcorrenciaDTO>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_OCORRENCIA_LISTA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@UsuarioAtualizacao", UsuarioAtualizacao));
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {                           
                            DateTime? VariavelDateNula = null;

                            var gestao = new ListaGestaoOcorrenciaDTO();
                            gestao.Id = result["Id"] is DBNull ? 0 : Convert.ToInt32(result["Id"]);
                            gestao.Interessado = (result["Interessado"] == null ? string.Empty : result["Interessado"].ToString());
                            gestao.InteressadoId = result["InteressadoId"] is DBNull ? 0 : Convert.ToInt32(result["InteressadoId"]);
                            gestao.CodigoOcorrencia = (result["CodigoOcorrencia"].ToString() == null ? String.Empty : result["CodigoOcorrencia"].ToString());
                            gestao.RegionalId = result["RegionalId"] is DBNull ? 0 : Convert.ToInt32(result["RegionalId"]);
                            gestao.ResidenciaConservacaoId = result["ResidenciaConservacaoId"] is DBNull ? 0 : Convert.ToInt32(result["ResidenciaConservacaoId"]);
                            gestao.RodoviaId = result["RodoviaId"] is DBNull ? 0 : Convert.ToInt32(result["RodoviaId"]);
                            gestao.LadoId = result["LadoId"] is DBNull ? 0 : Convert.ToInt32(result["LadoId"]);
                            gestao.TrechoId = result["TrechoId"] is DBNull ? 0 : Convert.ToInt32(result["TrechoId"]);
                            gestao.TipoOcupacaoId = result["TipoOcupacaoId"] is DBNull ? 0 : Convert.ToInt32(result["TipoOcupacaoId"]);
                            gestao.Documento = result["Documento"] is DBNull ? string.Empty : result["Documento"].ToString();
                            gestao.Titulo = result["Titulo"] is DBNull ? string.Empty : result["Titulo"].ToString();
                            gestao.Descricao = result["Descricao"] is DBNull ? string.Empty : result["Descricao"].ToString();
                            gestao.AssuntoId = result["AssuntoId"] is DBNull ? 0 : Convert.ToInt32(result["AssuntoId"]);
                            gestao.Observacao = result["Observacao"] is DBNull ? string.Empty : result["Observacao"].ToString();
                            gestao.UsuarioAtualizacao = result["UsuarioAtualizacao"] is DBNull ? string.Empty : result["UsuarioAtualizacao"].ToString();
                            gestao.StatusId = result["StatusId"] is DBNull ? 0 : Convert.ToInt32(result["StatusId"]);
                            gestao.SeveridadeId = result["SeveridadeId"] is DBNull ? 0 : Convert.ToInt32(result["SeveridadeId"]);
                            gestao.TipoOcupacao = (result["TipoOcupacao"] == null ? string.Empty : result["TipoOcupacao"].ToString());
                            gestao.Regional = (result["Regional"] == null ? string.Empty : result["Regional"].ToString());
                            gestao.Rodovia = (result["Rodovia"] == null ? string.Empty : result["Rodovia"].ToString());
                            gestao.DataCadastro = result["DataCadastro"] != DBNull.Value ? Convert.ToDateTime(result["DataCadastro"]) : VariavelDateNula;
                             
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

        public List<GestaoOcorrenciasViewModel> ObtemTodasOcorrencias(string UsuarioAtualizacao)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<GestaoOcorrenciasViewModel>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_OCORRENCIA_LISTA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@UsuarioAtualizacao", UsuarioAtualizacao));
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            DateTime? VariavelDateNula = null;

                            var gestao = new GestaoOcorrenciasViewModel();
                            gestao.Id = result["Id"] is DBNull ? 0 : Convert.ToInt32(result["Id"]);
                            gestao.Interessado = (result["Interessado"] == null ? string.Empty : result["Interessado"].ToString());
                            gestao.InteressadoId = result["InteressadoId"] is DBNull ? 0 : Convert.ToInt32(result["InteressadoId"]);
                            gestao.CodigoOcorrencia = (result["CodigoOcorrencia"].ToString() == null ? String.Empty : result["CodigoOcorrencia"].ToString());
                            gestao.RegionalId = result["RegionalId"] is DBNull ? 0 : Convert.ToInt32(result["RegionalId"]);
                            gestao.Latitude = result["Latitude"] is DBNull ? string.Empty : result["Latitude"].ToString();
                            gestao.Longitude = result["Longitude"] is DBNull ? string.Empty : result["Longitude"].ToString();
                            gestao.ResidenciaConservacaoId = result["ResidenciaConservacaoId"] is DBNull ? 0 : Convert.ToInt32(result["ResidenciaConservacaoId"]);
                            gestao.KmInicial = result["KmInicial"] is DBNull ? string.Empty : result["KmInicial"].ToString();
                            gestao.KmFinal = result["KmFinal"] is DBNull ? string.Empty : result["KmFinal"].ToString();
                            gestao.RodoviaId = result["RodoviaId"] is DBNull ? 0 : Convert.ToInt32(result["RodoviaId"]);
                            gestao.LadoId = result["LadoId"] is DBNull ? 0 : Convert.ToInt32(result["LadoId"]);
                            gestao.TrechoId = result["TrechoId"] is DBNull ? 0 : Convert.ToInt32(result["TrechoId"]);
                            gestao.TipoOcupacaoId = result["TipoOcupacaoId"] is DBNull ? 0 : Convert.ToInt32(result["TipoOcupacaoId"]);
                            gestao.Documento = result["Documento"] is DBNull ? string.Empty : result["Documento"].ToString();
                            gestao.Titulo = result["Titulo"] is DBNull ? string.Empty : result["Titulo"].ToString();
                            gestao.Descricao = result["Descricao"] is DBNull ? string.Empty : result["Descricao"].ToString();
                            gestao.AssuntoId = result["AssuntoId"] is DBNull ? 0 : Convert.ToInt32(result["AssuntoId"]);
                            gestao.Observacao = result["Observacao"] is DBNull ? string.Empty : result["Observacao"].ToString();
                            gestao.UsuarioAtualizacao = result["UsuarioAtualizacao"] is DBNull ? string.Empty : result["UsuarioAtualizacao"].ToString();
                            gestao.StatusId = result["StatusId"] is DBNull ? 0 : Convert.ToInt32(result["StatusId"]);
                            gestao.SeveridadeId = result["SeveridadeId"] is DBNull ? 0 : Convert.ToInt32(result["SeveridadeId"]);
                            gestao.TipoOcupacao = (result["TipoOcupacao"] == null ? string.Empty : result["TipoOcupacao"].ToString());
                            gestao.Regional = (result["Regional"] == null ? string.Empty : result["Regional"].ToString());
                            gestao.Rodovia = (result["Rodovia"] == null ? string.Empty : result["Rodovia"].ToString());
                            gestao.DataCadastro = result["DataCadastro"] != DBNull.Value ? Convert.ToDateTime(result["DataCadastro"]) : VariavelDateNula;

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

        public GestaoOcorrenciasViewModel GetById(int id)
        //-- Description:	Busca um ID de Gestão de Ocorrencias
        //PROC: STP_SEL_GESTAO_OCORRENCIA_ID
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var gestao = new GestaoOcorrenciasViewModel();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_OCORRENCIA_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@id", id));
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            DateTime? VariavelDateNula = null;

                            gestao.Id = (result["Id"]) == null ? 0 : Convert.ToInt32(result["Id"]);
                            //gestao.Id = Convert.ToInt32(result["Id"]);

                            gestao.InteressadoId = (result["InteressadoId"]) is DBNull ? 0 : Convert.ToInt32(result["InteressadoId"]);
                            gestao.Interessado = (result["Interessado"].ToString() == null ? String.Empty : result["Interessado"].ToString());
                            gestao.CodigoOcorrencia = (result["CodigoOcorrencia"].ToString() == null ? String.Empty : result["CodigoOcorrencia"].ToString());
                            gestao.Documento = (result["Documento"].ToString() == null ? String.Empty : result["Documento"].ToString());
                            gestao.TipoOcupacaoId = Convert.ToInt32(result["TipoOcupacaoId"]);
                            gestao.TrechoId = Convert.ToInt32(result["TrechoId"]);
                            gestao.RodoviaId = Convert.ToInt32(result["RodoviaId"]);
                            gestao.KmInicial = (result["KmInicial"].ToString() == null ? String.Empty : result["KmInicial"].ToString());
                            gestao.KmFinal = (result["KmFinal"].ToString() == null ? String.Empty : result["KmFinal"].ToString());
                            gestao.LadoId = Convert.ToInt32(result["LadoId"]);
                            gestao.ResidenciaConservacaoId = Convert.ToInt32(result["ResidenciaConservacaoId"]);
                            gestao.RegionalId = Convert.ToInt32(result["RegionalId"]);
                            gestao.Latitude = (result["Latitude"].ToString() == null ? String.Empty : result["Latitude"].ToString());
                            gestao.Longitude = (result["Longitude"].ToString() == null ? String.Empty : result["Longitude"].ToString());
                            gestao.Titulo = (result["Titulo"].ToString() == null ? String.Empty : result["Titulo"].ToString());
                            gestao.AssuntoId = Convert.ToInt32(result["AssuntoId"]);
                            gestao.SeveridadeId = Convert.ToInt32(result["SeveridadeId"]);
                            gestao.StatusId = Convert.ToInt32(result["StatusId"]);
                            gestao.Descricao = (result["Descricao"].ToString() == null ? String.Empty : result["Descricao"].ToString());
                            gestao.Observacao = (result["Observacao"].ToString() == null ? String.Empty : result["Observacao"].ToString());
                            gestao.UsuarioAtualizacao = (result["UsuarioAtualizacao"].ToString() == null ? String.Empty : result["UsuarioAtualizacao"].ToString());
                            gestao.DataCadastro = result["DataCadastro"] != DBNull.Value ? Convert.ToDateTime(result["DataCadastro"]) : VariavelDateNula;
                            gestao.DataAtualizacao = result["DataAtualizacao"] != DBNull.Value ? Convert.ToDateTime(result["DataAtualizacao"]) : VariavelDateNula;

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

        public void Update(GestaoOcorrencia domain)
        //-- Description:	Atualiza uma Ocorrência
        //PROC: STP_UPD_GESTAO_OCORRENCIA
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.Id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_GESTAO_OCORRENCIA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@interessadoId", domain.InteressadoId));
                        command.Parameters.Add(new SqlParameter("@documento", domain.Documento));
                        command.Parameters.Add(new SqlParameter("@ocupacaoId", domain.OcupacaoId));
                        command.Parameters.Add(new SqlParameter("@tipoOcupacaoId", domain.TipoOcupacaoId));
                        command.Parameters.Add(new SqlParameter("@trechoId", domain.TrechoId));
                        command.Parameters.Add(new SqlParameter("@rodoviaId", domain.RodoviaId));
                        command.Parameters.Add(new SqlParameter("@kmInicial", domain.KmInicial));
                        command.Parameters.Add(new SqlParameter("@kmFinal", domain.KmFinal));
                        command.Parameters.Add(new SqlParameter("@ladoId", domain.LadoId));
                        command.Parameters.Add(new SqlParameter("@residenciaConservacaoId", domain.ResidenciaConservacaoId));
                        command.Parameters.Add(new SqlParameter("@regionalId", domain.RegionalId));
                        command.Parameters.Add(new SqlParameter("@latitude", domain.Latitude));
                        command.Parameters.Add(new SqlParameter("@longitude", domain.Longitude));
                        command.Parameters.Add(new SqlParameter("@titulo", domain.Titulo));
                        command.Parameters.Add(new SqlParameter("@assuntoId", domain.AssuntoId));
                        command.Parameters.Add(new SqlParameter("@severidadeId", domain.SeveridadeId));
                        command.Parameters.Add(new SqlParameter("@statusId", domain.StatusId));
                        command.Parameters.Add(new SqlParameter("@descricao", domain.Descricao));
                        command.Parameters.Add(new SqlParameter("@observacao", domain.Observacao));
                        command.Parameters.Add(new SqlParameter("@usuarioAtualizacao", domain.UsuarioAtualizacao));
                        command.Parameters.Add(new SqlParameter("@dataAtualizacao", domain.DataAtualizacao = DateTime.Now));
                        command.Parameters.Add(new SqlParameter("@oco_id", domain.Id));

                        var result = command.ExecuteNonQuery();

                        conn.Close();
                        var newValue = GetById(domain.Id);
                        if (!newValue.Equals(oldValue))
                            logger.salvarLog(TipoAlteracao.Edicao, domain.Id.ToString(), logger.serializer.Serialize(oldValue), logger.serializer.Serialize(newValue));
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Inserir(GestaoOcorrencia domain)
        //-- Description:	Insere uma nova Ocupação
        //PROC>  STP_INS_GESTAO_OCORRENCIA
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_GESTAO_OCORRENCIA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@codigoOcorrencia", domain.CodigoOcorrencia));
                        command.Parameters.Add(new SqlParameter("@interessadoId", domain.InteressadoId));
                        command.Parameters.Add(new SqlParameter("@documento", domain.Documento));
                        command.Parameters.Add(new SqlParameter("@ocupacaoId", domain.OcupacaoId));
                        command.Parameters.Add(new SqlParameter("@tipoOcupacaoId", domain.TipoOcupacaoId));
                        command.Parameters.Add(new SqlParameter("@trechoId", domain.TrechoId));
                        command.Parameters.Add(new SqlParameter("@rodoviaId", domain.RodoviaId));
                        command.Parameters.Add(new SqlParameter("@kmInicial", domain.KmInicial));
                        command.Parameters.Add(new SqlParameter("@kmFinal", domain.KmFinal));
                        command.Parameters.Add(new SqlParameter("@ladoId", domain.LadoId));
                        command.Parameters.Add(new SqlParameter("@residenciaConservacaoId", domain.ResidenciaConservacaoId));
                        command.Parameters.Add(new SqlParameter("@regionalId", domain.RegionalId));
                        command.Parameters.Add(new SqlParameter("@latitude", domain.Latitude));
                        command.Parameters.Add(new SqlParameter("@longitude", domain.Longitude));
                        command.Parameters.Add(new SqlParameter("@titulo", domain.Titulo));
                        command.Parameters.Add(new SqlParameter("@assuntoId", domain.AssuntoId));
                        command.Parameters.Add(new SqlParameter("@severidadeId", domain.SeveridadeId));
                        command.Parameters.Add(new SqlParameter("@statusId", domain.StatusId));
                        command.Parameters.Add(new SqlParameter("@descricao", domain.Descricao));
                        command.Parameters.Add(new SqlParameter("@observacao", domain.Observacao));
                        command.Parameters.Add(new SqlParameter("@usuarioAtualizacao", domain.UsuarioAtualizacao));
                        command.Parameters.Add(new SqlParameter("@dataCadastro", domain.DataCadastro = DateTime.Now));
                        command.Parameters.Add(new SqlParameter("@dataAtualizacao", domain.DataAtualizacao = DateTime.Now));
                        command.Parameters.Add(new SqlParameter("@ativo", domain.Ativo));

                        var result = command.ExecuteScalar();
                        var id = Convert.ToInt32(result);
                        conn.Close();
                        var newValue = GetById(id);
                        logger.salvarLog(TipoAlteracao.Criacao, id.ToString(), "", logger.serializer.Serialize(newValue));

                        return id;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(int id)
        //Deleta uma Ocorrência
        //PROC: [STP_DEL_GESTAO_OCORRENCIAS]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(id);
            logger.salvarLog(TipoAlteracao.Exclusao, id.ToString(), logger.serializer.Serialize(oldValue), "");
            
            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_GESTAO_OCORRENCIAS", conn))
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