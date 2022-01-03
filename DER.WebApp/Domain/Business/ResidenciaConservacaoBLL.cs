﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class ResidenciaConservacaoBLL
    {
        private DerContext context;
        private ResidenciaConservacaoDAO residenciaconservacaoDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            residenciaconservacaoDAO = new ResidenciaConservacaoDAO(context);
        }

        public bool Save(ResidenciaConservacaoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.residencia_conservacao_id) ?
                    residenciaconservacaoDAO.Update(model) :
                    residenciaconservacaoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<ResidenciaConservacaoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<ResidenciaConservacaoViewModel>();
            }
        }

        public List<ResidenciaConservacao> Load()
        {
            try
            {
                return residenciaconservacaoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<ResidenciaConservacao>();
            }
        }

        public bool Remove(ResidenciaConservacaoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.residencia_conservacao_id) ?
                    residenciaconservacaoDAO.Delete(model) : false;
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
                return Load().Any(x => x.residencia_conservacao_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<ResidenciaConservacaoViewModel> ToList(ResidenciaConservacaoViewModel model, List<ResidenciaConservacaoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<ResidenciaConservacaoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<ResidenciaConservacaoViewModel>();
            }
        }

        private ResidenciaConservacao ViewModelToModel(ResidenciaConservacaoViewModel model)
        {
            try
            {
                var retorno = new ResidenciaConservacao();
                retorno.residencia_conservacao_id = model.residencia_conservacao_id;
                retorno.Nome = model.Nome;
                retorno.Sigla = model.Sigla;

                return retorno;
            }
            catch (Exception e)
            {
                return new ResidenciaConservacao();
            }
        }

        private ResidenciaConservacaoViewModel ViewModelToModel(ResidenciaConservacao model)
        {
            try
            {
                var retorno = new ResidenciaConservacaoViewModel();
                retorno.residencia_conservacao_id = model.residencia_conservacao_id;
                retorno.Nome = model.Nome;
                retorno.Sigla = model.Sigla;

                return retorno;
            }
            catch (Exception e)
            {
                return new ResidenciaConservacao();
            }
        }
    }

}