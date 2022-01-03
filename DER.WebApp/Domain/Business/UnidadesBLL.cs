using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class UnidadeBLL
    {
        private DerContext context;
        private UnidadeDAO unidadeDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            unidadeDAO = new UnidadeDAO(context);
        }

        public bool Save(UnidadeViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.unidade_id) ?
                    unidadeDAO.Update(model) :
                    unidadeDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<UnidadeViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<UnidadeViewModel>();
            }
        }

        public List<Unidade> Load()
        {
            try
            {
                return unidadeDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<Unidade>();
            }
        }

        public bool Remove(UnidadeViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.unidade_id) ?
                    unidadeDAO.Delete(model) : false;
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
                return Load().Any(x => x.unidade_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<UnidadeViewModel> ToList(UnidadeViewModel model, List<UnidadeViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<UnidadeViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<UnidadeViewModel>();
            }
        }

        private Unidade ViewModelToModel(UnidadeViewModel model)
        {
            try
            {
                var retorno = new Unidade();
                retorno.unidade_id = model.unidade_id;
                retorno.sigla = model.sigla;
                retorno.nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new Unidade();
            }
        }

        private UnidadeViewModel ViewModelToModel(Unidade model)
        {
            try
            {
                var retorno = new UnidadeViewModel();
                retorno.unidade_id = model.unidade_id;
                retorno.sigla = model.sigla;
                retorno.nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new Unidade();
            }
        }
    }

}