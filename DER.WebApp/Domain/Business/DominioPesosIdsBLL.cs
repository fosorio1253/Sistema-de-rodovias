using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class DominioPesosIdsBLL
    {
        private DerContext context;
        private DominioPesosIdsDAO dominiopesosidsDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            dominiopesosidsDAO = new DominioPesosIdsDAO(context);
        }

        public bool Save(DominioPesosIdsViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.dominio_pesos_id) ?
                    dominiopesosidsDAO.Update(model) :
                    dominiopesosidsDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioPesosIdsViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioPesosIdsViewModel>();
            }
        }

        public List<DominioPesosIds> Load()
        {
            try
            {
                return dominiopesosidsDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioPesosIds>();
            }
        }

        public bool Remove(DominioPesosIdsViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.dominio_pesos_id) ?
                    dominiopesosidsDAO.Delete(model) : false;
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
                return Load().Any(x => x.dominio_pesos_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioPesosIdsViewModel> ToList(DominioPesosIdsViewModel model, List<DominioPesosIdsViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioPesosIdsViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioPesosIdsViewModel>();
            }
        }

        private DominioPesosIds ViewModelToModel(DominioPesosIdsViewModel model)
        {
            try
            {
                var retorno = new DominioPesosIds();
                retorno.dominio_pesos_id = model.dominio_pesos_id;
                retorno.pes_anomalia = model.pes_anomalia;
                retorno.pes_severidade = model.pes_severidade;
                retorno.pes_nota = model.pes_nota;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioPesosIds();
            }
        }

        private DominioPesosIdsViewModel ViewModelToModel(DominioPesosIds model)
        {
            try
            {
                var retorno = new DominioPesosIdsViewModel();
                retorno.dominio_pesos_id = model.dominio_pesos_id;
                retorno.pes_anomalia = model.pes_anomalia;
                retorno.pes_severidade = model.pes_severidade;
                retorno.pes_nota = model.pes_nota;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioPesosIds();
            }
        }
    }

}