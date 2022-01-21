using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoInteressados;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class TipoDeDocumentoBLL
    {
        private DerContext _context;

        public TipoDeDocumentoBLL()
        {
            _context = new DerContext();
        }

        public List<TipoDeDocumentoViewModel> ObtemTipoDeDocumento(int? id = null)
        {
            var retorno = new List<TipoDeDocumentoViewModel>();
            var dados = new List<TipoDocumento>();

            if (id != null)
            {
                dados = _context.TipoDocumento.Where(x => x.DocTipoInteressado == id && x.DocTipoInteressado == 32 || x.DocTipoInteressado == 33).ToList();
            } 
            else 
            {
                dados  = _context.TipoDocumento.Where(x => x.DocTipoInteressado == 32 || x.DocTipoInteressado == 33).ToList();
            }

            foreach (var d in dados) 
            {
                retorno.Add(new TipoDeDocumentoViewModel() { TipoDeDocumentoId = d.Id, Nome = d.NomeDocumento });
            }

            return retorno;
        }
    }
}