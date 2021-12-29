using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.DTO;
using DER.WebApp.Infra.DAL;
using DER.WebApp.ViewModels.GestaoInteressados;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DER.WebApp.Infra.DAO
{
    public class EmpresaDAO : BaseDAO<Empresa>
    {
        public EmpresaDAO(DerContext context) : base(context)
        {

        }

        public List<EmpresaViewModel> ObtemEmpresaUsuario(int UsuarioId)
        //-- Description:	Busca A EMPRESA DO interessado pelo ID.
        //PROC: [STP_SEL_GESTAO_INTERESSADO_EMPRESA_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<EmpresaViewModel>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_INTERESSADO_EMPRESA_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@usuarioId", UsuarioId));
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            var gestao = new EmpresaViewModel();
                            gestao.EmpresaId = result["Id"] is DBNull ? 0 : Convert.ToInt32(result["Id"]);
                            gestao.Nome = (result["Nome"] == null ? string.Empty : result["Nome"].ToString());

                            retorno.Add(gestao);
                        }
                        conn.Close();
                    }
                }               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retorno;
        }
    }
}