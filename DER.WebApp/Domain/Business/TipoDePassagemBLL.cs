using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class TipoDePassagemBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public TipoDePassagemBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<GestaoOcupacoesTipoPassagemViewModel> ObtemTipoPassagens()
        {
            var retorno = new List<GestaoOcupacoesTipoPassagemViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.TipoDePassagem);

            foreach (var d in dominio)
            {
                retorno.Add(new GestaoOcupacoesTipoPassagemViewModel() { TipoPassagemId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}