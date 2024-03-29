﻿using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class RodoviasBLL
    {
        private DerContext context;
        private RodoviasDAO rodoviaDAO;

        public RodoviasBLL()
        {
            context = new DerContext();
            rodoviaDAO = new RodoviasDAO(context);
        }

        public bool Save(RodoviaViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.rodovia_id) ?
                    rodoviaDAO.Update(model) :
                    rodoviaDAO.Inserir(model);
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

                return ExistsById(model.rodovia_id) ?
                    rodoviaDAO.Update(model) :
                    rodoviaDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(Rodovia model)
        {
            try
            {
                return ExistsById(model.rodovia_id) ?
                    rodoviaDAO.Update(model) :
                    rodoviaDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SaveAPI(DominioRodovia model)
        {
            try
            {
                return ExistsByRodId(model.rod_id) ?
                    rodoviaDAO.Update(APIToViewModel(model)) :
                    rodoviaDAO.Inserir(APIToViewModel(model));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<RodoviaViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<RodoviaViewModel>();
            }
        }

        public List<Rodovia> Load()
        {
            try
            {
                return rodoviaDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<Rodovia>();
            }
        }

        public bool Remove(RodoviaViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.rodovia_id) ?
                    rodoviaDAO.Delete(model) : false;
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
                return Load().Any(x => x.rodovia_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool ExistsByRodId(int id)
        {
            try
            {
                return Load().Any(x => x.rod_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<RodoviaViewModel> ToList(RodoviaViewModel model, List<RodoviaViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<RodoviaViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<RodoviaViewModel>();
            }
        }

        private Rodovia ConvertModel(RodoviaViewModel model)
        {
            try
            {
                var retorno = new Rodovia();
                retorno.rodovia_id = model.rodovia_id;
                retorno.rod_codigo = model.rod_codigo;
                retorno.Nome = model.Nome;
                retorno.rod_id = model.rod_id;
                retorno.jur_id_origem = model.jur_id_origem;
                retorno.rte_id = model.rte_id;
                retorno.ror_id = model.ror_id;
                retorno.rod_km_inicial = model.rod_km_inicial;
                retorno.rod_km_final = model.rod_km_final;
                retorno.rod_km_extensao = model.rod_km_extensao;

                return retorno;
            }
            catch (Exception e)
            {
                return new Rodovia();
            }
        }

        private RodoviaViewModel ConvertModel(Rodovia model)
        {
            try
            {
                var retorno = new RodoviaViewModel();
                retorno.rodovia_id = model.rodovia_id;
                retorno.rod_codigo = model.rod_codigo;
                retorno.Nome = model.Nome;
                retorno.rod_id = model.rod_id;
                retorno.jur_id_origem = model.jur_id_origem;
                retorno.rte_id = model.rte_id;
                retorno.ror_id = model.ror_id;
                retorno.rod_km_inicial = model.rod_km_inicial;
                retorno.rod_km_final = model.rod_km_final;
                retorno.rod_km_extensao = model.rod_km_extensao;

                return retorno;
            }
            catch (Exception e)
            {
                return new RodoviaViewModel();
            }
        }

        private RodoviaViewModel ConvertModel(List<DadoMestreTabelaValoresViewModel> lmodel)
        {
            try
            {
                return new RodoviaViewModel()
                {
                    rodovia_id = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("rodovia_id")).Select(y => y.valor).FirstOrDefault()),
                    Nome = lmodel.Where(y => y.nome_coluna.Equals("Nome")).Select(y => y.valor).FirstOrDefault(),
                    jur_id_origem = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("jur_id_origem")).Select(y => y.valor).FirstOrDefault()),
                    rod_codigo = lmodel.Where(y => y.nome_coluna.Equals("rod_codigo")).Select(y => y.valor).FirstOrDefault(),
                    rod_id = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("rod_id")).Select(y => y.valor).FirstOrDefault()),
                    rod_km_extensao = Convert.ToDouble(lmodel.Where(y => y.nome_coluna.Equals("rod_km_extensao")).Select(y => y.valor).FirstOrDefault()),
                    rod_km_final = Convert.ToDouble(lmodel.Where(y => y.nome_coluna.Equals("rod_km_final")).Select(y => y.valor).FirstOrDefault()),
                    rod_km_inicial = Convert.ToDouble(lmodel.Where(y => y.nome_coluna.Equals("rod_km_inicial")).Select(y => y.valor).FirstOrDefault()),
                    ror_id = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("ror_id")).Select(y => y.valor).FirstOrDefault()),
                    rte_id = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("rte_id")).Select(y => y.valor).FirstOrDefault())
                };
            }
            catch (Exception e)
            {
                return new RodoviaViewModel();
            }
        }

        private Rodovia APIToViewModel(DominioRodovia model)
        {
            try
            {
                var retorno = new Rodovia();
                retorno.rod_codigo = model.rod_codigo;
                retorno.rod_id = model.rod_id;
                retorno.jur_id_origem = model.jur_id_origem;
                retorno.rte_id = model.rte_id;
                retorno.ror_id = model.ror_id;
                retorno.rod_km_inicial = model.rod_km_inicial;
                retorno.rod_km_final = model.rod_km_final;
                retorno.rod_km_extensao = model.rod_km_extensao;

                return retorno;
            }
            catch (Exception e)
            {
                return new Rodovia();
            }
        }
    }

}