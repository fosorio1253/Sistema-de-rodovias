using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class TipoDeInterferenciaBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public TipoDeInterferenciaBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<TipoDeInterferenciaViewModel> ObtemTipoDeInterferencias()
        {
            var retorno = new List<TipoDeInterferenciaViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.TipoDeInterferencia);

            foreach (var d in dominio)
            {
                retorno.Add(new TipoDeInterferenciaViewModel() { TipoDeInterferenciaId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}