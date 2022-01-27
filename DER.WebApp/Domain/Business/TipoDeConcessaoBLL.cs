using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.GestaoInteressados;
using System;
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
            var concessoes = idGestao.HasValue ? 
                gestaoInteressadoTipoDeConcessaoDAO.GetByGestaoId((int)idGestao) : 
                new List<TipoDeConcessaoViewModel>();

            tipoConcessaoBLL.LoadView().ForEach(x =>
            {
                var ret = new TipoDeConcessaoViewModel();
                ret.TipoConcessaoId = x.tipo_concessao_id;
                ret.Nome = x.Descricao;

                if (idGestao.HasValue)
                    if (concessoes.Any(y => y.IdGestao == (int)idGestao && y.TipoConcessaoId == x.tipo_concessao_id))
                        ret.Marcado = concessoes.Where(y => y.IdGestao == (int)idGestao && y.TipoConcessaoId == x.tipo_concessao_id).FirstOrDefault().Marcado;
                    else
                        ret.Marcado = false;
                else
                    ret.Marcado = false;

                retorno.Add(ret);
            });
            return retorno;
        }
    }
}