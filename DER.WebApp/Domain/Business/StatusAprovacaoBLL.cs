using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoInteressados;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class StatusAprovacaoBLL
    {
        private DerContext _context;
        private StatusAprovacaoDAO statusAprovacaoDAO;

        public StatusAprovacaoBLL()
        {
            _context = new DerContext();
            statusAprovacaoDAO = new StatusAprovacaoDAO(_context);
        }

        public List<StatusViewModel> ObtemStatus()
        {
            var retorno = new List<StatusViewModel>();

            var dominio = statusAprovacaoDAO.GetAll().OrderBy(x => x.Id);

            var statusAprovacaos = dominio.Where(x => x.Id >= 1 && x.Id <= 8).ToList();

            foreach (var d in statusAprovacaos)
            {
                retorno.Add(new StatusViewModel() { StatusId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}