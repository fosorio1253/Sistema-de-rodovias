using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class DominioHidraulicaPosicoesBLL
    {
        private DerContext context;
        private DominioHidraulicaPosicoesDAO dominiohidraulicaposicoesDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            dominiohidraulicaposicoesDAO = new DominioHidraulicaPosicoesDAO(context);
        }

        public bool Save(DominioHidraulicaPosicoesViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.hps_id) ?
                    dominiohidraulicaposicoesDAO.Update(model) :
                    dominiohidraulicaposicoesDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioHidraulicaPosicoesViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioHidraulicaPosicoesViewModel>();
            }
        }

        public List<DominioHidraulicaPosicoes> Load()
        {
            try
            {
                return dominiohidraulicaposicoesDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioHidraulicaPosicoes>();
            }
        }

        public bool Remove(DominioHidraulicaPosicoesViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.hps_id) ?
                    dominiohidraulicaposicoesDAO.Delete(model) : false;
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
                return Load().Any(x => x.hps_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioHidraulicaPosicoesViewModel> ToList(DominioHidraulicaPosicoesViewModel model, List<DominioHidraulicaPosicoesViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioHidraulicaPosicoesViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioHidraulicaPosicoesViewModel>();
            }
        }

        private DominioHidraulicaPosicoes ViewModelToModel(DominioHidraulicaPosicoesViewModel model)
        {
            try
            {
                var retorno = new DominioHidraulicaPosicoes();
                retorno.hps_id = model.hps_id;
                retorno.hps_descricao = model.hps_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioHidraulicaPosicoes();
            }
        }

        private DominioHidraulicaPosicoesViewModel ViewModelToModel(DominioHidraulicaPosicoes model)
        {
            try
            {
                var retorno = new DominioHidraulicaPosicoesViewModel();
                retorno.hps_id = model.hps_id;
                retorno.hps_descricao = model.hps_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioHidraulicaPosicoes();
            }
        }
    }

}