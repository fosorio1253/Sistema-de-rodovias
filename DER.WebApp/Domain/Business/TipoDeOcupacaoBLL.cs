using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class TipoDeOcupacaoBLL
    {
        private DerContext _context;
        private GestaoOcupacaoTipoDAO gestaoOcupacaoTipoDAO;

        public TipoDeOcupacaoBLL()
        {
            _context = new DerContext();
            gestaoOcupacaoTipoDAO = new GestaoOcupacaoTipoDAO(_context);
        }

        public List<GestaoOcupacoesTipoOcupacaoViewModel> ObtemTipoOcupacoes(int idInteressado)
        {
            return gestaoOcupacaoTipoDAO.GetByIdInteressado(idInteressado);
        }
    }
}