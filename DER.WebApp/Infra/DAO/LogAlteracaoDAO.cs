using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.ViewModels.Log;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace DER.WebApp.Infra.DAO
{
    public class LogAlteracaoDAO : BaseDAO<LogAlteracao>
    {
        public LogAlteracaoDAO(DerContext derContext) : base(derContext)
        {

        }

        public static DateTime EndOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        public static DateTime StartOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }
        public List<LogAlteracao> Lista(LogViewModelParam logViewModel)
        {
            IQueryable<LogAlteracao> consulta = db.LogAlteracao;
            DateTime dataInicial = default, dataFinal = default;
            
            if (logViewModel.DataInicial.HasValue)
            {
                dataInicial = StartOfDay(logViewModel.DataInicial.Value);
            }

            if (logViewModel.DataFinal.HasValue)
            {
                dataFinal = EndOfDay(logViewModel.DataFinal.Value);    
            }
            
            if(logViewModel.DataInicial == null && logViewModel.DataFinal == null && (logViewModel.TipoAlteracao == null || logViewModel.TipoAlteracao == "Selecione"))
            {
                var ontem = DateTime.Now.AddDays(-17);
                return consulta.Where(c => c.DataAlteracao >= ontem).ToList();
            }

            if(logViewModel.DataInicial != null)
            {
                consulta = consulta.Where(c => c.DataAlteracao >= dataInicial);
            }

            if(logViewModel.DataFinal != null && logViewModel.DataInicial != null)
            {
                consulta = consulta.Where(c => c.DataAlteracao <= dataFinal);
            }

            if(logViewModel.TipoAlteracao != null && logViewModel.TipoAlteracao != "Selecione")
            {
                consulta = consulta.Where(c => c.TipoAlteracao == logViewModel.TipoAlteracao);
            }

            return consulta.ToList();
        }

        public bool Salvar(LogAlteracao logAlteracao)
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_LOG_ALTERACAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@nomeEntidade", logAlteracao.NomeEntidade));
                        command.Parameters.Add(new SqlParameter("@idAlterado", logAlteracao.IdPrimaryKey));
                        command.Parameters.Add(new SqlParameter("@valorAntigo", logAlteracao.ValorAntigo));
                        command.Parameters.Add(new SqlParameter("@novoValor", logAlteracao.NovoValor));
                        command.Parameters.Add(new SqlParameter("@usuarioResponsavel", logAlteracao.ReponsavelAlteracao));
                        command.Parameters.Add(new SqlParameter("@dataAlteracao", logAlteracao.DataAlteracao));
                        command.Parameters.Add(new SqlParameter("@tipoAlteracao", logAlteracao.TipoAlteracao));
                        command.Parameters.Add(new SqlParameter("@nomeUsuarioResponsavel", logAlteracao.NomeUsuarioResponsavel));

                        var result = command.ExecuteScalar();

                        conn.Close();

                        return true;
                    }
                }
            }
            catch(Exception)
            {
                throw new System.Exception("Ocorreu um erro ao Salvar a LogAlteracao");
            }
        }
    }
}