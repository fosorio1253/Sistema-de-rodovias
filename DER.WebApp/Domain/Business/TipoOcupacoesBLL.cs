using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class TipoOcupacoesBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public TipoOcupacoesBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<ViewModels.TipoOcupacaoViewModel> ObtemTipoOcupacoes()
        {
            var retorno = new List<ViewModels.TipoOcupacaoViewModel>();

            //var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.TipoOcupacao);
            var dominio = dadosMestresDAO.ObtemDominioTipoOcupacao((int)TabelaDadosMestresEnum.TipoOcupacao);
            

            foreach (var d in dominio)
            {
                retorno.Add(new ViewModels.TipoOcupacaoViewModel() { TipoOcupacaoId = d.Id, Nome = d.Nome, 
                                                                     AlturaMinima = d.AlturaMinima, ProfundidadeMinima = d.ProfundidadeMinima});
            }

            return retorno;
        }
    }
}