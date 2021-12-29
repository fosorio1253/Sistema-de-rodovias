using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoInteressados;
using System.Collections.Generic;


namespace DER.WebApp.Domain.Business
{
    public class NaturezaJuridicaBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public NaturezaJuridicaBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<ViewModels.NaturezaJuridicaViewModel> ObtemNaturezaJuridica()
        {
            var retorno = new List<ViewModels.NaturezaJuridicaViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.NaturezaJuridica);

            foreach (var d in dominio)
            {
                retorno.Add(new ViewModels.NaturezaJuridicaViewModel() { NaturezaJuridicaId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}