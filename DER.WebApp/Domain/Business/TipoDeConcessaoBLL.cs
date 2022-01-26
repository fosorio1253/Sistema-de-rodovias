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
                retorno.Add(new TipoDeConcessaoViewModel()
                {
                    TipoConcessaoId = x.tipo_concessao_id, Nome = " - " + x.Descricao, Marcado = idGestao.HasValue ? 
                        Convert.ToBoolean(concessoes.FirstOrDefault(y => y.IdGestao == (int)idGestao && 
                        y.TipoConcessaoId == x.tipo_concessao_id).Marcado.ToString() ?? false.ToString()) : false
                });
            });
            return retorno;
        }
    }
}