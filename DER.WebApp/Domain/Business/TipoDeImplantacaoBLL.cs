using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class TipoDeImplantacaoBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public TipoDeImplantacaoBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<GestaoOcupacoesTipoImplantacaoViewModel> ObtemTipoImplantacoes()
        {
            var retorno = new List<GestaoOcupacoesTipoImplantacaoViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.TipoDeImplantacao);

            foreach (var d in dominio)
            {
                retorno.Add(new GestaoOcupacoesTipoImplantacaoViewModel() { TipoImplantacaoId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}