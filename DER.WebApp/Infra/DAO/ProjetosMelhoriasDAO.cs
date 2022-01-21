using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.DTO;
using DER.WebApp.Infra.DAL;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using DER.WebApp.ViewModels.ProjetosMelhorias;
using System;
using DER.WebApp.Helper;
using DER.WebApp.ViewModels.GestaoOcupacoes;

namespace DER.WebApp.Infra.DAO
{
    public class ProjetosMelhoriasDAO : BaseDAO<ProjetosMelhorias>
    {
        
        public ProjetosMelhoriasDAO(DerContext context) : base(context)
        {
            
        }

        public List<ListaProjetosMelhoriasDTO> GetListProjetosMelhorias()
        //Descrição: Retorna a lista com todos os Projetos de Melhorias ativos.
        //PROC: STP_SEL_PROJETOS_MELHORIAS_LISTA
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<ListaProjetosMelhoriasDTO>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_PROJETOS_MELHORIAS_LISTA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            var projetosMelhorias = new ListaProjetosMelhoriasDTO();
                            projetosMelhorias.Id = result["Id"] is DBNull ? 0 : Convert.ToInt32(result["Id"]);
                            projetosMelhorias.Regional = (result["Regional"] == null ? string.Empty : result["Regional"].ToString());
                            projetosMelhorias.Municipio = (result["Municipio"] == null ? string.Empty : result["Municipio"].ToString());
                            projetosMelhorias.Rodovia = (result["Rodovia"] == null ? string.Empty : result["Rodovia"].ToString());
                            projetosMelhorias.Nome = (result["Nome"].ToString() == null ? String.Empty : result["Nome"].ToString());
                            projetosMelhorias.KmInicial = result["KmInicial"] is DBNull ? 0 : Convert.ToInt32(result["KmInicial"]);
                            projetosMelhorias.KmFinal = result["KmFinal"] is DBNull ? 0 : Convert.ToInt32(result["KmFinal"]);
                            projetosMelhorias.Extensao = result["Extensao"] is DBNull ? 0 : Convert.ToInt32(result["Extensao"]);
                            projetosMelhorias.Sentido = result["Sentido"] is DBNull ? string.Empty : result["Sentido"].ToString();
                            projetosMelhorias.LadoId = result["Lado"] is DBNull ? 0 : Convert.ToInt32(result["Lado"]);
                            projetosMelhorias.Lote = result["Lote"] is DBNull ? string.Empty : result["Lote"].ToString();
                            projetosMelhorias.Status = result["Status"] is DBNull ? string.Empty : result["Status"].ToString();
                            projetosMelhorias.NumeroContrato = result["NumeroContrato"] is DBNull ? string.Empty : result["NumeroContrato"].ToString();
                            projetosMelhorias.Prazo = result["Prazo"] is DBNull ? string.Empty : result["Prazo"].ToString();
                            projetosMelhorias.PrevisaoInicio = result["PrevisaoInicio"] is DBNull ? string.Empty : result["PrevisaoInicio"].ToString();
                            projetosMelhorias.Descricao = result["Descricao"] is DBNull ? string.Empty : result["Descricao"].ToString();
                            projetosMelhorias.UnidadeConservacao = result["UnidadeConservacao"] is DBNull ? string.Empty : result["UnidadeConservacao"].ToString();

                            retorno.Add(projetosMelhorias);
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

        public int Inserir(ProjetosMelhorias domain)
        //Descrição: Insere um Projeto de Melhoria.
        //PROC: STP_INS_PROJETOS_MELHORIAS
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_PROJETOS_MELHORIAS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@pro_regional", domain.RegionalId));
                        command.Parameters.Add(new SqlParameter("@pro_municipio", domain.MunicipioId));
                        command.Parameters.Add(new SqlParameter("@pro_rodovia", domain.RodoviaId));
                        command.Parameters.Add(new SqlParameter("@pro_nome", domain.Nome));
                        command.Parameters.Add(new SqlParameter("@pro_km_inicial", domain.KmInicial));
                        command.Parameters.Add(new SqlParameter("@pro_km_final", domain.KmFinal));
                        command.Parameters.Add(new SqlParameter("@pro_extensao", domain.Extensao));
                        command.Parameters.Add(new SqlParameter("@pro_sentido", domain.Sentido));
                        command.Parameters.Add(new SqlParameter("@pro_lado", domain.LadoId));
                        command.Parameters.Add(new SqlParameter("@pro_lote", domain.Lote));
                        command.Parameters.Add(new SqlParameter("@pro_status", domain.Status));
                        command.Parameters.Add(new SqlParameter("@pro_num_contrato", domain.NumeroContrato == String.Empty ? null : domain.NumeroContrato));
                        command.Parameters.Add(new SqlParameter("@pro_prazo", domain.Prazo == String.Empty ? null : domain.Prazo));
                        command.Parameters.Add(new SqlParameter("@pro_previsao_inicio", domain.PrevisaoInicio));
                        command.Parameters.Add(new SqlParameter("@pro_descricao", domain.Descricao));
                        command.Parameters.Add(new SqlParameter("@pro_ativo", domain.Ativo));
                        command.Parameters.Add(new SqlParameter("@pro_unidade_conservacao", domain.UnidadeConservacao));

                        var result = command.ExecuteScalar();

