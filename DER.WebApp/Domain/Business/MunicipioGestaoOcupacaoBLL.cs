using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class MunicipioGestaoOcupacaoBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public MunicipioGestaoOcupacaoBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<GestaoOcupacoesMunicipioViewModel> ObtemMunicipio()
        {
            var retorno = new List<GestaoOcupacoesMunicipioViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.Municipio, "Municipio");

            foreach (var d in dominio)
            {
                retorno.Add(new GestaoOcupacoesMunicipioViewModel() { MunicipioId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}