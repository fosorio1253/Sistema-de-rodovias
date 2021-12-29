using DER.WebApp.Domain.Models;
using DER.WebApp.Helper;
using DER.WebApp.Infra.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DER.WebApp.Infra.DAO
{
    public class GestaoOcupacoesPEPDAO : BaseDAO<GestaoOcupacoesPEP>
    {
        Logger logger;

        public GestaoOcupacoesPEPDAO(DerContext context) : base(context)
        {
            logger = new Logger("GestaoOcupacoesPEP", context);
        }

        public List<GestaoOcupacoesPEP> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new List<GestaoOcupacoesPEP>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_OCUPACAO_PEP", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dt = DateTime.MinValue;

                        while (result.Read())
                        {
                            var PEP = new GestaoOcupacoesPEP();
                            PEP.Id_PEP                          = result["Id_PEP"]                          is DBNull ? 0   : Convert.ToInt32(result["Id_PEP"]);
                            PEP.Id_Interessado                  = result["Id_Interessado"]                  is DBNull ? 0   : Convert.ToInt32(result["Id_Interessado"]);
                            PEP.Id_Ocupacao                     = result["Id_Ocupacao"]                     is DBNull ? 0   : Convert.ToInt32(result["Id_Ocupacao"]);
                            PEP.DataEmissãoPEP                  = result["DataEmissãoPEP"]                  is DBNull ? dt  : Convert.ToDateTime(result["DataEmissãoPEP"]);
                            PEP.DataPagamento                   = result["DataPagamento"]                   is DBNull ? dt  : Convert.ToDateTime(result["DataPagamento"]);
                            PEP.Datavencimento                  = result["Datavencimento"]                  is DBNull ? dt  : Convert.ToDateTime(result["Datavencimento"]);
                            PEP.Valor                           = result["Valor"]                           is DBNull ? 0   : Convert.ToDecimal(result["Valor"]);
                            PEP.Comprovante                     = result["Comprovante"]                     is DBNull ? ""  : result["Comprovante"].ToString();
                            PEP.dataBaseCalculo                 = result["dataBaseCalculo"]                 is DBNull ? ""  : result["dataBaseCalculo"].ToString();
                            PEP.UFESP                           = result["UFESP"]                           is DBNull ? 0   : Convert.ToDecimal(result["UFESP"]);
                            PEP.extensaoOcupacaoLongitudinal    = result["extensaoOcupacaoLongitudinal"]    is DBNull ? 0   : Convert.ToDecimal(result["extensaoOcupacaoLongitudinal"]);
                            PEP.extensaoOcupacaoTransversal     = result["extensaoOcupacaoTransversal"]     is DBNull ? 0   : Convert.ToDecimal(result["extensaoOcupacaoTransversal"]);
                            PEP.extensaoOcupacaoPontual         = result["extensaoOcupacaoPontual"]         is DBNull ? 0   : Convert.ToDecimal(result["extensaoOcupacaoPontual"]);
                            PEP.fatorRemuneracao                = result["fatorRemuneracao"]                is DBNull ? 0   : Convert.ToDecimal(result["fatorRemuneracao"]);
                            PEP.OcupacaoLongitudinal            = result["OcupacaoLongitudinal"]            is DBNull ? 0   : Convert.ToDecimal(result["OcupacaoLongitudinal"]);
                            PEP.OcupacaoTransversal             = result["OcupacaoTransversal"]             is DBNull ? 0   : Convert.ToDecimal(result["OcupacaoTransversal"]);
                            PEP.OcupacaoPontual                 = result["OcupacaoPontual"]                 is DBNull ? 0   : Convert.ToDecimal(result["OcupacaoPontual"]);
                            PEP.totalCalculado                  = result["totalCalculado"]                  is DBNull ? 0   : Convert.ToDecimal(result["totalCalculado"]);
                            PEP.Tipo_Ocupacao                   = result["Tipo_Ocupacao"]                   is DBNull ? 0   : Convert.ToInt32(result["Tipo_Ocupacao"]);
                            PEP.Status                          = result["Status"]                          is DBNull ? ""  : result["Status"].ToString();

                            retorno.Add(PEP);
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

        public bool Inserir(GestaoOcupacoesPEP domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_GESTAO_OCUPACAO_PEP", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@Id_Interessado",                  domain.Id_Interessado));
                        command.Parameters.Add(new SqlParameter("@Id_Ocupacao",                     domain.Id_Ocupacao));
                        command.Parameters.Add(new SqlParameter("@DataEmissãoPEP",                  domain.DataEmissãoPEP));
                        command.Parameters.Add(new SqlParameter("@DataPagamento",                   domain.DataPagamento));
                        command.Parameters.Add(new SqlParameter("@Datavencimento",                  domain.Datavencimento));
                        command.Parameters.Add(new SqlParameter("@Valor",                           domain.Valor));
                        command.Parameters.Add(new SqlParameter("@Comprovante",                     Encoding.ASCII.GetBytes(domain.Comprovante ?? "")));
                        command.Parameters.Add(new SqlParameter("@dataBaseCalculo",                 domain.dataBaseCalculo));
                        command.Parameters.Add(new SqlParameter("@UFESP",                           domain.UFESP));
                        command.Parameters.Add(new SqlParameter("@extensaoOcupacaoLongitudinal",    domain.extensaoOcupacaoLongitudinal));
                        command.Parameters.Add(new SqlParameter("@extensaoOcupacaoTransversal",     domain.extensaoOcupacaoTransversal));
                        command.Parameters.Add(new SqlParameter("@extensaoOcupacaoPontual",         domain.extensaoOcupacaoPontual));
                        command.Parameters.Add(new SqlParameter("@fatorRemuneracao",                domain.fatorRemuneracao));
                        command.Parameters.Add(new SqlParameter("@OcupacaoLongitudinal",            domain.OcupacaoLongitudinal));
                        command.Parameters.Add(new SqlParameter("@OcupacaoTransversal",             domain.OcupacaoTransversal));
                        command.Parameters.Add(new SqlParameter("@OcupacaoPontual",                 domain.OcupacaoPontual));
                        command.Parameters.Add(new SqlParameter("@totalCalculado",                  domain.totalCalculado));
                        command.Parameters.Add(new SqlParameter("@Tipo_Ocupacao",                   domain.Tipo_Ocupacao));
                        command.Parameters.Add(new SqlParameter("@Status",                          domain.Status));

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

        public bool Update(GestaoOcupacoesPEP domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.Id_PEP);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_GESTAO_OCUPACAO_PEP", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@Id_PEP",                          domain.Id_PEP));
                        command.Parameters.Add(new SqlParameter("@Id_Interessado",                  domain.Id_Interessado));
                        command.Parameters.Add(new SqlParameter("@Id_Ocupacao",                     domain.Id_Ocupacao));
                        command.Parameters.Add(new SqlParameter("@DataEmissãoPEP",                  domain.DataEmissãoPEP));
                        command.Parameters.Add(new SqlParameter("@DataPagamento",                   domain.DataPagamento));
                        command.Parameters.Add(new SqlParameter("@Datavencimento",                  domain.Datavencimento));
                        command.Parameters.Add(new SqlParameter("@Valor",                           domain.Valor));
                        command.Parameters.Add(new SqlParameter("@Comprovante",                     domain.Comprovante));
                        command.Parameters.Add(new SqlParameter("@dataBaseCalculo",                 domain.dataBaseCalculo));
                        command.Parameters.Add(new SqlParameter("@UFESP",                           domain.UFESP));
                        command.Parameters.Add(new SqlParameter("@extensaoOcupacaoLongitudinal",    domain.extensaoOcupacaoLongitudinal));
                        command.Parameters.Add(new SqlParameter("@extensaoOcupacaoTransversal",     domain.extensaoOcupacaoTransversal));
                        command.Parameters.Add(new SqlParameter("@extensaoOcupacaoPontual",         domain.extensaoOcupacaoPontual));
                        command.Parameters.Add(new SqlParameter("@fatorRemuneracao",                domain.fatorRemuneracao));
                        command.Parameters.Add(new SqlParameter("@OcupacaoLongitudinal",            domain.OcupacaoLongitudinal));
                        command.Parameters.Add(new SqlParameter("@OcupacaoTransversal",             domain.OcupacaoTransversal));
                        command.Parameters.Add(new SqlParameter("@OcupacaoPontual",                 domain.OcupacaoPontual));
                        command.Parameters.Add(new SqlParameter("@totalCalculado",                  domain.totalCalculado));
                        command.Parameters.Add(new SqlParameter("@Tipo_Ocupacao",                   domain.Tipo_Ocupacao));
                        command.Parameters.Add(new SqlParameter("@Status",                          domain.Status));

                        var result = command.ExecuteNonQuery();

                        conn.Close();
                    }
                }
                var value = GetById(domain.Id_PEP);
                if (!value.Equals(oldValue))
                    logger.salvarLog(TipoAlteracao.Edicao, domain.Id_PEP.ToString(), logger.serializer.Serialize(oldValue), logger.serializer.Serialize(value));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public GestaoOcupacoesPEP GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var PEP = new GestaoOcupacoesPEP();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_OCUPACAO_PEP_BYID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@Id_PEP", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dt = DateTime.MinValue;

                        while (result.Read())
                        {
                            PEP.Id_PEP                          = result["Id_PEP"]                          is DBNull ? 0   : Convert.ToInt32(result["Id_PEP"]);
                            PEP.Id_Interessado                  = result["Id_Interessado"]                  is DBNull ? 0   : Convert.ToInt32(result["Id_Interessado"]);
                            PEP.Id_Ocupacao                     = result["Id_Ocupacao"]                     is DBNull ? 0   : Convert.ToInt32(result["Id_Ocupacao"]);
                            PEP.DataEmissãoPEP                  = result["DataEmissãoPEP"]                  is DBNull ? dt  : Convert.ToDateTime(result["DataEmissãoPEP"]);
                            PEP.DataPagamento                   = result["DataPagamento"]                   is DBNull ? dt  : Convert.ToDateTime(result["DataPagamento"]);
                            PEP.Datavencimento                  = result["Datavencimento"]                  is DBNull ? dt  : Convert.ToDateTime(result["Datavencimento"]);
                            PEP.Valor                           = result["Valor"]                           is DBNull ? 0   : Convert.ToDecimal(result["Valor"]);
                            PEP.Comprovante                     = result["Comprovante"]                     is DBNull ? ""  : result["Comprovante"].ToString();
                            PEP.dataBaseCalculo                 = result["dataBaseCalculo"]                 is DBNull ? ""  : result["dataBaseCalculo"].ToString();
                            PEP.UFESP                           = result["UFESP"]                           is DBNull ? 0   : Convert.ToDecimal(result["UFESP"]);
                            PEP.extensaoOcupacaoLongitudinal    = result["extensaoOcupacaoLongitudinal"]    is DBNull ? 0   : Convert.ToDecimal(result["extensaoOcupacaoLongitudinal"]);
                            PEP.extensaoOcupacaoTransversal     = result["extensaoOcupacaoTransversal"]     is DBNull ? 0   : Convert.ToDecimal(result["extensaoOcupacaoTransversal"]);
                            PEP.extensaoOcupacaoPontual         = result["extensaoOcupacaoPontual"]         is DBNull ? 0   : Convert.ToDecimal(result["extensaoOcupacaoPontual"]);
                            PEP.fatorRemuneracao                = result["fatorRemuneracao"]                is DBNull ? 0   : Convert.ToDecimal(result["fatorRemuneracao"]);
                            PEP.OcupacaoLongitudinal            = result["OcupacaoLongitudinal"]            is DBNull ? 0   : Convert.ToDecimal(result["OcupacaoLongitudinal"]);
                            PEP.OcupacaoTransversal             = result["OcupacaoTransversal"]             is DBNull ? 0   : Convert.ToDecimal(result["OcupacaoTransversal"]);
                            PEP.OcupacaoPontual                 = result["OcupacaoPontual"]                 is DBNull ? 0   : Convert.ToDecimal(result["OcupacaoPontual"]);
                            PEP.totalCalculado                  = result["totalCalculado"]                  is DBNull ? 0   : Convert.ToDecimal(result["totalCalculado"]);
                            PEP.Tipo_Ocupacao                   = result["Tipo_Ocupacao"]                   is DBNull ? 0   : Convert.ToInt32(result["Tipo_Ocupacao"]);
                            PEP.Status                          = result["Status"]                          is DBNull ? ""  : result["Status"].ToString();
                        }
                        conn.Close();
                    }
                }
                return PEP;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}