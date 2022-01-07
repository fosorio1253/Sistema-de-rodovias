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
    public class DominioRegionaisBLL
    {
        private DerContext context;
        private DominioRegionaisDAO dominioregionaisDAO;

        public DominioRegionaisBLL()
        {
            context = new DerContext();
            dominioregionaisDAO = new DominioRegionaisDAO(context);
        }

        public bool Save(DominioRegionaisViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.reg_id) ?
                    dominioregionaisDAO.Update(model) :
                    dominioregionaisDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioRegionaisViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioRegionaisViewModel>();
            }
        }

        public List<DominioRegionais> Load()
        {
            try
            {
                return dominioregionaisDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioRegionais>();
            }
        }

        public bool Remove(DominioRegionaisViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.reg_id) ?
                    dominioregionaisDAO.Delete(model) : false;
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
                return Load().Any(x => x.reg_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioRegionaisViewModel> ToList(DominioRegionaisViewModel model, List<DominioRegionaisViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioRegionaisViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioRegionaisViewModel>();
            }
        }

        private DominioRegionais ViewModelToModel(DominioRegionaisViewModel model)
        {
            try
            {
                var retorno = new DominioRegionais();
                retorno.reg_id = model.reg_id;
                retorno.reg_codigo = model.reg_codigo;
                retorno.mun_ibge_id = model.mun_ibge_id;
                retorno.reg_descricao = model.reg_descricao;
                retorno.reg_endereco = model.reg_endereco;
                retorno.reg_bairro = model.reg_bairro;
                retorno.reg_cep = model.reg_cep;
                retorno.reg_ddd_telefone = model.reg_ddd_telefone;
                retorno.reg_telefone = model.reg_telefone;
                retorno.reg_email = model.reg_email;
                retorno.reg_diretor = model.reg_diretor;
                retorno.reg_email_diretor = model.reg_email_diretor;
                retorno.reg_ddd_telefone_cco = model.reg_ddd_telefone_cco;
                retorno.reg_telefone_cco = model.reg_telefone_cco;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioRegionais();
            }
        }

        private DominioRegionaisViewModel ModelToViewModel(DominioRegionais model)
        {
            try
            {
                var retorno = new DominioRegionaisViewModel();
                retorno.reg_id = model.reg_id;
                retorno.reg_codigo = model.reg_codigo;
                retorno.mun_ibge_id = model.mun_ibge_id;
                retorno.reg_descricao = model.reg_descricao;
                retorno.reg_endereco = model.reg_endereco;
                retorno.reg_bairro = model.reg_bairro;
                retorno.reg_cep = model.reg_cep;
                retorno.reg_ddd_telefone = model.reg_ddd_telefone;
                retorno.reg_telefone = model.reg_telefone;
                retorno.reg_email = model.reg_email;
                retorno.reg_diretor = model.reg_diretor;
                retorno.reg_email_diretor = model.reg_email_diretor;
                retorno.reg_ddd_telefone_cco = model.reg_ddd_telefone_cco;
                retorno.reg_telefone_cco = model.reg_telefone_cco;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioRegionaisViewModel();
            }
        }
    }

}