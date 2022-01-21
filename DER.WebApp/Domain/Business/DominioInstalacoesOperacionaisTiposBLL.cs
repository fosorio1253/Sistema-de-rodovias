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
    public class DominioInstalacoesOperacionaisTiposBLL
    {
        private DerContext context;
        private DominioInstalacoesOperacionaisTiposDAO dominioinstalacoesoperacionaistiposDAO;

        public DominioInstalacoesOperacionaisTiposBLL()
        {
            context = new DerContext();
            dominioinstalacoesoperacionaistiposDAO = new DominioInstalacoesOperacionaisTiposDAO(context);
        }

        public bool Save(DominioInstalacoesOperacionaisTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.iot_id) ?
                    dominioinstalacoesoperacionaistiposDAO.Update(model) :
                    dominioinstalacoesoperacionaistiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(DominioInstalacoesOperacionaisTipos model)
        {
            try
            {
                return ExistsById(model.iot_id) ?
                    dominioinstalacoesoperacionaistiposDAO.Update(model) :
                    dominioinstalacoesoperacionaistiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioInstalacoesOperacionaisTiposViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioInstalacoesOperacionaisTiposViewModel>();
            }
        }

        public List<DominioInstalacoesOperacionaisTipos> Load()
        {
            try
            {
                return dominioinstalacoesoperacionaistiposDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioInstalacoesOperacionaisTipos>();
            }
        }

        public bool Remove(DominioInstalacoesOperacionaisTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.iot_id) ?
                    dominioinstalacoesoperacionaistiposDAO.Delete(model) : false;
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
                return Load().Any(x => x.iot_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioInstalacoesOperacionaisTiposViewModel> ToList(DominioInstalacoesOperacionaisTiposViewModel model, List<DominioInstalacoesOperacionaisTiposViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioInstalacoesOperacionaisTiposViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioInstalacoesOperacionaisTiposViewModel>();
            }
        }

        private DominioInstalacoesOperacionaisTipos ViewModelToModel(DominioInstalacoesOperacionaisTiposViewModel model)
        {
            try
            {
                var retorno = new DominioInstalacoesOperacionaisTipos();
                retorno.iot_id = model.iot_id;
                retorno.iot_descricao = model.iot_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioInstalacoesOperacionaisTipos();
            }
        }

        private DominioInstalacoesOperacionaisTiposViewModel ModelToViewModel(DominioInstalacoesOperacionaisTipos model)
        {
            try
            {
                var retorno = new DominioInstalacoesOperacionaisTiposViewModel();
                retorno.iot_id = model.iot_id;
                retorno.iot_descricao = model.iot_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioInstalacoesOperacionaisTiposViewModel();
            }
        }
    }

}