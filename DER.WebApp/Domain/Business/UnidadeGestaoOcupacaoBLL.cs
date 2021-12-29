using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class UnidadeGestaoOcupacaoBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public UnidadeGestaoOcupacaoBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<GestaoOcupacoesUnidadeViewModel> ObtemUnidades()
        {
            var retorno = new List<GestaoOcupacoesUnidadeViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.Unidade);

            foreach (var d in dominio)
            {
                retorno.Add(new GestaoOcupacoesUnidadeViewModel() { UnidadeId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}