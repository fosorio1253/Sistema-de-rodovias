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
    public class DominioRodoviassentidosBLL
    {
        private DerContext context;
        private DominioRodoviassentidosDAO dominiorodoviassentidosDAO;

        public DominioRodoviassentidosBLL()
        {
            context = new DerContext();
            dominiorodoviassentidosDAO = new DominioRodoviassentidosDAO(context);
        }

        public bool Save(DominioRodoviassentidosViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.sen_id) ?
                    dominiorodoviassentidosDAO.Update(model) :
                    dominiorodoviassentidosDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(DominioRodoviassentidos model)
        {
            try
            {
                return ExistsById(model.sen_id) ?
                    dominiorodoviassentidosDAO.Update(model) :
                    dominiorodoviassentidosDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioRodoviassentidosViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioRodoviassentidosViewModel>();
            }
        }

        public List<DominioRodoviassentidos> Load()
        {
            try
            {
                return dominiorodoviassentidosDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioRodoviassentidos>();
            }
        }

        public bool Remove(DominioRodoviassentidosViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.sen_id) ?
                    dominiorodoviassentidosDAO.Delete(model) : false;
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
                return Load().Any(x => x.sen_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioRodoviassentidosViewModel> ToList(DominioRodoviassentidosViewModel model, List<DominioRodoviassentidosViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioRodoviassentidosViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioRodoviassentidosViewModel>();
            }
        }

        private DominioRodoviassentidos ViewModelToModel(DominioRodoviassentidosViewModel model)
        {
            try
            {
                var retorno = new DominioRodoviassentidos();
                retorno.sen_id = model.sen_id;
                retorno.sen_descricao = model.sen_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioRodoviassentidos();
            }
        }

        private DominioRodoviassentidosViewModel ModelToViewModel(DominioRodoviassentidos model)
        {
            try
            {
                var retorno = new DominioRodoviassentidosViewModel();
                retorno.sen_id = model.sen_id;
                retorno.sen_descricao = model.sen_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioRodoviassentidosViewModel();
            }
        }
    }

}