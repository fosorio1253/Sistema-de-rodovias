using Dapper;
using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DER.WebApp.Helper;

namespace DER.WebApp.Infra.DAO
{
    public class GestaoOcupacaoDocumentoDAO : BaseDAO<GestaoOcupacaoDocumento>
    {

        public GestaoOcupacaoDocumentoDAO(DerContext context) : base(context)
        {
        }

        public void ExcluirPorIdOcupacao(int idOcupacao)
        //-- Description:	Deleta um item No menu Documento.
        //PROC: [STP_DEL_GESTAO_OCUPACAO_DOCUMENTO]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_DEL_GESTAO_OCUPACAO_DOCUMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@idOcupacao", idOcupacao));
                        conn.Open();
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public GestaoOcupacaoDocumentoViewModel GetByArquivoOcupacaoId(int idOcupacao)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var gestao = new GestaoOcupacaoDocumentoViewModel();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_OCUPACAO_DOCUMENTO_ARQUIVO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@idOcupacao", idOcupacao));
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            gestao.Arquivo = result["Arquivo"].ToString() == null ? String.Empty : result["Arquivo"].ToString();
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

        public List<GestaoOcupacaoDocumentoViewModel> GetByOcupacaoId(int idOcupacao)
        //-- Description:	Busca os Documentos no menu Documentos pelo ID.
        //PROC: [STP_SEL_GESTAO_OCUPACAO_DOCUMENTO_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<GestaoOcupacaoDocumentoViewModel>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_OCUPACAO_DOCUMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@idOcupacao", idOcupacao));
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            //var Documento = result["Documento"].ToString();
                            //var AdicionadoPor = result["AdicionadoPor"].ToString();
                            //var CaminhoArquivo = result["CaminhoArquivo"].ToString();
                            DateTime? VariavelDateNula = null;

                            var gestao = new GestaoOcupacaoDocumentoViewModel();
                            gestao.Id = result["Id"] == null ? 0 : Convert.ToInt32(result["Id"]);
                            gestao.Documento = (result["Documento"] == null ? string.Empty : result["Documento"].ToString());
                            try
                            {
                                gestao.TipoDocumentoId = result["TipoDocumentoId"] == null ? 0 : int.Parse(result["TipoDocumentoId"].ToString());
                            } catch (Exception e)
                            {
                                gestao.TipoDocumentoId = 0;
                            }
                            
                            gestao.Arquivo = (result["Arquivo"] == null ? string.Empty : result["Arquivo"].ToString());
                            gestao.DataAdicionado = result["DataAdicionado"] != DBNull.Value ? Convert.ToDateTime(result["DataAdicionado"]) : VariavelDateNula;
                            gestao.AdicionadoPor = (result["AdicionadoPor"] == null ? string.Empty : result["AdicionadoPor"].ToString());
                            gestao.CaminhoArquivo = (result["CaminhoArquivo"] == null ? string.Empty : result["CaminhoArquivo"].ToString());

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

        public void Update(GestaoOcupacao domain)
        //-- Description:	Atualiza uma Ocupação
        //PROC: STP_UPD_GESTAO_OCUPACAO_DOCUMENTO
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_GESTAO_OCUPACAO_DOCUMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@interessadoId", domain.InteressadoId));
                        command.Parameters.Add(new SqlParameter("@regionalId", domain.RegionalId));
                        command.Parameters.Add(new SqlParameter("@numeroSPDOC", domain.NumeroSPDOC));
                        command.Parameters.Add(new SqlParameter("@numeroProcesso", domain.NumeroProcesso));
                        command.Parameters.Add(new SqlParameter("@origemSolicitacaolId", domain.OrigemSolicitacaolId));
                        command.Parameters.Add(new SqlParameter("@situacaoSolicitacaoId", domain.SituacaoSolicitacaoId));
                        command.Parameters.Add(new SqlParameter("@dataCadastro", domain.DataCadastro));
                        command.Parameters.Add(new SqlParameter("@residenciaConservacaoId", domain.ResidenciaConservacaoId));
                        command.Parameters.Add(new SqlParameter("@id", domain.Id));

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

        public void Inserir(GestaoOcupacaoDocumento domain)
        //-- Description:	Insere um novo Documento no Menu de Documentos.
        //PROC: [STP_INS_GESTAO_OCUPACAO_DOCUMENTO]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_GESTAO_OCUPACAO_DOCUMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@gestaoOcupacaoId", domain.GestaoOcupacaoId));
                        command.Parameters.Add(new SqlParameter("@documento", domain.Documento));
                        command.Parameters.Add(new SqlParameter("@arquivo", domain.Arquivo));
                        command.Parameters.Add(new SqlParameter("@dataAdicionado", domain.DataAdicionado));
                        command.Parameters.Add(new SqlParameter("@adicionadoPor", domain.AdicionadoPor));
                        command.Parameters.Add(new SqlParameter("@tipoDocumentoId", domain.TipoDocumentoId));

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
    }
}