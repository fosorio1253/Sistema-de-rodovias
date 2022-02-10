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
                var model = ConvertModel(viewModel);

                return ExistsById(model.municipio_id) ?
                    municipioDAO.Update(model) :
                    municipioDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(List<DadoMestreTabelaValoresViewModel> viewModel)
        {
            try
            {
                var model = ConvertModel(ConvertModel(viewModel));

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
                return Load().Select(x => ConvertModel(x)).ToList();
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
                var model = ConvertModel(viewModel);
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

        private Municipio ConvertModel(MunicipioViewModel model)
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

        private MunicipioViewModel ConvertModel(Municipio model)
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

        private MunicipioViewModel ConvertModel(List<DadoMestreTabelaValoresViewModel> lmodel)
        {
            try
            {
                return new MunicipioViewModel()
                {
                    municipio_id = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("municipio_id")).Select(y => y.valor).FirstOrDefault()),
                    municipio = lmodel.Where(y => y.nome_coluna.Equals("municipio")).Select(y => y.valor).FirstOrDefault(),
                    regional = lmodel.Where(y => y.nome_coluna.Equals("regional")).Select(y => y.valor).FirstOrDefault(),
                    codigo = lmodel.Where(y => y.nome_coluna.Equals("codigo")).Select(y => y.valor).FirstOrDefault()
                };
            }
            catch (Exception e)
            {
                return new MunicipioViewModel();
            }
        }
    }

}