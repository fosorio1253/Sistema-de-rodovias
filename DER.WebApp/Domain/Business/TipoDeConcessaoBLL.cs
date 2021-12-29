using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.GestaoInteressados;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class TipoDeConcessaoBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;
        private GestaoInteressadoTipoDeConcessaoDAO gestaoInteressadoTipoDeConcessaoDAO;

        public TipoDeConcessaoBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
            gestaoInteressadoTipoDeConcessaoDAO = new GestaoInteressadoTipoDeConcessaoDAO(_context);
        }

        public List<TipoDeConcessaoViewModel> ObtemTipoDeConcessao(int? idGestao)
        {
            var retorno = new List<TipoDeConcessaoViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.TipoDeConcessao);

            var concessoes = new List<TipoDeConcessaoViewModel>();

            if (idGestao != null)
            {
                concessoes = gestaoInteressadoTipoDeConcessaoDAO.GetByGestaoId((int)idGestao);
            }

            foreach (var d in dominio)
            {
                var marcado = false;

                if (idGestao != null)
                {
                    var con = concessoes.FirstOrDefault(x => x.IdGestao == (int)idGestao && x.TipoConcessaoId == d.Id);
                    marcado = (con != null) ? con.Marcado : marcado;
                }

                retorno.Add(new TipoDeConcessaoViewModel() { TipoConcessaoId = d.Id, Nome = " - " + d.Nome, Marcado = marcado  });
            }

            return retorno;
        }
    }
}