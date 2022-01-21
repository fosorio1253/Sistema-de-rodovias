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
    public class RodoviaDAO : BaseDAO<Rodovia>
    {
        

        public RodoviaDAO(DerContext context) : base(context)
        {
            
        }

        public static void CadastrarRodovias(List<Rodovia> domains)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_RODOVIAS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        foreach(var domain in domains)
                        {
                            command.Parameters.Add(new SqlParameter("@rodCodigo", domain.rod_codigo));
                            command.Parameters.Add(new SqlParameter("@jurIdOrigem", domain.jur_id_origem));
                            command.Parameters.Add(new SqlParameter("@rteId", domain.rte_id));
                            command.Parameters.Add(new SqlParameter("@rorId", domain.ror_id));
                            command.Parameters.Add(new SqlParameter("@rodKmInicial", domain.rod_km_inicial));
                            command.Parameters.Add(new SqlParameter("@rodKmFinal", domain.rod_km_final));
                            command.Parameters.Add(new SqlParameter("@rodKmExtensao", domain.rod_km_extensao));

                            var result = command.ExecuteScalar();

                            command.Parameters.Clear();
                        }
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