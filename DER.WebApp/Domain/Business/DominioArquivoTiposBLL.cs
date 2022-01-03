using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class DominioArquivoTiposBLL
    {
        private DerContext context;
        private DominioArquivoTiposDAO dominioarquivotiposDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            dominioarquivotiposDAO = new DominioArquivoTiposDAO(context);
        }

        public bool Save(DominioArquivoTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.arq_id) ?
                    dominioarquivotiposDAO.Update(model) :
                    dominioarquivotiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioArquivoTiposViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioArquivoTiposViewModel>();
            }
        }

        public List<DominioArquivoTipos> Load()
        {
            try
            {
                return dominioarquivotiposDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioArquivoTipos>();
            }
        }

        public bool Remove(DominioArquivoTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.arq_id) ?
                    dominioarquivotiposDAO.Delete(model) : false;
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
                return Load().Any(x => x.arq_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioArquivoTiposViewModel> ToList(DominioArquivoTiposViewModel model, List<DominioArquivoTiposViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioArquivoTiposViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioArquivoTiposViewModel>();
            }
        }

        private DominioArquivoTipos ViewModelToModel(DominioArquivoTiposViewModel model)
        {
            try
            {
                var retorno = new DominioArquivoTipos();
                retorno.arq_id = model.arq_id;
                retorno.1 = model.1;
                retorno.arq_codigo = model.arq_codigo;
                retorno.arq_descricao = model.arq_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioArquivoTipos();
            }
        }

        private DominioArquivoTiposViewModel ViewModelToModel(DominioArquivoTipos model)
        {
            try
            {
                var retorno = new DominioArquivoTiposViewModel();
                retorno.arq_id = model.arq_id;
                retorno.1 = model.1;
                retorno.arq_codigo = model.arq_codigo;
                retorno.arq_descricao = model.arq_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioArquivoTipos();
            }
        }
    }

}