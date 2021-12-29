using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class OrigemDaSolicitacaoBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public OrigemDaSolicitacaoBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<GestaoOcupacoesOrigemSolicitacaoViewModel> ObtemOrigemSolicitacoes()
        {
            var retorno = new List<GestaoOcupacoesOrigemSolicitacaoViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.OrigemDaSolicitacao);

            foreach (var d in dominio)
            {
                retorno.Add(new GestaoOcupacoesOrigemSolicitacaoViewModel() { OrigemSolicitacaoId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}