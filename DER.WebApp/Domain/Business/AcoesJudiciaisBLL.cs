using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using EnumsNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DER.WebApp.Domain.Business
{
    public class AcoesJudiciaisBLL
    {
        private DerContext context;
        private GestaoOcupacaoAcoesJudiciaisDAO acoesJudiciaisDAO;

        public AcoesJudiciaisBLL()
        {
            context = new DerContext();
            acoesJudiciaisDAO = new GestaoOcupacaoAcoesJudiciaisDAO(context);
        }

        public bool Save(GestaoOcupacoesAcoesJudiciaisViewModel viewModel)
        {
            try
            {
                return ExistsById(viewModel.IdAcoesJudiciais) ? 
                    acoesJudiciaisDAO.Update(ViewModelToModel(viewModel)) :
                    acoesJudiciaisDAO.Inserir(ViewModelToModel(viewModel));
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public List<GestaoOcupacoesAcoesJudiciaisViewModel> Load()
        {
            try
            {
                return acoesJudiciaisDAO.ObtemTodos().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<GestaoOcupacoesAcoesJudiciaisViewModel>();
            }
        }

        public GestaoOcupacoesAcoesJudiciaisViewModel LoadById(int id)
        {
            try
            {
                return Load().Where(x => x.IdAcoesJudiciais.Equals(id)).FirstOrDefault();
            }
            catch (Exception e)
            {
                return new GestaoOcupacoesAcoesJudiciaisViewModel();
            }
        }

        public GestaoOcupacoesAcoesJudiciaisViewModel LoadByOcupacao(int id)
        {
            try
            {
                return Load().Where(x => x.IdOcupacao.Equals(id)).FirstOrDefault();
            }
            catch (Exception e)
            {
                return new GestaoOcupacoesAcoesJudiciaisViewModel();
            }
        }

        public GestaoOcupacoesAcoesJudiciaisViewModel LoadByInteressado(int id)
        {
            try
            {
                return Load().Where(x => x.IdInteressado.Equals(id)).FirstOrDefault();
            }
            catch (Exception e)
            {
                return new GestaoOcupacoesAcoesJudiciaisViewModel();
            }
        }

        public GestaoOcupacoesAcoesJudiciaisViewModel LoadPadrao()
        {
            try
            {
                var model = new GestaoOcupacoesAcoesJudiciaisViewModel();
                model.IdSituacaoProcessual  = (int)SituacaoProcessualEnum.Situacao.TotalFavor;
                model.CobrancaAnuidade      = "Sim";
                model.CobrancaPEP           = "Sim";
                model.CobrancaRegularizacao = "Sim";
                model.CobrancaLevantamento  = "Sim";
                model.Assinatura            = "Sim";

                model.SituacoesProcessuais  = GerarSelectListSituacaoProcessual();

                return model;
            }
            catch (Exception e)
            {
                return new GestaoOcupacoesAcoesJudiciaisViewModel();
            }
        }

        public bool ExistsById(int id)
        {
            try
            {
                return Load().Any(x => x.IdAcoesJudiciais.Equals(id));
            }
            catch (Exception e)

            {
                return false;
            }
        }

        public bool ExistsByOcupacao(int id)
        {
            
            try
            {
                return Load().Any(x => x.IdOcupacao.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExistsByInteressado(int id)
        {
            try
            {
                return Load().Any(x => x.IdInteressado.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ValidarAcaoJudicialPEP(int id)
        {
            try
            {
                if (ExistsByOcupacao(id))
                    return ViewModelToModel(LoadByOcupacao(id)).ocu_acoesjud_cobrancapep;
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool ValidarAcaoJudicialAnuidade(int id)
        {
            try
            {
                if (ExistsByOcupacao(id))
                    return ViewModelToModel(LoadByOcupacao(id)).ocu_acoesjud_cobrancaanuidade;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<GestaoOcupacoesAcoesJudiciaisViewModel> ToList(GestaoOcupacoesAcoesJudiciaisViewModel model, List<GestaoOcupacoesAcoesJudiciaisViewModel> lmodel = null)
        {
            try
            {
                if(lmodel == null) lmodel = new List<GestaoOcupacoesAcoesJudiciaisViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<GestaoOcupacoesAcoesJudiciaisViewModel>();
            }
        }

        private AcoesJudiciais ViewModelToModel(GestaoOcupacoesAcoesJudiciaisViewModel model)
        {
            try
            {
                var retorno = new AcoesJudiciais();
                retorno.ocu_acoesjud_id                     = model.IdAcoesJudiciais;
                retorno.ocu_acoesjud_idinteressado          = model.IdInteressado;
                retorno.ocu_acoesjud_idocupacao             = model.IdOcupacao;
                retorno.ocu_acoesjud_cnpj                   = model.CPNJ;
                retorno.ocu_acoesjud_protocolo              = model.Protocolo;
                retorno.ocu_acoesjud_idtipocupacao          = model.IdTipoOcupacao;
                retorno.ocu_acoesjud_processojudicial       = model.ProcessoJudicial;
                retorno.ocu_acoesjud_historicoresumido      = model.HistoricoResumido;
                retorno.ocu_acoesjud_idsituacaoprocessual   = model.IdSituacaoProcessual;
                retorno.ocu_acoesjud_cobrancapep            = model.CobrancaPEP.Equals("Sim")           ? true : false;
                retorno.ocu_acoesjud_cobrancaregularizacao  = model.CobrancaRegularizacao.Equals("Sim") ? true : false;
                retorno.ocu_acoesjud_cobrancaanuidade       = model.CobrancaAnuidade.Equals("Sim")      ? true : false;
                retorno.ocu_acoesjud_cobrancalevantamento   = model.CobrancaLevantamento.Equals("Sim")  ? true : false;
                retorno.ocu_acoesjud_assinatura             = model.Assinatura.Equals("Sim")            ? true : false;
                retorno.ocu_acoesjud_idrodovia              = model.IdRodovia;
                retorno.ocu_acoesjud_kminicial              = model.KmInicial;
                retorno.ocu_acoesjud_kmfinal                = model.KmFinal;
                retorno.ocu_acoesjud_motivoassinatura       = model.MotivoAssinatura;
                retorno.ocu_acoesjud_datadespacho           = model.DataDespacho;
                retorno.ocu_acoesjud_observacao             = model.Observacao;

                return retorno;
            }
            catch (Exception e)
            {
                return new AcoesJudiciais();
            }
        }

        private GestaoOcupacoesAcoesJudiciaisViewModel ModelToViewModel(AcoesJudiciais model)
        {
            try
            {
                var retorno = new GestaoOcupacoesAcoesJudiciaisViewModel();
                retorno.IdAcoesJudiciais        = model.ocu_acoesjud_id;
                retorno.IdInteressado           = model.ocu_acoesjud_idinteressado;
                retorno.IdOcupacao              = model.ocu_acoesjud_idocupacao;
                retorno.CPNJ                    = model.ocu_acoesjud_cnpj;
                retorno.Protocolo               = model.ocu_acoesjud_protocolo;
                retorno.IdTipoOcupacao          = model.ocu_acoesjud_idtipocupacao;
                retorno.ProcessoJudicial        = model.ocu_acoesjud_processojudicial;
                retorno.HistoricoResumido       = model.ocu_acoesjud_historicoresumido;
                retorno.IdSituacaoProcessual    = model.ocu_acoesjud_idsituacaoprocessual;
                retorno.CobrancaPEP             = model.ocu_acoesjud_cobrancapep            ? "Sim" : "Não";
                retorno.CobrancaRegularizacao   = model.ocu_acoesjud_cobrancaregularizacao  ? "Sim" : "Não";
                retorno.CobrancaAnuidade        = model.ocu_acoesjud_cobrancaanuidade       ? "Sim" : "Não";
                retorno.CobrancaLevantamento    = model.ocu_acoesjud_cobrancalevantamento   ? "Sim" : "Não";
                retorno.Assinatura              = model.ocu_acoesjud_assinatura             ? "Sim" : "Não";
                retorno.IdRodovia               = model.ocu_acoesjud_idrodovia;
                retorno.KmInicial               = model.ocu_acoesjud_kminicial;
                retorno.KmFinal                 = model.ocu_acoesjud_kmfinal;
                retorno.MotivoAssinatura        = model.ocu_acoesjud_motivoassinatura;
                retorno.DataDespacho            = model.ocu_acoesjud_datadespacho;
                retorno.Observacao              = model.ocu_acoesjud_observacao;

                retorno.SituacoesProcessuais    = GerarSelectListSituacaoProcessual();

                return retorno;
            }
            catch (Exception e)
            {
                return new GestaoOcupacoesAcoesJudiciaisViewModel();
            }
        }

        private SelectList GerarSelectListSituacaoProcessual()
        {
            try
            {
                var lmodel = new List<SituacaoProcessual>();
                Enum.GetValues(typeof(SituacaoProcessualEnum.Situacao)).Cast<int>().ToList().ForEach(x => 
                {
                    var model = new SituacaoProcessual();
                    model.Id = x;
                    model.Situacao = ((SituacaoProcessualEnum.Situacao)x).AsString(EnumFormat.Description);
                    lmodel.Add(model);
                });
                return new SelectList(lmodel, "Id", "Situacao");
            }
            catch (Exception e)
            {
                return new SelectList(null);
            }
        }
    }

    public class SituacaoProcessual
    {
        public int      Id          { get; set; }
        public string   Situacao    { get; set; }
    }
}
