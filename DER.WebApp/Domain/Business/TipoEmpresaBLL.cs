using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoInteressados;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class TipoEmpresaBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public TipoEmpresaBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<TipoEmpresaViewModel> ObtemTipoEmpresa()
        {
            var retorno = new List<TipoEmpresaViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.TipoEmpresa);

            foreach (var d in dominio)
            {
                retorno.Add(new TipoEmpresaViewModel() { TipoEmpresaId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}