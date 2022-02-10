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
    public class PiBLL
    {
        private DerContext context;
        private PiDAO piDAO;

        public PiBLL()
        {
            context = new DerContext();
            piDAO = new PiDAO(context);
        }

        public bool Save(PiViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.pi_id) ?
                    piDAO.Update(model) :
                    piDAO.Inserir(model);
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

                return ExistsById(model.pi_id) ?
                    piDAO.Update(model) :
                    piDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<PiViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<PiViewModel>();
            }
        }

        public List<Pi> Load()
        {
            try
            {
                return piDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<Pi>();
            }
        }

        public bool Remove(PiViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.pi_id) ?
                    piDAO.Delete(model) : false;
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
                return Load().Any(x => x.pi_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<PiViewModel> ToList(PiViewModel model, List<PiViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<PiViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<PiViewModel>();
            }
        }

        private Pi ConvertModel(PiViewModel model)
        {
            try
            {
                var retorno = new Pi();
                retorno.pi_id = model.pi_id;
                retorno.Mes_Ano = model.Mes_Ano;
                retorno.Valor_PI = model.Valor_PI;

                return retorno;
            }
            catch (Exception e)
            {
                return new Pi();
            }
        }

        private PiViewModel ConvertModel(Pi model)
        {
            try
            {
                var retorno = new PiViewModel();
                retorno.pi_id = model.pi_id;
                retorno.Mes_Ano = model.Mes_Ano;
                retorno.Valor_PI = model.Valor_PI;

                return retorno;
            }
            catch (Exception e)
            {
                return new PiViewModel();
            }
        }

        private PiViewModel ConvertModel(List<DadoMestreTabelaValoresViewModel> lmodel)
        {
            try
            {
                return new PiViewModel()
                {
                    pi_id = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("pi_id")).Select(y => y.valor).FirstOrDefault()),
                    Mes_Ano = Convert.ToDateTime(lmodel.Where(y => y.nome_coluna.Equals("Mes_Ano")).Select(y => y.valor).FirstOrDefault()),
                    Valor_PI = Convert.ToDouble(lmodel.Where(y => y.nome_coluna.Equals("Valor_PI")).Select(y => y.valor).FirstOrDefault())
                };
            }
            catch (Exception e)
            {
                return new PiViewModel();
            }
        }
    }

}