using DER.WebApp.Domain.Models;
using DER.WebApp.Helper;
using DER.WebApp.Infra.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DER.WebApp.Infra.DAO
{
    public class PavimentosRigidosLevantamentoDAO : BaseDAO<PavimentosRigidosLevantamento>
    {
        Logger logger;

        public PavimentosRigidosLevantamentoDAO(DerContext context) : base(context)
        {
            logger = new Logger("PavimentosRigidosLevantamento");
        }

        public List<PavimentosRigidosLevantamento> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<PavimentosRigidosLevantamento>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_PAVIMENTOSRIGIDOSLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new PavimentosRigidosLevantamento();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.pvr_km_inicial = result["pvr_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["pvr_km_inicial"]);
                            retorno.pvr_km_final = result["pvr_km_final"] is DBNull ? 0 : Convert.ToDouble(result["pvr_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.pvr_data_levantamento = result["pvr_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["pvr_data_levantamento"]);
                            retorno.pvr_extensao = result["pvr_extensao"] is DBNull ? 0 : Convert.ToDouble(result["pvr_extensao"]);
                            retorno.rev_id = result["rev_id"] is DBNull ? 0 : Convert.ToInt32(result["rev_id"]);
                            retorno.pvr_data_criacao = result["pvr_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["pvr_data_criacao"]);

                            lretorno.Add(retorno);
                        }
                        conn.Close();
                    }
                }
                return lretorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Inserir(PavimentosRigidosLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_PAVIMENTOSRIGIDOSLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@pvr_km_inicial", domain.pvr_km_inicial));
                        command.Parameters.Add(new SqlParameter("@pvr_km_final", domain.pvr_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@pvr_data_levantamento", domain.pvr_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@pvr_extensao", domain.pvr_extensao));
                        command.Parameters.Add(new SqlParameter("@rev_id", domain.rev_id));
                        command.Parameters.Add(new SqlParameter("@pvr_data_criacao", domain.pvr_data_criacao));
                        var result = command.ExecuteScalar();
                        command.Parameters.Clear();
                        conn.Close();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(PavimentosRigidosLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_PAVIMENTOSRIGIDOSLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@pvr_km_inicial", domain.pvr_km_inicial));
                        command.Parameters.Add(new SqlParameter("@pvr_km_final", domain.pvr_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@pvr_data_levantamento", domain.pvr_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@pvr_extensao", domain.pvr_extensao));
                        command.Parameters.Add(new SqlParameter("@rev_id", domain.rev_id));
                        command.Parameters.Add(new SqlParameter("@pvr_data_criacao", domain.pvr_data_criacao));
                        var result = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                var value = GetById(domain.rod_id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PavimentosRigidosLevantamento GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new PavimentosRigidosLevantamento();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_PAVIMENTOSRIGIDOSLEVANTAMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.pvr_km_inicial = result["pvr_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["pvr_km_inicial"]);
                            retorno.pvr_km_final = result["pvr_km_final"] is DBNull ? 0 : Convert.ToDouble(result["pvr_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.pvr_data_levantamento = result["pvr_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["pvr_data_levantamento"]);
                            retorno.pvr_extensao = result["pvr_extensao"] is DBNull ? 0 : Convert.ToDouble(result["pvr_extensao"]);
                            retorno.rev_id = result["rev_id"] is DBNull ? 0 : Convert.ToInt32(result["rev_id"]);
                            retorno.pvr_data_criacao = result["pvr_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["pvr_data_criacao"]);
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

        public bool Delete(PavimentosRigidosLevantamento model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_PAVIMENTOSRIGIDOSLEVANTAMENTO", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@rod_id", model.rod_id));
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    conn.Close();
                }
            }
            return true;
        }
    }


}