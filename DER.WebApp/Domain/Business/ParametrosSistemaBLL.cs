using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class ParametrosSistemaBLL
    {
        private DerContext context;
        private ParametrosSistemaDAO parametrosSistemaDAO;

        public ParametrosSistemaBLL()
        {
            context = new DerContext();
            parametrosSistemaDAO = new ParametrosSistemaDAO(context);
        }

        public bool Save(ParametrosSistemaViewModel viewModel)
        {
            try
            {
                var model = ConvertModelView(viewModel);

                return ExistsById(model.parametros_sistema_id) ?
                    parametrosSistemaDAO.Update(model) :
                    parametrosSistemaDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<ParametrosSistemaViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModelView(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<ParametrosSistemaViewModel>();
            }
        }

        public List<ParametrosSistema> Load()
        {
            try
            {
                return parametrosSistemaDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<ParametrosSistema>();
            }
        }

        public bool Remove(ParametrosSistemaViewModel viewModel)
        {
            try
            {
                var model = ConvertModelView(viewModel);
                return ExistsById(model.parametros_sistema_id) ?
                    parametrosSistemaDAO.Delete(model) : false;
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
                return Load().Any(x => x.parametros_sistema_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<ParametrosSistemaViewModel> ToList(ParametrosSistemaViewModel model, List<ParametrosSistemaViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<ParametrosSistemaViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<ParametrosSistemaViewModel>();
            }
        }

        private ParametrosSistema ConvertModelView(ParametrosSistemaViewModel model)
        {
            try
            {
                var retorno = new ParametrosSistema();
                retorno.area_nome                       = model.area_nome;
                retorno.lado_nome                       = model.lado_nome;
                retorno.natureza_juridica_descricao     = model.natureza_juridica_descricao;
                retorno.ocorrencia_severidade_nome      = model.ocorrencia_severidade_nome;
                retorno.ocorrencia_status_nome          = model.ocorrencia_status_nome;
                retorno.ocorrencia_trecho_nome          = model.ocorrencia_trecho_nome;
                retorno.origem_da_solicitacao_nome      = model.ocorrencia_trecho_nome;
                retorno.parametros_sistema_id           = model.parametros_sistema_id;
                retorno.situacao_ocupacao_nome          = model.situacao_ocupacao_nome;
                retorno.situacao_solicitacao_nome       = model.situacao_solicitacao_nome;
                retorno.tipo_documento_descricao        = model.tipo_documento_descricao;
                retorno.tipo_documento_ocupao_descricao = model.tipo_documento_ocupao_descricao;
                retorno.tipo_empresa_descricao          = model.tipo_empresa_descricao;
                retorno.tipo_implantacao_nome           = model.tipo_implantacao_nome;
                retorno.tipo_interferencia_nome         = model.tipo_interferencia_nome;
                retorno.tipo_passagem_nome              = model.tipo_passagem_nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new ParametrosSistema();
            }
        }

        private ParametrosSistemaViewModel ConvertModelView(ParametrosSistema model)
        {
            try
            {
                var retorno = new ParametrosSistemaViewModel();
                retorno.area_nome                       = model.area_nome;
                retorno.lado_nome                       = model.lado_nome;
                retorno.natureza_juridica_descricao     = model.natureza_juridica_descricao;
                retorno.ocorrencia_severidade_nome      = model.ocorrencia_severidade_nome;
                retorno.ocorrencia_status_nome          = model.ocorrencia_status_nome;
                retorno.ocorrencia_trecho_nome          = model.ocorrencia_trecho_nome;
                retorno.origem_da_solicitacao_nome      = model.ocorrencia_trecho_nome;
                retorno.parametros_sistema_id           = model.parametros_sistema_id;
                retorno.situacao_ocupacao_nome          = model.situacao_ocupacao_nome;
                retorno.situacao_solicitacao_nome       = model.situacao_solicitacao_nome;
                retorno.tipo_documento_descricao        = model.tipo_documento_descricao;
                retorno.tipo_documento_ocupao_descricao = model.tipo_documento_ocupao_descricao;
                retorno.tipo_empresa_descricao          = model.tipo_empresa_descricao;
                retorno.tipo_implantacao_nome           = model.tipo_implantacao_nome;
                retorno.tipo_interferencia_nome         = model.tipo_interferencia_nome;
                retorno.tipo_passagem_nome              = model.tipo_passagem_nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new ParametrosSistemaViewModel();
            }
        }
    }
}