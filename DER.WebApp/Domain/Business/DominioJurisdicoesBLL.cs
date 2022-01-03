using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class DominioJurisdicoesBLL
    {
        private DerContext context;
        private DominioJurisdicoesDAO dominiojurisdicoesDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            dominiojurisdicoesDAO = new DominioJurisdicoesDAO(context);
        }

        public bool Save(DominioJurisdicoesViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.jur_id) ?
                    dominiojurisdicoesDAO.Update(model) :
                    dominiojurisdicoesDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioJurisdicoesViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioJurisdicoesViewModel>();
            }
        }

        public List<DominioJurisdicoes> Load()
        {
            try
            {
                return dominiojurisdicoesDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioJurisdicoes>();
            }
        }

        public bool Remove(DominioJurisdicoesViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.jur_id) ?
                    dominiojurisdicoesDAO.Delete(model) : false;
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
                return Load().Any(x => x.jur_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioJurisdicoesViewModel> ToList(DominioJurisdicoesViewModel model, List<DominioJurisdicoesViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioJurisdicoesViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioJurisdicoesViewModel>();
            }
        }

        private DominioJurisdicoes ViewModelToModel(DominioJurisdicoesViewModel model)
        {
            try
            {
                var retorno = new DominioJurisdicoes();
                retorno.jur_id = model.jur_id;
                retorno.jur_descricao = model.jur_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioJurisdicoes();
            }
        }

        private DominioJurisdicoesViewModel ViewModelToModel(DominioJurisdicoes model)
        {
            try
            {
                var retorno = new DominioJurisdicoesViewModel();
                retorno.jur_id = model.jur_id;
                retorno.jur_descricao = model.jur_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioJurisdicoes();
            }
        }
    }

}