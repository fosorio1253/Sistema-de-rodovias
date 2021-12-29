using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class SituacaoDaSolicitacaoBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public SituacaoDaSolicitacaoBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<GestaoOcupacoesSituacaoSolicitacaoViewModel> ObtemSituacaoSolicitacoes()
        {
            var retorno = new List<GestaoOcupacoesSituacaoSolicitacaoViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.SituacaoDaSolicitacao);

            foreach (var d in dominio)
            {
                retorno.Add(new GestaoOcupacoesSituacaoSolicitacaoViewModel() { SituacaoSolicitacaoId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}