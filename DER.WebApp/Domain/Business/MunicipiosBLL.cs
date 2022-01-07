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
    public class MunicipiosBLL
    {
        private DerContext context;
        private MunicipioDAO municipioDAO;

        public MunicipiosBLL()
        {
            context = new DerContext();
            municipioDAO = new MunicipioDAO(context);
        }

        public bool Save(MunicipioViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.municipio_id) ?
                    municipioDAO.Update(model) :
                    municipioDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<MunicipioViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<MunicipioViewModel>();
            }
        }

        public List<Municipio> Load()
        {
            try
            {
                return municipioDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<Municipio>();
            }
        }

        public bool Remove(MunicipioViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.municipio_id) ?
                    municipioDAO.Delete(model) : false;
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
                return Load().Any(x => x.municipio_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<MunicipioViewModel> ToList(MunicipioViewModel model, List<MunicipioViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<MunicipioViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<MunicipioViewModel>();
            }
        }

        private Municipio ViewModelToModel(MunicipioViewModel model)
        {
            try
            {
                var retorno = new Municipio();
                retorno.municipio_id = model.municipio_id;
                retorno.codigo = model.codigo;
                retorno.municipio = model.municipio;
                retorno.regional = model.regional;

                return retorno;
            }
            catch (Exception e)
            {
                return new Municipio();
            }
        }

        private MunicipioViewModel ModelToViewModel(Municipio model)
        {
            try
            {
                var retorno = new MunicipioViewModel();
                retorno.municipio_id = model.municipio_id;
                retorno.codigo = model.codigo;
                retorno.municipio = model.municipio;
                retorno.regional = model.regional;

                return retorno;
            }
            catch (Exception e)
            {
                return new MunicipioViewModel();
            }
        }
    }

}