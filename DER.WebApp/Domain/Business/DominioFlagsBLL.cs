using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class DominioFlagsBLL
    {
        private DerContext context;
        private DominioFlagsDAO dominioflagsDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            dominioflagsDAO = new DominioFlagsDAO(context);
        }

        public bool Save(DominioFlagsViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.fla_id) ?
                    dominioflagsDAO.Update(model) :
                    dominioflagsDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioFlagsViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioFlagsViewModel>();
            }
        }

        public List<DominioFlags> Load()
        {
            try
            {
                return dominioflagsDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioFlags>();
            }
        }

        public bool Remove(DominioFlagsViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.fla_id) ?
                    dominioflagsDAO.Delete(model) : false;
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
                return Load().Any(x => x.fla_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioFlagsViewModel> ToList(DominioFlagsViewModel model, List<DominioFlagsViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioFlagsViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioFlagsViewModel>();
            }
        }

        private DominioFlags ViewModelToModel(DominioFlagsViewModel model)
        {
            try
            {
                var retorno = new DominioFlags();
                retorno.fla_id = model.fla_id;
                retorno.fla_descricao = model.fla_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioFlags();
            }
        }

        private DominioFlagsViewModel ViewModelToModel(DominioFlags model)
        {
            try
            {
                var retorno = new DominioFlagsViewModel();
                retorno.fla_id = model.fla_id;
                retorno.fla_descricao = model.fla_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioFlags();
            }
        }
    }

}