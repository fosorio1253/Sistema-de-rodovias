﻿using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.ConsultarRodovias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DER.WebApp.Domain.Business
{
    public class ConsultarRodoviasBLL
    {
        private ApiBueiroBLL apiBueiro;
        private ApiDispositivoBLL apiDispositivoBLL;
        private ApiDrenagemBLL apiDrenagemBLL;
        private ApiEdificacoesBLL apiEdificacoesBLL;
        private DominioSuperficiesTiposBLL dominioSuperficiesTiposBLL;
        private DominioDispositivosTiposBLL dominioDispositivosTiposBLL;
        private DominioDrenagensTiposBLL dominioDrenagensTiposBLL;
        private DominioEdificacoesTiposBLL dominioEdificacoesTiposBLL;

        public ConsultarRodoviasBLL()
        {
            apiBueiro = new ApiBueiroBLL();
            apiDispositivoBLL = new ApiDispositivoBLL();
            apiDrenagemBLL = new ApiDrenagemBLL();
            apiEdificacoesBLL = new ApiEdificacoesBLL();
            dominioSuperficiesTiposBLL = new DominioSuperficiesTiposBLL();
            dominioDispositivosTiposBLL = new DominioDispositivosTiposBLL();
            dominioDrenagensTiposBLL = new DominioDrenagensTiposBLL();
            dominioEdificacoesTiposBLL = new DominioEdificacoesTiposBLL();
        }

        public List<ConsultarRodoviasViewModels> ObtemLista(ConsultarRodoviasViewModelsParams logViewModel)
        {
            bool bueiro = logViewModel.AdutoraAgua;
            bool dispositivo = logViewModel.DispositivosOCR;
            bool drenagem = logViewModel.RedePluvial;
            bool edifica = logViewModel.Outros;

            if(!logViewModel.AdutoraAgua && 
                !logViewModel.DispositivosOCR && 
                !logViewModel.EstacaoTelefonia && 
                !logViewModel.Gasodutos && 
                !logViewModel.Oleodutos && 
                !logViewModel.Outros &&
                !logViewModel.RedeEletrica &&
                !logViewModel.RedePluvial &&
                !logViewModel.RedeTelecomunicativa)
            {
                bueiro = true;
                dispositivo = true;
                drenagem = true;
                edifica = true;
            }

            if (logViewModel.KmFinal.Equals(0))
                logViewModel.KmFinal = double.MaxValue;

            var lDom = new List<ConsultarRodoviasViewModels>();
            
            if (!logViewModel.RodoviaId.Equals(0))
            {
                if(bueiro)
                    ConstruirConsultarRodoviasViewModels(apiBueiro.LoadView()
                        .Where(x => x.rod_id.Equals(logViewModel.RodoviaId) && x.ace_km >= logViewModel.KmInicial && x.ace_km <= logViewModel.KmFinal)
                        .OrderBy(x => x.ace_km).ToList()).ForEach(x => { if (x != null) lDom.Add(x); });

                if(dispositivo)
                    ConstruirConsultarRodoviasViewModels(apiDispositivoBLL.LoadView()
                        .Where(x => x.rod_id.Equals(logViewModel.RodoviaId) && x.dis_km >= logViewModel.KmInicial && x.dis_km <= logViewModel.KmFinal)
                        .OrderBy(x => x.dis_km).ToList()).ForEach(x => { if (x != null) lDom.Add(x); });

                if(drenagem)
                    ConstruirConsultarRodoviasViewModels(apiDrenagemBLL.LoadView()
                        .Where(x => x.rod_id.Equals(logViewModel.RodoviaId) && x.drp_km >= logViewModel.KmInicial && x.drp_km <= logViewModel.KmFinal)
                        .OrderBy(x => x.drp_km).ToList()).ForEach(x => { if (x != null) lDom.Add(x); });
                
                if(edifica)
                ConstruirConsultarRodoviasViewModels(apiEdificacoesBLL.LoadView()
                    .Where(x => x.rod_id.Equals(logViewModel.RodoviaId) && x.edi_km >= logViewModel.KmInicial && x.edi_km <= logViewModel.KmFinal)
                    .OrderBy(x => x.edi_km).ToList()).ForEach(x => { if (x != null) lDom.Add(x); });
            }

            return lDom;
        }

        public List<ConsultarRodoviasViewModels> ConstruirConsultarRodoviasViewModels<T>(List<T> lObj, bool central = false)
        {
            var nome = AddSpacesToSentence(Activator.CreateInstance(typeof(T)).GetType().Name.ToString());
            
            var lCRVM = new List<ConsultarRodoviasViewModels>();
            foreach (var obj in lObj)
            {
                var CRVM = new ConsultarRodoviasViewModels();
                if (obj.GetType().Name.ToString().Equals("ApiBueiro"))
                    nome = dominioSuperficiesTiposBLL.LoadView()
                        .Where(x => x.stp_id.Equals(obj.GetType().GetProperty("stp_id").GetValue(obj))).FirstOrDefault().stp_descricao;

                else if (obj.GetType().Name.ToString().Equals("ApiDispositivo"))
                    nome = dominioDispositivosTiposBLL.LoadView()
                        .Where(x => x.dit_id.Equals(obj.GetType().GetProperty("dit_id").GetValue(obj))).FirstOrDefault().dit_descricao;

                else if (obj.GetType().Name.ToString().Equals("ApiDrenagem"))
                    nome = dominioDrenagensTiposBLL.LoadView()
                        .Where(x => x.drt_id.Equals(obj.GetType().GetProperty("drt_id").GetValue(obj))).FirstOrDefault().drt_descricao;

                else if (obj.GetType().Name.ToString().Equals("ApiEdificacoes"))
                    nome = dominioEdificacoesTiposBLL.LoadView()
                        .Where(x => x.edt_id.Equals(obj.GetType().GetProperty("edt_id").GetValue(obj))).FirstOrDefault().edt_descricao;

                CRVM.Quilometro = (double)obj.GetType().GetProperties().Where(x => x.Name.Contains("_km")).Select(x => x.GetValue(obj)).FirstOrDefault();
                if(central)
                    CRVM.Centro = nome;
                else
                {
                    if (obj.GetType().GetProperty("sen_id").GetValue(obj).Equals(1))
                        CRVM.BordaDireita = nome;
                    else
                        CRVM.BordaEsquerda = nome;
                }
                lCRVM.Add(CRVM);
            }
            return lCRVM;
        }

        public string AddSpacesToSentence(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]) && text[i - 1] != ' ')
                    newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }
    }
}