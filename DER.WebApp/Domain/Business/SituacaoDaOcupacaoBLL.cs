using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class SituacaoDaOcupacaoBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public SituacaoDaOcupacaoBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<GestaoOcupacoesSituacaoOcupacaoViewModel> ObtemSituacaoOcupacoes()
        {
            var retorno = new List<GestaoOcupacoesSituacaoOcupacaoViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.SituacaoDaOcupacao);

            foreach (var d in dominio)
            {
                retorno.Add(new GestaoOcupacoesSituacaoOcupacaoViewModel() { SituacaoOcupacaoId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}