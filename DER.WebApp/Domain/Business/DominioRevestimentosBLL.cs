using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class DominioRevestimentosBLL
    {
        private DerContext context;
        private DominioRevestimentosDAO dominiorevestimentosDAO;

        public DominioRevestimentosBLL()
        {
            context = new DerContext();
            dominiorevestimentosDAO = new DominioRevestimentosDAO(context);
        }

        public bool Save(DominioRevestimentosViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rev_id) ?
                    dominiorevestimentosDAO.Update(model) :
                    dominiorevestimentosDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(DominioRevestimentos model)
        {
            try
            {
                return ExistsById(model.rev_id) ?
                    dominiorevestimentosDAO.Update(model) :
                    dominiorevestimentosDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioRevestimentosViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioRevestimentosViewModel>();
            }
        }

        public List<DominioRevestimentos> Load()
        {
            try
            {
                return dominiorevestimentosDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioRevestimentos>();
            }
        }

        public bool Remove(DominioRevestimentosViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rev_id) ?
                    dominiorevestimentosDAO.Delete(model) : false;
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
                return Load().Any(x => x.rev_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioRevestimentosViewModel> ToList(DominioRevestimentosViewModel model, List<DominioRevestimentosViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioRevestimentosViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioRevestimentosViewModel>();
            }
        }

        private DominioRevestimentos ViewModelToModel(DominioRevestimentosViewModel model)
        {
            try
            {
                var retorno = new DominioRevestimentos();
                retorno.rev_id = model.rev_id;
                retorno.rev_objeto = model.rev_objeto;
                retorno.rev_sigla = model.rev_sigla;
                retorno.rev_descricao = model.rev_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioRevestimentos();
            }
        }

        private DominioRevestimentosViewModel ModelToViewModel(DominioRevestimentos model)
        {
            try
            {
                var retorno = new DominioRevestimentosViewModel();
                retorno.rev_id = model.rev_id;
                retorno.rev_objeto = model.rev_objeto;
                retorno.rev_sigla = model.rev_sigla;
                retorno.rev_descricao = model.rev_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioRevestimentosViewModel();
            }
        }
    }

}