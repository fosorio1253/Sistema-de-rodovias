using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class DominioGradacoesBLL
    {
        private DerContext context;
        private DominioGradacoesDAO dominiogradacoesDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            dominiogradacoesDAO = new DominioGradacoesDAO(context);
        }

        public bool Save(DominioGradacoesViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.gra_id) ?
                    dominiogradacoesDAO.Update(model) :
                    dominiogradacoesDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioGradacoesViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioGradacoesViewModel>();
            }
        }

        public List<DominioGradacoes> Load()
        {
            try
            {
                return dominiogradacoesDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioGradacoes>();
            }
        }

        public bool Remove(DominioGradacoesViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.gra_id) ?
                    dominiogradacoesDAO.Delete(model) : false;
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
                return Load().Any(x => x.gra_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioGradacoesViewModel> ToList(DominioGradacoesViewModel model, List<DominioGradacoesViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioGradacoesViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioGradacoesViewModel>();
            }
        }

        private DominioGradacoes ViewModelToModel(DominioGradacoesViewModel model)
        {
            try
            {
                var retorno = new DominioGradacoes();
                retorno.gra_id = model.gra_id;
                retorno.gra_objeto = model.gra_objeto;
                retorno.gra_descricao = model.gra_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioGradacoes();
            }
        }

        private DominioGradacoesViewModel ViewModelToModel(DominioGradacoes model)
        {
            try
            {
                var retorno = new DominioGradacoesViewModel();
                retorno.gra_id = model.gra_id;
                retorno.gra_objeto = model.gra_objeto;
                retorno.gra_descricao = model.gra_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioGradacoes();
            }
        }
    }

}