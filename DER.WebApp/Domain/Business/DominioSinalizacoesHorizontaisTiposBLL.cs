using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class DominioSinalizacoesHorizontaisTiposBLL
    {
        private DerContext context;
        private DominioSinalizacoesHorizontaisTiposDAO dominiosinalizacoeshorizontaistiposDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            dominiosinalizacoeshorizontaistiposDAO = new DominioSinalizacoesHorizontaisTiposDAO(context);
        }

        public bool Save(DominioSinalizacoesHorizontaisTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.sht_id) ?
                    dominiosinalizacoeshorizontaistiposDAO.Update(model) :
                    dominiosinalizacoeshorizontaistiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioSinalizacoesHorizontaisTiposViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioSinalizacoesHorizontaisTiposViewModel>();
            }
        }

        public List<DominioSinalizacoesHorizontaisTipos> Load()
        {
            try
            {
                return dominiosinalizacoeshorizontaistiposDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioSinalizacoesHorizontaisTipos>();
            }
        }

        public bool Remove(DominioSinalizacoesHorizontaisTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.sht_id) ?
                    dominiosinalizacoeshorizontaistiposDAO.Delete(model) : false;
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
                return Load().Any(x => x.sht_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioSinalizacoesHorizontaisTiposViewModel> ToList(DominioSinalizacoesHorizontaisTiposViewModel model, List<DominioSinalizacoesHorizontaisTiposViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioSinalizacoesHorizontaisTiposViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioSinalizacoesHorizontaisTiposViewModel>();
            }
        }

        private DominioSinalizacoesHorizontaisTipos ViewModelToModel(DominioSinalizacoesHorizontaisTiposViewModel model)
        {
            try
            {
                var retorno = new DominioSinalizacoesHorizontaisTipos();
                retorno.sht_id = model.sht_id;
                retorno.sht_tipo = model.sht_tipo;
                retorno.sht_descricao = model.sht_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioSinalizacoesHorizontaisTipos();
            }
        }

        private DominioSinalizacoesHorizontaisTiposViewModel ViewModelToModel(DominioSinalizacoesHorizontaisTipos model)
        {
            try
            {
                var retorno = new DominioSinalizacoesHorizontaisTiposViewModel();
                retorno.sht_id = model.sht_id;
                retorno.sht_tipo = model.sht_tipo;
                retorno.sht_descricao = model.sht_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioSinalizacoesHorizontaisTipos();
            }
        }
    }

}