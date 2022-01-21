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
    public class DominioResidenciasBLL
    {
        private DerContext context;
        private DominioResidenciasDAO dominioresidenciasDAO;

        public DominioResidenciasBLL()
        {
            context = new DerContext();
            dominioresidenciasDAO = new DominioResidenciasDAO(context);
        }

        public bool Save(DominioResidenciasViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.res_id) ?
                    dominioresidenciasDAO.Update(model) :
                    dominioresidenciasDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(DominioResidencias model)
        {
            try
            {
                return ExistsById(model.res_id) ?
                    dominioresidenciasDAO.Update(model) :
                    dominioresidenciasDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioResidenciasViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioResidenciasViewModel>();
            }
        }

        public List<DominioResidencias> Load()
        {
            try
            {
                return dominioresidenciasDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioResidencias>();
            }
        }

        public bool Remove(DominioResidenciasViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.res_id) ?
                    dominioresidenciasDAO.Delete(model) : false;
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
                return Load().Any(x => x.res_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioResidenciasViewModel> ToList(DominioResidenciasViewModel model, List<DominioResidenciasViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioResidenciasViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioResidenciasViewModel>();
            }
        }

        private DominioResidencias ViewModelToModel(DominioResidenciasViewModel model)
        {
            try
            {
                var retorno = new DominioResidencias();
                retorno.res_id = model.res_id;
                retorno.reg_id = model.reg_id;
                retorno.res_codigo = model.res_codigo;
                retorno.mun_ibge_id = model.mun_ibge_id;
                retorno.res_descricao = model.res_descricao;
                retorno.res_endereco = model.res_endereco;
                retorno.res_bairro = model.res_bairro;
                retorno.res_cep = model.res_cep;
                retorno.res_ddd_telefone = model.res_ddd_telefone;
                retorno.res_telefone = model.res_telefone;
                retorno.res_ddd_telefone_cco = model.res_ddd_telefone_cco;
                retorno.res_telefone_cco = model.res_telefone_cco;
                retorno.res_email = model.res_email;
                retorno.res_eng_responsavel = model.res_eng_responsavel;
                retorno.res_email_eng_responsavel = model.res_email_eng_responsavel;
                retorno.res_ddd_celular_eng = model.res_ddd_celular_eng;
                retorno.res_celular_eng = model.res_celular_eng;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioResidencias();
            }
        }

        private DominioResidenciasViewModel ModelToViewModel(DominioResidencias model)
        {
            try
            {
                var retorno = new DominioResidenciasViewModel();
                retorno.res_id = model.res_id;
                retorno.reg_id = model.reg_id;
                retorno.res_codigo = model.res_codigo;
                retorno.mun_ibge_id = model.mun_ibge_id;
                retorno.res_descricao = model.res_descricao;
                retorno.res_endereco = model.res_endereco;
                retorno.res_bairro = model.res_bairro;
                retorno.res_cep = model.res_cep;
                retorno.res_ddd_telefone = model.res_ddd_telefone;
                retorno.res_telefone = model.res_telefone;
                retorno.res_ddd_telefone_cco = model.res_ddd_telefone_cco;
                retorno.res_telefone_cco = model.res_telefone_cco;
                retorno.res_email = model.res_email;
                retorno.res_eng_responsavel = model.res_eng_responsavel;
                retorno.res_email_eng_responsavel = model.res_email_eng_responsavel;
                retorno.res_ddd_celular_eng = model.res_ddd_celular_eng;
                retorno.res_celular_eng = model.res_celular_eng;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioResidenciasViewModel();
            }
        }
    }

}