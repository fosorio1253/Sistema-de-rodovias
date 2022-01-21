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
        private GestaoInteressadoTipoDeConcessaoDAO gestaoInteressadoTipoDeConcessaoDAO;
        private TipoConcessaoBLL tipoConcessaoBLL;

        public TipoDeConcessaoBLL()
        {
            _context = new DerContext();
            gestaoInteressadoTipoDeConcessaoDAO = new GestaoInteressadoTipoDeConcessaoDAO(_context);
            tipoConcessaoBLL = new TipoConcessaoBLL();
        }

        public List<TipoDeConcessaoViewModel> ObtemTipoDeConcessao(int? idGestao)
        {
            var retorno = new List<TipoDeConcessaoViewModel>();
            var concessoes = new List<TipoDeConcessaoViewModel>();

            if (idGestao != null)
                concessoes = gestaoInteressadoTipoDeConcessaoDAO.GetByGestaoId((int)idGestao);

            tipoConcessaoBLL.LoadView().ForEach(x =>
            {
                var marcado = false;

                if (idGestao != null)
                {
                    var con = concessoes.FirstOrDefault(y => y.IdGestao == (int)idGestao && y.TipoConcessaoId == x.tipo_concessao_id);
                    marcado = (con != null) ? con.Marcado : marcado;
                }

                retorno.Add(new TipoDeConcessaoViewModel() { TipoConcessaoId = x.tipo_concessao_id, Nome = " - " + x.Descricao, Marcado = marcado });
            });
            return retorno;
        }
    }
}