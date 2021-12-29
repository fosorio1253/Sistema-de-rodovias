using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.DTO;
using DER.WebApp.Infra.DAL;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using DER.WebApp.Helper;
using DER.WebApp.ViewModels.ProjetosMelhorias;
using System;

namespace DER.WebApp.Infra.DAO
{
    public class ProjetosMelhoriasInformacoesRelevantesDAO : BaseDAO<ProjetosMelhoriasInformacoesRelevantes>
    {
        private Logger _logger;
        public ProjetosMelhoriasInformacoesRelevantesDAO(DerContext context) : base(context)
        {
            _logger = new Logger("Projetos Melhorias Informações Relevantes", context);
        }
        public void ExcluirPorIdProjetos(int idProjetos)
        //-- Description:	Deleta uma informação relevante de um Projeto de Melhoria.
        //PROC: [STP_DEL_PROJETOS_MELHORIAS_INFORMACOES_RELEVANTES]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_PROJETOS_MELHORIAS_INFORMACOES_RELEVANTES", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@idProjetos", idProjetos));
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    conn.Close();
                    _logger.salvarLog(TipoAlteracao.Exclusao, idProjetos.ToString(), "", "");
                }
            }
        }

        public List<ProjetosMelhoriasInformacoesRelevantesViewModel> GetByInformacoesRelevantesId(int projetosMelhoriasId)
        //-- Description:	Busca um ID de Informações Relevantes dentro de Projeto de Melhorias
        //PROC: [STP_SEL_PROJETOS_MELHORIAS_INFORMACOES_RELEVANTES_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<ProjetosMelhoriasInformacoesRelevantesViewModel>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_PROJETOS_MELHORIAS_INFORMACOES_RELEVANTES_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@projetosMelhoriasId", projetosMelhoriasId));

                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();


                        while (result.Read())
                        {
                            DateTime? VariavelDateNula = null;

                            var projetosmelhoriasIR = new ProjetosMelhoriasInformacoesRelevantesViewModel();
                            projetosmelhoriasIR.DataAtualizacao = result["DataAtualizacao"] != DBNull.Value ? Convert.ToDateTime(result["DataAtualizacao"]) : VariavelDateNula;
                            projetosmelhoriasIR.AdicionadoPor = result["AdicionadoPor"] == null ? string.Empty : result["AdicionadoPor"].ToString();
                            projetosmelhoriasIR.Descricao = result["Descricao"] == null ? string.Empty : result["Descricao"].ToString();

                            retorno.Add(projetosmelhoriasIR);
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
        public int Inserir(ProjetosMelhoriasInformacoesRelevantes domain)
        //Description:	Insere uma nova informação relevante em um Projeto de Melhoria.
        //PROC: [STP_INS_PROJETOS_MELHORIAS_INFORMACOES_RELEVANTES]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;                     

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_PROJETOS_MELHORIAS_INFORMACOES_RELEVANTES", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@info_pro_id", domain.ProjetosMelhoriasId));
                        command.Parameters.Add(new SqlParameter("@info_data_atualizacao", domain.DataAtualizacao));
                        command.Parameters.Add(new SqlParameter("@info_addpor", domain.AdicionadoPor));
                        command.Parameters.Add(new SqlParameter("@info_descricao", domain.Descricao));

                        var result = command.ExecuteScalar();

                        conn.Close();
                        _logger.salvarLog(TipoAlteracao.Criacao, "", "", _logger.serializer.Serialize(domain));

                        return Convert.ToInt32(result);
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