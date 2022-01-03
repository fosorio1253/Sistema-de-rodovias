using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class UfespBLL
    {
        private DerContext context;
        private UfespDAO ufespDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            ufespDAO = new UfespDAO(context);
        }

        public bool Save(UfespViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.ufesp_id) ?
                    ufespDAO.Update(model) :
                    ufespDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<UfespViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<UfespViewModel>();
            }
        }

        public List<Ufesp> Load()
        {
            try
            {
                return ufespDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<Ufesp>();
            }
        }

        public bool Remove(UfespViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.ufesp_id) ?
                    ufespDAO.Delete(model) : false;
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
                return Load().Any(x => x.ufesp_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<UfespViewModel> ToList(UfespViewModel model, List<UfespViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<UfespViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<UfespViewModel>();
            }
        }

        private Ufesp ViewModelToModel(UfespViewModel model)
        {
            try
            {
                var retorno = new Ufesp();
                retorno.ufesp_id = model.ufesp_id;
                retorno.mes_ano = model.mes_ano;
                retorno.valor = model.valor;
                retorno.p_calculado = model.p_calculado;

                return retorno;
            }
            catch (Exception e)
            {
                return new Ufesp();
            }
        }

        private UfespViewModel ViewModelToModel(Ufesp model)
        {
            try
            {
                var retorno = new UfespViewModel();
                retorno.ufesp_id = model.ufesp_id;
                retorno.mes_ano = model.mes_ano;
                retorno.valor = model.valor;
                retorno.p_calculado = model.p_calculado;

                return retorno;
            }
            catch (Exception e)
            {
                return new Ufesp();
            }
        }
    }

}