using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class TipoConcessaoBLL
    {
        private DerContext context;
        private TipoConcessaoDAO tipoconcessaoDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            tipoconcessaoDAO = new TipoConcessaoDAO(context);
        }

        public bool Save(TipoConcessaoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.tipo_concessao_id) ?
                    tipoconcessaoDAO.Update(model) :
                    tipoconcessaoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoConcessaoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<TipoConcessaoViewModel>();
            }
        }

        public List<TipoConcessao> Load()
        {
            try
            {
                return tipoconcessaoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<TipoConcessao>();
            }
        }

        public bool Remove(TipoConcessaoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.tipo_concessao_id) ?
                    tipoconcessaoDAO.Delete(model) : false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExistsById(int id)
        {
            try
            {
                return Load().Any(x => x.tipo_concessao_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoConcessaoViewModel> ToList(TipoConcessaoViewModel model, List<TipoConcessaoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<TipoConcessaoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<TipoConcessaoViewModel>();
            }
        }

        private TipoConcessao ViewModelToModel(TipoConcessaoViewModel model)
        {
            try
            {
                var retorno = new TipoConcessao();
                retorno.tipo_concessao_id = model.tipo_concessao_id;
                retorno.Descricao = model.Descricao;
                retorno.Documentos = model.Documentos;
                retorno.profundidade_minima = model.profundidade_minima;
                retorno. = model.;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoConcessao();
            }
        }

        private TipoConcessaoViewModel ViewModelToModel(TipoConcessao model)
        {
            try
            {
                var retorno = new TipoConcessaoViewModel();
                retorno.tipo_concessao_id = model.tipo_concessao_id;
                retorno.Descricao = model.Descricao;
                retorno.Documentos = model.Documentos;
                retorno.profundidade_minima = model.profundidade_minima;
                retorno. = model.;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoConcessao();
            }
        }
    }

}