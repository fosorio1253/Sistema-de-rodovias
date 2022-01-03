using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class DominioEdificacoesTiposBLL
    {
        private DerContext context;
        private DominioEdificacoesTiposDAO dominioedificacoestiposDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            dominioedificacoestiposDAO = new DominioEdificacoesTiposDAO(context);
        }

        public bool Save(DominioEdificacoesTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.edt_id) ?
                    dominioedificacoestiposDAO.Update(model) :
                    dominioedificacoestiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioEdificacoesTiposViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioEdificacoesTiposViewModel>();
            }
        }

        public List<DominioEdificacoesTipos> Load()
        {
            try
            {
                return dominioedificacoestiposDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioEdificacoesTipos>();
            }
        }

        public bool Remove(DominioEdificacoesTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.edt_id) ?
                    dominioedificacoestiposDAO.Delete(model) : false;
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
                return Load().Any(x => x.edt_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioEdificacoesTiposViewModel> ToList(DominioEdificacoesTiposViewModel model, List<DominioEdificacoesTiposViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioEdificacoesTiposViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioEdificacoesTiposViewModel>();
            }
        }

        private DominioEdificacoesTipos ViewModelToModel(DominioEdificacoesTiposViewModel model)
        {
            try
            {
                var retorno = new DominioEdificacoesTipos();
                retorno.edt_id = model.edt_id;
                retorno.edt_descricao = model.edt_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioEdificacoesTipos();
            }
        }

        private DominioEdificacoesTiposViewModel ViewModelToModel(DominioEdificacoesTipos model)
        {
            try
            {
                var retorno = new DominioEdificacoesTiposViewModel();
                retorno.edt_id = model.edt_id;
                retorno.edt_descricao = model.edt_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioEdificacoesTipos();
            }
        }
    }

}