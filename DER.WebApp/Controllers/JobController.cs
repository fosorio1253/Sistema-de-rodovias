using DER.WebApp.Domain.Business;
using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace DER.WebApp.Controllers
{
    public class JobController : Controller
    {
        private DadosMestresBLL dadosMestresBLL;
        private GestaoOcupacaoRemuneracaoBLL gestaoOcupacaoRemuneracaoBLL;
        private FaturamentoOcupacaoBLL faturamentoOcupacaoBLL;
        private InadimplentesViewBLL InadimplentesViewBLL;

        public JobController()
        {
            dadosMestresBLL                 = new DadosMestresBLL();
            gestaoOcupacaoRemuneracaoBLL    = new GestaoOcupacaoRemuneracaoBLL();
            faturamentoOcupacaoBLL          = new FaturamentoOcupacaoBLL();
            InadimplentesViewBLL            = new InadimplentesViewBLL();
        }
        public ActionResult Index()
        {
            return View(new APIViewModel().RetornaApisSirgeo());
        }

        public JsonResult ExecutaTodasAPIs()
        {
            var model = new APIViewModel();
            var listaQueDeveSerConsumida = new List<int>();
            var lretorno = new List<SirgeoColection>();

            
            listaQueDeveSerConsumida.Add(2);            
            listaQueDeveSerConsumida.Add(4);
            
            for (int i = 113; i < 117; i++)
                listaQueDeveSerConsumida.Add(i);
            
            
            foreach (var i in listaQueDeveSerConsumida)
                lretorno.Add(new SirgeoColection() { id = i, retorno = model.HealtCheckAPI(i) });

            //consumir os primeiros 10 objetos recebidos pelo HeltCheckAPI. Util para testes
            /*
            foreach(var ret in lretorno)
            {
                string mon = string.Empty;
                int i = 0;
                foreach(var data in ret.retorno.Mensagem.Split('}'))
                    if (i < 10)
                    {
                        mon = mon + data + "}";
                        i++;
                    }
                    else
                        break;

                ret.retorno.Mensagem = mon + "]";
            }
            */

            foreach (var ret in lretorno)
                if (!ret.retorno.Mensagem.Equals(@"[]"))
                    if (ret.id == 2) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<Rodovia>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 4) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<Dispositivo>(ret.retorno.Mensagem, "dis_id")); }
                    else if (ret.id == 56) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<AreasGramadasLevantamento>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 57) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DrenagensLinearesLevantamento>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 58) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<CercasLevantamento>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 59) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<FaixasRolamentoLevantamento>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 60) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<PassivosAmbientaisLinLevantamento>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 61) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<OaeLevantamento>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 62) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<PavimentacoesLevantamento>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 63) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<PavimentosRigidosLevantamento>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 64) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<SegurancaBordoLevantamento>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 65) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<RocadasLevantamento>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 66) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<SegurancaCanteiroLevantamento>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 67) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<SegurancaGuardaCorpoLevantamento>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 68) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<SinalFaixaBordoLevantamento>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 69) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<SinalFaixaCentralLevantamento>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 70) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<TerceiraFaixaLevantamento>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 71) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<TachaFaixaBordoLevantamento>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 72) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<TachaFaixaCentralLevantamento>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 73) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<TiposPistaLevantamento>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 74) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<TuneisLevantamento>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 75) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<AcostamentosLevantamento>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 76) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioFlags>(ret.retorno.Mensagem, "fla_id")); }
                    //else if (ret.id == 77) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 78) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioHidraulicaPosicoes>(ret.retorno.Mensagem, "hps_id")); }
                    else if (ret.id == 79) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioPistaTipos>(ret.retorno.Mensagem, "ptp_id")); }
                    else if (ret.id == 80) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioRegionais>(ret.retorno.Mensagem, "reg_codigo")); }
                    else if (ret.id == 81) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioRegionaisCode>(ret.retorno.Mensagem, "reg_id")); }
                    else if (ret.id == 82) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioResidencias>(ret.retorno.Mensagem, "res_id")); }
                    else if (ret.id == 83) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioRelevos>(ret.retorno.Mensagem, "rel_id")); }
                    else if (ret.id == 84) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioRevestimentos>(ret.retorno.Mensagem, "rev_id")); }
                    else if (ret.id == 85) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioRodoviassentidos>(ret.retorno.Mensagem, "sen_id")); }
                    else if (ret.id == 86) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioRodoviasTipos>(ret.retorno.Mensagem, "rtp_id")); }
                    else if (ret.id == 87) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioArquivoTipos>(ret.retorno.Mensagem, "arq_id")); }
                    else if (ret.id == 88) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioBueirosDiagnosticos>(ret.retorno.Mensagem, "bdg_id")); }
                    else if (ret.id == 89) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioBueirosMateriais>(ret.retorno.Mensagem, "bmt_id")); }
                    //else if (ret.id == 90) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioBueirosTipos>(ret.retorno.Mensagem, "btp_id")); }
                    else if (ret.id == 91) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioGradacoes>(ret.retorno.Mensagem, "gra_id")); }
                    else if (ret.id == 92) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioPesosIds>(ret.retorno.Mensagem, "pes_nota")); }
                    else if (ret.id == 93) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioSuperficiesTipos>(ret.retorno.Mensagem, "stp_id")); }
                    else if (ret.id == 94) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioDrenagensTipos>(ret.retorno.Mensagem, "drt_id")); }
                    else if (ret.id == 95) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioOaeTipos>(ret.retorno.Mensagem, "oat_id")); }
                    else if (ret.id == 96) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioPassivosAmbientaisTipos>(ret.retorno.Mensagem, "pat_id")); }
                    else if (ret.id == 97) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioElementosSegurancaTipos>(ret.retorno.Mensagem, "est_id")); }
                    else if (ret.id == 98) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioSinalizacoesHorizontaisTipos>(ret.retorno.Mensagem, "sht_id")); }
                    else if (ret.id == 99) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioDispositivosTipos>(ret.retorno.Mensagem, "dit_id")); }
                    else if (ret.id == 100) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioEdificacoesTipos>(ret.retorno.Mensagem, "edt_id")); }
                    else if (ret.id == 101) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioInstalacoesOperacionaisTipos>(ret.retorno.Mensagem, "iot_id")); }
                    else if (ret.id == 102) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioSubestacoesReservatoriosTipos>(ret.retorno.Mensagem, "srt_id")); }
                    else if (ret.id == 103) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioPorticosPmvsTipos>(ret.retorno.Mensagem, "ppt_id")); }
                    else if (ret.id == 104) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioEletricosTelefoniaTipos>(ret.retorno.Mensagem, "ett_id")); }
                    //else if (ret.id == 105) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioSensoresEletronicosTipos>(ret.retorno.Mensagem, "set_id")); }
                    else if (ret.id == 106) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioSinalizacoesVerticaisTipos>(ret.retorno.Mensagem, "svt_id")); }
                    else if (ret.id == 107) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioTravessiasTipos>(ret.retorno.Mensagem, "trt_id")); }
                    else if (ret.id == 108) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioMateriais>(ret.retorno.Mensagem, "mat_id")); }
                    else if (ret.id == 109) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioAdministradores>(ret.retorno.Mensagem, "adm_id")); }
                    else if (ret.id == 110) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioJurisdições>(ret.retorno.Mensagem, "jur_id")); }
                    else if (ret.id == 111) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioConservadores>(ret.retorno.Mensagem, "con_id")); }
                    else if (ret.id == 112) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<DominioCircunscricao>(ret.retorno.Mensagem, "res_id")); }

                    else if (ret.id == 113) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<ApiBueiro>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 114) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<ApiDispositivo>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 115) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<ApiDrenagem>(ret.retorno.Mensagem, "rod_id")); }
                    else if (ret.id == 116) { dadosMestresBLL.Salvar(dadosMestresBLL.EntToDadosMestres<ApiEdificacoes>(ret.retorno.Mensagem, "rod_id")); }


            return Json($"Retornando", JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemuneracaoJob()
        {
            gestaoOcupacaoRemuneracaoBLL.Read().TakeWhile(x => gestaoOcupacaoRemuneracaoBLL.Read()
            .GroupBy(y => y.IdOcupacao).Select(y => y.Max(z => z.IdGestaoOcupacoesRemuneracao)) //pegando a ultima remuneração gerada de cada ocupação
            .Any(y => y.Equals(x.IdGestaoOcupacoesRemuneracao)) && x.DataRemuneracao.Value.AddMonths(11) < DateTime.Now).ToList() //filtrando para que fique somente as remunerações que estão com 11 meses
            .ForEach(x => gestaoOcupacaoRemuneracaoBLL.Write(new GestaoOcupacoesController().ObtemGestaoOcupacao(x.IdOcupacao), x.IdGestaoOcupacoesRemuneracao++)); //calculando a nova remuneração

            return Json($"Retornando", JsonRequestBehavior.AllowGet);
        }

        public JsonResult InadimplentesJob()
        {
            InadimplentesViewBLL.Write(faturamentoOcupacaoBLL.ObterFaturamentoInadimplentes());
            return Json($"Retornando", JsonRequestBehavior.AllowGet);
        }
    }
    public class SirgeoColection
    {
        public int id { get; set; }
        public RetornoHealtCheckAPI retorno { get; set; }
    }
}