                        conn.Close();
                        var value = GetById(Convert.ToInt32(result)); 
                        
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ProjetosMelhoriasViewModel GetById(int id)
        //Descrição: Retorna um Projeto de Melhoria pelo ID.
        //PROC: STP_SEL_PROJETOS_MELHORIAS_ID
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new ProjetosMelhoriasViewModel();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_PROJETOS_MELHORIAS_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@id", id));
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            retorno.Id = result["Id"] == null ? 0 : Convert.ToInt32(result["Id"]);
                            retorno.RegionalId = result["RegionalId"] == null ? 0 : Convert.ToInt32(result["RegionalId"]);
                            retorno.MunicipioId = result["MunicipioId"] == null ? 0 : Convert.ToInt32(result["MunicipioId"]);
                            retorno.RodoviaId = result["RodoviaId"] == null ? 0 : Convert.ToInt32(result["RodoviaId"]);
                            retorno.Nome = result["Nome"] == null ? string.Empty : result["Nome"].ToString();
                            retorno.KmInicial = result["KmInicial"] == null ? 0 : Convert.ToDouble(result["KmInicial"]);
                            retorno.KmFinal = result["KmFinal"] == null ? 0 : Convert.ToDouble(result["KmFinal"]);
                            retorno.Extensao = result["Extensao"] == null ? 0 : Convert.ToDouble(result["Extensao"]);
                            retorno.Sentido = result["Sentido"] == null ? string.Empty : result["Sentido"].ToString();
                            retorno.LadoId = result["LadoId"] == null ? 0 : Convert.ToInt32(result["LadoId"]);
                            retorno.Lote = result["Lote"] == null ? string.Empty : result["Lote"].ToString();
                            retorno.Status = result["Status"] == null ? string.Empty : result["Status"].ToString();
                            retorno.NumeroContrato = result["NumeroContrato"] == null ? string.Empty : result["NumeroContrato"].ToString();
                            retorno.Prazo = result["Prazo"] == null ? string.Empty : result["Prazo"].ToString();
                            retorno.PrevisaoInicio = result["PrevisaoInicio"] == null ? string.Empty : result["PrevisaoInicio"].ToString();
                            retorno.Descricao = result["Descricao"] == null ? string.Empty : result["Descricao"].ToString();
                            retorno.UnidadeConservacao = result["UnidadeConservacao"] == null ? string.Empty : result["UnidadeConservacao"].ToString();
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

        public int Atualizar(ProjetosMelhorias domain)
        // Descrição: Atualiza um Projeto de Melhoria.
        //PROC: STP_UPD_PROJETOS_MELHORIAS
        {
            
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
        
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_PROJETOS_MELHORIAS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@RegionalId", domain.RegionalId));
                        command.Parameters.Add(new SqlParameter("@MunicipioId", domain.MunicipioId));
                        command.Parameters.Add(new SqlParameter("@RodoviaId", domain.RodoviaId));
                        command.Parameters.Add(new SqlParameter("@Nome", domain.Nome));
                        command.Parameters.Add(new SqlParameter("@KmInicial", domain.KmInicial));
                        command.Parameters.Add(new SqlParameter("@KmFinal", domain.KmFinal));
                        command.Parameters.Add(new SqlParameter("@Extensao", domain.Extensao));
                        command.Parameters.Add(new SqlParameter("@Sentido", domain.Sentido));
                        command.Parameters.Add(new SqlParameter("@LadoId", domain.LadoId));
                        command.Parameters.Add(new SqlParameter("@Lote", domain.Lote));
                        command.Parameters.Add(new SqlParameter("@Status", domain.Status));
                        command.Parameters.Add(new SqlParameter("@NumeroContrato", domain.NumeroContrato));
                        command.Parameters.Add(new SqlParameter("@Prazo", domain.Prazo));
                        command.Parameters.Add(new SqlParameter("@PrevisaoInicio", domain.PrevisaoInicio));
                        command.Parameters.Add(new SqlParameter("@Descricao", domain.Descricao));
                        command.Parameters.Add(new SqlParameter("@id", domain.Id));
                        command.Parameters.Add(new SqlParameter("@UnidadeConservacao", domain.UnidadeConservacao));

                        var result = command.ExecuteNonQuery();
                        
                        return domain.Id;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }          
        }

        public void Excluir(int id)
        //Description:	Excluir logicamente um Projeto de Melhoria.
        //PROC: STP_DEL_PROJETOS_MELHORIAS
        {
            var oldValue = GetById(id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            
            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_PROJETOS_MELHORIAS", conn))
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

        public List<RetornoValidacaoTrechoProjetoViewModel> ValidacaoTrechoProjetoMelhoria(ValidacaoTrechoProjetoViewModel viewModel)
        //Description:	Retorna a lista de Trechos existentes antes de cadastrar um Projeto de Melhoria. 
        //PROC: STP_SEL_PROJETOS_MELHORIAS_VALIDA_TRECHO
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<RetornoValidacaoTrechoProjetoViewModel>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_PROJETOS_MELHORIAS_VALIDA_TRECHO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@lado", viewModel.Lado));
                        command.Parameters.Add(new SqlParameter("@rodoviaId", viewModel.RodoviaId));
                        command.Parameters.Add(new SqlParameter("@kmInicial", viewModel.KmInicial));
                        command.Parameters.Add(new SqlParameter("@kmFinal", viewModel.KmFinal));

                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            var projetosmelhorias = new RetornoValidacaoTrechoProjetoViewModel();
                            projetosmelhorias.projeto_melhoria_id = Convert.ToInt32(result["PROJETO_MELHORIA_ID"]);
                            projetosmelhorias.projeto_melhoria_nome = result["PROJETO_MELHORIA_NOME"].ToString();

                            retorno.Add(projetosmelhorias);
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
    }
}