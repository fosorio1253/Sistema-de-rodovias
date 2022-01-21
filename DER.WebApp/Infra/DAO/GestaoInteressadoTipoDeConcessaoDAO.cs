using Dapper;
using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Domain.Models.Enum;
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
    public class GestaoInteressadoTipoDeConcessaoDAO : BaseDAO<GestaoInteressadoTipoDeConcessao>
    {
        public GestaoInteressadoTipoDeConcessaoDAO(DerContext context) : base(context)
        {
        }

        public void ExcluirPorIdGestao(int idGestao)
        //-- Description:	Deleta um Tipo de Concessão em Gestão de Interessado.
        //PROC: [STP_DEL_GESTAO_INTERESSADO_TIPO_DE_CONCESSAO]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetByGestaoId(idGestao);

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_GESTAO_INTERESSADO_TIPO_DE_CONCESSAO", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@idGestao", idGestao));
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    conn.Close();
                    
                }
            }
        }

        public List<TipoDeConcessaoViewModel> GetByGestaoId(int idGestao)
        //-- Description:	Busca um Tipo de Concessão em Gestão de Interessados.
        //PROC: [STP_SEL_GESTAO_INTERESSADO_TIPO_DE_CONCESSAO_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<TipoDeConcessaoViewModel>();

            const string sql = @"select
                                    tipoConcessao.int_id as IdGestao,
                                    tipoConcessao.dmv_id_tipo_concessao as TipoConcessaoId,
                                    tipoConcessao.int_tipo_concessao_marcado as Marcado,
                                    descricao.dmv_valor as Nome, 
                                    documentos.dmv_valor as Documentos, 
                                    profundidadeMinima.dmv_valor as ProfundidadeMinima,
                                    alturaMinima.dmv_valor as AlturaMinima
                                FROM tab_gestao_interessado_tipo_de_concessao as tipoConcessao
                                LEFT JOIN tab_dadosMestres_val as descricao ON tipoConcessao.dmv_id_tipo_concessao=descricao.dmv_id AND descricao.col_id=30
                                LEFT JOIN tab_dadosMestres_val as documentos ON descricao.dmv_linha=documentos.dmv_linha AND documentos.col_id=489
                                LEFT JOIN tab_dadosMestres_val as profundidadeMinima ON descricao.dmv_linha=profundidadeMinima.dmv_linha AND profundidadeMinima.col_id=490
                                LEFT JOIN tab_dadosMestres_val as alturaMinima ON descricao.dmv_linha=alturaMinima.dmv_linha AND alturaMinima.col_id=491
                                WHERE int_id = @idGestao AND int_tipo_concessao_marcado=1";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                retorno = conexao.Query<TipoDeConcessaoViewModel>(sql, new { idGestao = idGestao }, commandType: CommandType.Text).ToList();
            }

            return retorno;


            ////////////////////////////////////
            ///
            //try
            //{
            //    using (var conn = new SqlConnection(connectionString))
            //    {
            //        using (var command = new SqlCommand("STP_SEL_GESTAO_INTERESSADO_TIPO_DE_CONCESSAO_ID", conn))
            //        {
            //            command.CommandType = CommandType.StoredProcedure;
            //            conn.Open();

            //            command.Parameters.Add(new SqlParameter("@idGestao", idGestao));

            //            SqlDataReader result = command.ExecuteReader();

            //            while (result.Read())
            //            {
            //                var tipoConcessao = new TipoDeConcessaoViewModel();
            //                tipoConcessao.IdGestao = result["IdGestao"] is DBNull ? 0 : Convert.ToInt32(result["IdGestao"]);
            //                tipoConcessao.TipoConcessaoId = result["TipoConcessaoId"] is DBNull ? 0 : Convert.ToInt32(result["TipoConcessaoId"]);
            //                tipoConcessao.Marcado = result["Marcado"] is 0 ? false : true;

            //                retorno.Add(tipoConcessao);
            //            }
            //            conn.Close();
            //        }
            //    }
            //    return retorno;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
        }
        public int Inserir(GestaoInteressadoTipoDeConcessao domain)
        //-- Description:	Insere um novo Tipo de Concessão em Gestão de Interessados.
        //PROC: [STP_INS_GESTAO_INTERESSADO_TIPO_DE_CONCESSAO]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_GESTAO_INTERESSADO_TIPO_DE_CONCESSAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@gestaoInteressadoId", domain.GestaoInteressadoId));
                        command.Parameters.Add(new SqlParameter("@tipoDeConcessaoId", domain.TipoDeConcessaoId));
                        command.Parameters.Add(new SqlParameter("@marcado", domain.Marcado));

                        var result = command.ExecuteScalar();

                        conn.Close();

                        var id = Convert.ToInt32(result);
                        
                        
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