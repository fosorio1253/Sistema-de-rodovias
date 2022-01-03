using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class DominioSensoresEletronicosTiposBLL
    {
        private DerContext context;
        private DominioSensoresEletronicosTiposDAO dominiosensoreseletronicostiposDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            dominiosensoreseletronicostiposDAO = new DominioSensoresEletronicosTiposDAO(context);
        }

        public bool Save(DominioSensoresEletronicosTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.set_id) ?
                    dominiosensoreseletronicostiposDAO.Update(model) :
                    dominiosensoreseletronicostiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioSensoresEletronicosTiposViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioSensoresEletronicosTiposViewModel>();
            }
        }

        public List<DominioSensoresEletronicosTipos> Load()
        {
            try
            {
                return dominiosensoreseletronicostiposDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioSensoresEletronicosTipos>();
            }
        }

        public bool Remove(DominioSensoresEletronicosTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.set_id) ?
                    dominiosensoreseletronicostiposDAO.Delete(model) : false;
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
                return Load().Any(x => x.set_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioSensoresEletronicosTiposViewModel> ToList(DominioSensoresEletronicosTiposViewModel model, List<DominioSensoresEletronicosTiposViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioSensoresEletronicosTiposViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioSensoresEletronicosTiposViewModel>();
            }
        }

        private DominioSensoresEletronicosTipos ViewModelToModel(DominioSensoresEletronicosTiposViewModel model)
        {
            try
            {
                var retorno = new DominioSensoresEletronicosTipos();
                retorno.set_id = model.set_id;
                retorno.set_descricao = model.set_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioSensoresEletronicosTipos();
            }
        }

        private DominioSensoresEletronicosTiposViewModel ViewModelToModel(DominioSensoresEletronicosTipos model)
        {
            try
            {
                var retorno = new DominioSensoresEletronicosTiposViewModel();
                retorno.set_id = model.set_id;
                retorno.set_descricao = model.set_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioSensoresEletronicosTipos();
            }
        }
    }

}