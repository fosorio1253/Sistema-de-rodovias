using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoInteressados;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class MunicipioBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public MunicipioBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<ViewModels.MunicipioViewModel> ObtemMunicipio()
        {
            var retorno = new List<ViewModels.MunicipioViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.Municipio, "Municipio");

            foreach (var d in dominio)
            {
                retorno.Add(new ViewModels.MunicipioViewModel() { MunicipioId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}