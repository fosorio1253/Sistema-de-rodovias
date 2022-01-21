using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.Log;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class LogBLL
    {
        private DerContext _context;
        private LogAlteracaoDAO logAlteracaoDAO;

        public LogBLL()
        {
            _context = new DerContext();
            logAlteracaoDAO = new LogAlteracaoDAO(_context);
        }

        public List<LogAlteracao> ObtemLista(LogViewModelParam logViewModel)
        {
            return logAlteracaoDAO.Lista(logViewModel);
        }
    }
}