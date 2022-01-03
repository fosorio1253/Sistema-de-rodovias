using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class DominioRodoviasTiposBLL
    {
        private DerContext context;
        private DominioRodoviasTiposDAO dominiorodoviastiposDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            dominiorodoviastiposDAO = new DominioRodoviasTiposDAO(context);
        }

        public bool Save(DominioRodoviasTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rtp_id) ?
                    dominiorodoviastiposDAO.Update(model) :
                    dominiorodoviastiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioRodoviasTiposViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioRodoviasTiposViewModel>();
            }
        }

        public List<DominioRodoviasTipos> Load()
        {
            try
            {
                return dominiorodoviastiposDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioRodoviasTipos>();
            }
        }

        public bool Remove(DominioRodoviasTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rtp_id) ?
                    dominiorodoviastiposDAO.Delete(model) : false;
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
                return Load().Any(x => x.rtp_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioRodoviasTiposViewModel> ToList(DominioRodoviasTiposViewModel model, List<DominioRodoviasTiposViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioRodoviasTiposViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioRodoviasTiposViewModel>();
            }
        }

        private DominioRodoviasTipos ViewModelToModel(DominioRodoviasTiposViewModel model)
        {
            try
            {
                var retorno = new DominioRodoviasTipos();
                retorno.rtp_id = model.rtp_id;
                retorno.rtp_descricao = model.rtp_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioRodoviasTipos();
            }
        }

        private DominioRodoviasTiposViewModel ViewModelToModel(DominioRodoviasTipos model)
        {
            try
            {
                var retorno = new DominioRodoviasTiposViewModel();
                retorno.rtp_id = model.rtp_id;
                retorno.rtp_descricao = model.rtp_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioRodoviasTipos();
            }
        }
    }

}