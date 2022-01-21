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
    public class GestaoInteressadoObservacaoDAO : BaseDAO<GestaoInteressadoObservacao>
    {
        
        public GestaoInteressadoObservacaoDAO(DerContext context) : base(context)
        {
            
        }

        public void ExcluirPorIdGestao(int idGestao)
        //-- Description:	Deleta uma observação em Gestão de Interessado.
        //PROC: [STP_DEL_GESTAO_INTERESSADO_OBSERVACAO]
        {
            var oldValue = GetByGestaoId(idGestao);
            
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            const string sql = @"delete from tab_gestao_interessado_observacao where int_id = @idGestao";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sql, new { idGestao = idGestao }, commandType: CommandType.Text).ToList();

                conexao.Close();
                
            }
        }

        public List<GestaoObservacaoViewModel> GetByGestaoId(int idGestao)
        //-- Description:	Busca uma Observação em Gestão de Interessados.
        //PROC: [STP_SEL_GESTAO_INTERESSADO_OBSERVACAO_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<GestaoObservacaoViewModel>();

            const string sql = @"select
                                    int_obs_observacao as Observacao,
                                    int_obs_data as Data,
                                    int_obs_addPor as AdicionadoPor
                                FROM tab_gestao_interessado_observacao
                                WHERE int_id = @idGestao";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                retorno = db.Query<GestaoObservacaoViewModel>(sql, new { idGestao = idGestao }, commandType: CommandType.Text).ToList();
            }

            return retorno;
        }

        public void Inserir(GestaoInteressadoObservacao domain)
        //-- Description:	Insere uma nova Observação em Gestão de Interessados.
        //PROC: [STP_INS_GESTAO_INTERESSADO_OBSERVACAO]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_GESTAO_INTERESSADO_OBSERVACAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@gestaoInteressadoId", domain.GestaoInteressadoId));
                        command.Parameters.Add(new SqlParameter("@observacao", domain.Observacao));
                        command.Parameters.Add(new SqlParameter("@data", domain.Data));
                        command.Parameters.Add(new SqlParameter("@addPor", domain.AdicionadoPor));
                      
                        var result = command.ExecuteScalar();

                        conn.Close();                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            ///////////////////////////////////////////////

            //string sqlUpdate = @"INSERT INTO tab_gestao_interessado_observacao
            //                    VALUES( @gestaoInteressadoId,
            //                            @observacao,
            //                            @data,
            //                            @addPor)";

            //using (SqlConnection conexao = new SqlConnection(connectionString))
            //{
            //    conexao.Open();

            //    conexao.Query(sqlUpdate, new
            //    {
            //        gestaoInteressadoId = domain.GestaoInteressadoId,
            //        observacao = domain.Observacao,
            //        data = domain.Data,
            //        addPor = domain.AdicionadoPor.Substring(0,10)
            //    }, commandType: CommandType.Text);;

            //    conexao.Close();
            //}
        }
    }
}