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
        private GestaoOcupacaoRemuneracaoBLL gestaoOcupacaoRemuneracaoBLL;
        private FaturamentoOcupacaoBLL faturamentoOcupacaoBLL;
        private InadimplentesViewBLL InadimplentesViewBLL;

        private RodoviasBLL rodoviasBLL;
        private DispositivosBLL dispositivoBLL;
        private AreasGramadasLevantamentoBLL areasGramadasLevantamentoBLL;
        private DrenagensLinearesLevantamentoBLL drenagensLinearesLevantamentoBLL;
        private CercasLevantamentoBLL cercasLevantamentoBLL;
        private FaixasRolamentoLevantamentoBLL faixasRolamentoLevantamentoBLL;
        private PassivosAmbientaisLinLevantamentoBLL passivosAmbientaisLinLevantamentoBLL;
        private OaeLevantamentoBLL oaeLevantamentoBLL;
        private PavimentacoesLevantamentoBLL pavimentacoesLevantamentoBLL;
        private PavimentosRigidosLevantamentoBLL pavimentosRigidosLevantamentoBLL;
        private SegurancaBordoLevantamentoBLL segurancaBordoLevantamentoBLL;
        private RocadasLevantamentoBLL rocadasLevantamentoBLL;
        private SegurancaCanteiroLevantamentoBLL segurancaCanteiroLevantamentoBLL;
        private SegurancaGuardaCorpoLevantamentoBLL segurancaGuardaCorpoLevantamentoBLL;
        private SinalFaixaBordoLevantamentoBLL sinalFaixaBordoLevantamentoBLL;
        private SinalFaixaCentralLevantamentoBLL sinalFaixaCentralLevantamentoBLL;
        private TerceiraFaixaLevantamentoBLL terceiraFaixaLevantamentoBLL;
        private TachaFaixaBordoLevantamentoBLL tachaFaixaBordoLevantamentoBLL;
        private TachaFaixaCentralLevantamentoBLL tachaFaixaCentralLevantamentoBLL;
        private TiposPistaLevantamentoBLL tiposPistaLevantamentoBLL;
        private TuneisLevantamentoBLL tuneisLevantamentoBLL;
        private AcostamentosLevantamentoBLL acostamentosLevantamentoBLL;
        private DominioFlagsBLL dominioFlagsBLL;


        private DominioHidraulicaPosicoesBLL dominioHidraulicaPosicoesBLL;
        private DominioPistaTiposBLL dominioPistaTiposBLL;
        private DominioRegionaisBLL dominioRegionaisBLL;
        private DominioRegionaisCodeBLL dominioRegionaisCodeBLL;
        private DominioResidenciasBLL dominioResidenciasBLL;
        private DominioRelevosBLL dominioRelevosBLL;
        private DominioRevestimentosBLL dominioRevestimentosBLL;
        private DominioRodoviassentidosBLL dominioRodoviassentidosBLL;
        private DominioRodoviasTiposBLL dominioRodoviasTiposBLL;
        private DominioArquivoTiposBLL dominioArquivoTiposBLL;
        private DominioBueirosDiagnosticosBLL dominioBueirosDiagnosticosBLL;
        private DominioBueirosMateriaisBLL dominioBueirosMateriaisBLL;
        private DominioGradacoesBLL dominioGradacoesBLL;
        private DominioPesosIdsBLL dominioPesosIdsBLL;
        private DominioSuperficiesTiposBLL dominioSuperficiesTiposBLL;
        private DominioDrenagensTiposBLL dominioDrenagensTiposBLL;
        private DominioOaeTiposBLL dominioOaeTiposBLL;
        private DominioPassivosAmbientaisTiposBLL dominioPassivosAmbientaisTiposBLL;
        private DominioElementosSegurancaTiposBLL dominioElementosSegurancaTiposBLL;
        private DominioSinalizacoesHorizontaisTiposBLL dominioSinalizacoesHorizontaisTiposBLL;
        private DominioDispositivosTiposBLL dominioDispositivosTiposBLL;
        private DominioEdificacoesTiposBLL dominioEdificacoesTiposBLL;
        private DominioInstalacoesOperacionaisTiposBLL dominioInstalacoesOperacionaisTiposBLL;
        private DominioSubestacoesReservatoriosTiposBLL dominioSubestacoesReservatoriosTiposBLL;
        private DominioPorticosPmvsTiposBLL dominioPorticosPmvsTiposBLL;
        private DominioEletricosTelefoniaTiposBLL dominioEletricosTelefoniaTiposBLL;
        private DominioSinalizacoesVerticaisTiposBLL dominioSinalizacoesVerticaisTiposBLL;
        private DominioTravessiasTiposBLL dominioTravessiasTiposBLL;
        private DominioMateriaisBLL dominioMateriaisBLL;
        private DominioAdministradoresBLL dominioAdministradoresBLL;
        private DominioJurisdicoesBLL dominioJurisdicoesBLL;
        private DominioConservadoresBLL dominioConservadoresBLL;
        private DominioCircunscricaoBLL dominioCircunscricaoBLL;
        private ApiBueiroBLL apiBueiroBLL;
        private ApiDispositivoBLL apiDispositivoBLL;
        private ApiDrenagemBLL apiDrenagemBLL;
        private ApiEdificacoesBLL apiEdificacoesBLL;

public JobController()
        {
            gestaoOcupacaoRemuneracaoBLL    = new GestaoOcupacaoRemuneracaoBLL();
            faturamentoOcupacaoBLL          = new FaturamentoOcupacaoBLL();
            InadimplentesViewBLL            = new InadimplentesViewBLL();

            rodoviasBLL = new RodoviasBLL();
            dispositivoBLL = new DispositivosBLL();
            areasGramadasLevantamentoBLL = new AreasGramadasLevantamentoBLL();
            drenagensLinearesLevantamentoBLL = new DrenagensLinearesLevantamentoBLL();
            cercasLevantamentoBLL = new CercasLevantamentoBLL();
            faixasRolamentoLevantamentoBLL = new FaixasRolamentoLevantamentoBLL();
            passivosAmbientaisLinLevantamentoBLL = new PassivosAmbientaisLinLevantamentoBLL();
            oaeLevantamentoBLL = new OaeLevantamentoBLL();
            pavimentacoesLevantamentoBLL = new PavimentacoesLevantamentoBLL();
            pavimentosRigidosLevantamentoBLL = new PavimentosRigidosLevantamentoBLL();
            segurancaBordoLevantamentoBLL = new SegurancaBordoLevantamentoBLL();
            rocadasLevantamentoBLL = new RocadasLevantamentoBLL();
            segurancaCanteiroLevantamentoBLL = new SegurancaCanteiroLevantamentoBLL();
            segurancaGuardaCorpoLevantamentoBLL = new SegurancaGuardaCorpoLevantamentoBLL();
            sinalFaixaBordoLevantamentoBLL = new SinalFaixaBordoLevantamentoBLL();
            sinalFaixaCentralLevantamentoBLL = new SinalFaixaCentralLevantamentoBLL();
            terceiraFaixaLevantamentoBLL = new TerceiraFaixaLevantamentoBLL();
            tachaFaixaBordoLevantamentoBLL = new TachaFaixaBordoLevantamentoBLL();
            tachaFaixaCentralLevantamentoBLL = new TachaFaixaCentralLevantamentoBLL();
            tiposPistaLevantamentoBLL = new TiposPistaLevantamentoBLL();
            tuneisLevantamentoBLL = new TuneisLevantamentoBLL();
            acostamentosLevantamentoBLL = new AcostamentosLevantamentoBLL();
            dominioFlagsBLL = new DominioFlagsBLL();
            dominioHidraulicaPosicoesBLL = new DominioHidraulicaPosicoesBLL();
            dominioPistaTiposBLL = new DominioPistaTiposBLL();
            dominioRegionaisBLL = new DominioRegionaisBLL();
            dominioRegionaisCodeBLL = new DominioRegionaisCodeBLL();
            dominioResidenciasBLL = new DominioResidenciasBLL();
            dominioRelevosBLL = new DominioRelevosBLL();
            dominioRevestimentosBLL = new DominioRevestimentosBLL();
            dominioRodoviassentidosBLL = new DominioRodoviassentidosBLL();
            dominioRodoviasTiposBLL = new DominioRodoviasTiposBLL();
            dominioArquivoTiposBLL = new DominioArquivoTiposBLL();
            dominioBueirosDiagnosticosBLL = new DominioBueirosDiagnosticosBLL();
            dominioBueirosMateriaisBLL = new DominioBueirosMateriaisBLL();
            dominioGradacoesBLL = new DominioGradacoesBLL();
            dominioPesosIdsBLL = new DominioPesosIdsBLL();
            dominioSuperficiesTiposBLL = new DominioSuperficiesTiposBLL();
            dominioDrenagensTiposBLL = new DominioDrenagensTiposBLL();
            dominioOaeTiposBLL = new DominioOaeTiposBLL();

            dominioPassivosAmbientaisTiposBLL = new DominioPassivosAmbientaisTiposBLL();
            dominioElementosSegurancaTiposBLL = new DominioElementosSegurancaTiposBLL();
            dominioSinalizacoesHorizontaisTiposBLL = new DominioSinalizacoesHorizontaisTiposBLL();
            dominioDispositivosTiposBLL = new DominioDispositivosTiposBLL();
            dominioEdificacoesTiposBLL = new DominioEdificacoesTiposBLL();
            dominioInstalacoesOperacionaisTiposBLL = new DominioInstalacoesOperacionaisTiposBLL();
            dominioSubestacoesReservatoriosTiposBLL = new DominioSubestacoesReservatoriosTiposBLL();
            dominioPorticosPmvsTiposBLL = new DominioPorticosPmvsTiposBLL();
            dominioEletricosTelefoniaTiposBLL = new DominioEletricosTelefoniaTiposBLL();
            dominioSinalizacoesVerticaisTiposBLL = new DominioSinalizacoesVerticaisTiposBLL();
            dominioTravessiasTiposBLL = new DominioTravessiasTiposBLL();
            dominioMateriaisBLL = new DominioMateriaisBLL();
            dominioAdministradoresBLL = new DominioAdministradoresBLL();
            dominioJurisdicoesBLL = new DominioJurisdicoesBLL();
            dominioConservadoresBLL = new DominioConservadoresBLL();
            dominioCircunscricaoBLL = new DominioCircunscricaoBLL();
            apiBueiroBLL = new ApiBueiroBLL();
            apiDispositivoBLL = new ApiDispositivoBLL();
            apiDrenagemBLL = new ApiDrenagemBLL();
            apiEdificacoesBLL = new ApiEdificacoesBLL();
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
                    if (ret.id == 2)        { JsonConvert.DeserializeObject<List<DominioRodovia>>      (ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => rodoviasBLL.SaveAPI(x));    }
                    else if (ret.id == 4)
                    {
                        //JsonConvert.DeserializeObject<List<DominioDispositivo>>  (ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dispositivoBLL.SaveAPI(x)); 
                    }
                    else if (ret.id == 56) { JsonConvert.DeserializeObject<List<AreasGramadasLevantamento>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => areasGramadasLevantamentoBLL.Save(x)); }
                    else if (ret.id == 57) { JsonConvert.DeserializeObject<List<DrenagensLinearesLevantamento>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => drenagensLinearesLevantamentoBLL.Save(x)); }
                    else if (ret.id == 58) { JsonConvert.DeserializeObject<List<CercasLevantamento>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => cercasLevantamentoBLL.Save(x)); }
                    else if (ret.id == 59) { JsonConvert.DeserializeObject<List<FaixasRolamentoLevantamento>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => faixasRolamentoLevantamentoBLL.Save(x)); }
                    else if (ret.id == 60) { JsonConvert.DeserializeObject<List<PassivosAmbientaisLinLevantamento>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => passivosAmbientaisLinLevantamentoBLL.Save(x)); }
                    else if (ret.id == 61) { JsonConvert.DeserializeObject<List<OaeLevantamento>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => oaeLevantamentoBLL.Save(x)); }
                    else if (ret.id == 62) { JsonConvert.DeserializeObject<List<PavimentacoesLevantamento>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => pavimentacoesLevantamentoBLL.Save(x)); }
                    else if (ret.id == 63) { JsonConvert.DeserializeObject<List<PavimentosRigidosLevantamento>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => pavimentosRigidosLevantamentoBLL.Save(x)); }
                    else if (ret.id == 64) { JsonConvert.DeserializeObject<List<SegurancaBordoLevantamento>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => segurancaBordoLevantamentoBLL.Save(x)); }
                    else if (ret.id == 65) { JsonConvert.DeserializeObject<List<RocadasLevantamento>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => rocadasLevantamentoBLL.Save(x)); }
                    else if (ret.id == 66) { JsonConvert.DeserializeObject<List<SegurancaCanteiroLevantamento>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => segurancaCanteiroLevantamentoBLL.Save(x)); }
                    else if (ret.id == 67) { JsonConvert.DeserializeObject<List<SegurancaGuardaCorpoLevantamento>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => segurancaGuardaCorpoLevantamentoBLL.Save(x)); }
                    else if (ret.id == 68) { JsonConvert.DeserializeObject<List<SinalFaixaBordoLevantamento>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => sinalFaixaBordoLevantamentoBLL.Save(x)); }
                    else if (ret.id == 69) { JsonConvert.DeserializeObject<List<SinalFaixaCentralLevantamento>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => sinalFaixaCentralLevantamentoBLL.Save(x)); }
                    else if (ret.id == 70) { JsonConvert.DeserializeObject<List<TerceiraFaixaLevantamento>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => terceiraFaixaLevantamentoBLL.Save(x)); }
                    else if (ret.id == 71) { JsonConvert.DeserializeObject<List<TachaFaixaBordoLevantamento>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => tachaFaixaBordoLevantamentoBLL.Save(x)); }
                    else if (ret.id == 72) { JsonConvert.DeserializeObject<List<TachaFaixaCentralLevantamento>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => tachaFaixaCentralLevantamentoBLL.Save(x)); }
                    else if (ret.id == 73) { JsonConvert.DeserializeObject<List<TiposPistaLevantamento>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => tiposPistaLevantamentoBLL.Save(x)); }
                    else if (ret.id == 74) { JsonConvert.DeserializeObject<List<TuneisLevantamento>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => tuneisLevantamentoBLL.Save(x)); }
                    else if (ret.id == 75) { JsonConvert.DeserializeObject<List<AcostamentosLevantamento>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => acostamentosLevantamentoBLL.Save(x)); }
                    else if (ret.id == 76) { JsonConvert.DeserializeObject<List<DominioFlags>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioFlagsBLL.Save(x)); }
                    //else if (ret.id == 77) { JsonConvert.DeserializeObject<List<>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => BLL.Save(x)); }
                    else if (ret.id == 78) { JsonConvert.DeserializeObject<List<DominioHidraulicaPosicoes>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioHidraulicaPosicoesBLL.Save(x)); }
                    else if (ret.id == 79) { JsonConvert.DeserializeObject<List<DominioPistaTipos>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioPistaTiposBLL.Save(x)); }
                    else if (ret.id == 80) { JsonConvert.DeserializeObject<List<DominioRegionais>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioRegionaisBLL.Save(x)); }
                    else if (ret.id == 81) { JsonConvert.DeserializeObject<List<DominioRegionaisCode>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioRegionaisCodeBLL.Save(x)); }
                    else if (ret.id == 82) { JsonConvert.DeserializeObject<List<DominioResidencias>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioResidenciasBLL.Save(x)); }
                    else if (ret.id == 83) { JsonConvert.DeserializeObject<List<DominioRelevos>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioRelevosBLL.Save(x)); }
                    else if (ret.id == 84) { JsonConvert.DeserializeObject<List<DominioRevestimentos>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioRevestimentosBLL.Save(x)); }
                    else if (ret.id == 85) { JsonConvert.DeserializeObject<List<DominioRodoviassentidos>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioRodoviassentidosBLL.Save(x)); }
                    else if (ret.id == 86) { JsonConvert.DeserializeObject<List<DominioRodoviasTipos>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioRodoviasTiposBLL.Save(x)); }
                    else if (ret.id == 87) { JsonConvert.DeserializeObject<List<DominioArquivoTipos>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioArquivoTiposBLL.Save(x)); }
                    else if (ret.id == 88) { JsonConvert.DeserializeObject<List<DominioBueirosDiagnosticos>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioBueirosDiagnosticosBLL.Save(x)); }
                    else if (ret.id == 89) { JsonConvert.DeserializeObject<List<DominioBueirosMateriais>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioBueirosMateriaisBLL.Save(x)); }
                    //else if (ret.id == 90) { JsonConvert.DeserializeObject<List<>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => BLL.Save(x)); }
                    else if (ret.id == 91) { JsonConvert.DeserializeObject<List<DominioGradacoes>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioGradacoesBLL.Save(x)); }
                    else if (ret.id == 92) { JsonConvert.DeserializeObject<List<DominioPesosIds>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioPesosIdsBLL.Save(x)); }
                    else if (ret.id == 93) { JsonConvert.DeserializeObject<List<DominioSuperficiesTipos>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioSuperficiesTiposBLL.Save(x)); }
                    else if (ret.id == 94) { JsonConvert.DeserializeObject<List<DominioDrenagensTipos>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioDrenagensTiposBLL.Save(x)); }
                    else if (ret.id == 95) { JsonConvert.DeserializeObject<List<DominioOaeTipos>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioOaeTiposBLL.Save(x)); }
                    else if (ret.id == 96) { JsonConvert.DeserializeObject<List<DominioPassivosAmbientaisTipos>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioPassivosAmbientaisTiposBLL.Save(x)); }
                    else if (ret.id == 97) { JsonConvert.DeserializeObject<List<DominioElementosSegurancaTipos>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioElementosSegurancaTiposBLL.Save(x)); }
                    else if (ret.id == 98) { JsonConvert.DeserializeObject<List<DominioSinalizacoesHorizontaisTipos>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioSinalizacoesHorizontaisTiposBLL.Save(x)); }
                    else if (ret.id == 99) { JsonConvert.DeserializeObject<List<DominioDispositivosTipos>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioDispositivosTiposBLL.Save(x)); }
                    else if (ret.id == 100) { JsonConvert.DeserializeObject<List<DominioEdificacoesTipos>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioEdificacoesTiposBLL.Save(x)); }
                    else if (ret.id == 101) { JsonConvert.DeserializeObject<List<DominioInstalacoesOperacionaisTipos>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioInstalacoesOperacionaisTiposBLL.Save(x)); }
                    else if (ret.id == 102) { JsonConvert.DeserializeObject<List<DominioSubestacoesReservatoriosTipos>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioSubestacoesReservatoriosTiposBLL.Save(x)); }
                    else if (ret.id == 103) { JsonConvert.DeserializeObject<List<DominioPorticosPmvsTipos>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioPorticosPmvsTiposBLL.Save(x)); }
                    else if (ret.id == 104) { JsonConvert.DeserializeObject<List<DominioEletricosTelefoniaTipos>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioEletricosTelefoniaTiposBLL.Save(x)); }
                    //else if (ret.id == 105) { JsonConvert.DeserializeObject<List<>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => BLL.Save(x)); }
                    else if (ret.id == 106) { JsonConvert.DeserializeObject<List<DominioSinalizacoesVerticaisTipos>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioSinalizacoesVerticaisTiposBLL.Save(x)); }
                    else if (ret.id == 107) { JsonConvert.DeserializeObject<List<DominioTravessiasTipos>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioTravessiasTiposBLL.Save(x)); }
                    else if (ret.id == 108) { JsonConvert.DeserializeObject<List<DominioMateriais>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioMateriaisBLL.Save(x)); }
                    else if (ret.id == 109) { JsonConvert.DeserializeObject<List<DominioAdministradores>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioAdministradoresBLL.Save(x)); }
                    else if (ret.id == 110) { JsonConvert.DeserializeObject<List<DominioJurisdicoes>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioJurisdicoesBLL.Save(x)); }
                    else if (ret.id == 111) { JsonConvert.DeserializeObject<List<DominioConservadores>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioConservadoresBLL.Save(x)); }
                    else if (ret.id == 112) { JsonConvert.DeserializeObject<List<DominioCircunscricao>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => dominioCircunscricaoBLL.Save(x)); }
                    else if (ret.id == 113) { JsonConvert.DeserializeObject<List<ApiBueiro>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => apiBueiroBLL.Save(x)); }
                    else if (ret.id == 114) { JsonConvert.DeserializeObject<List<ApiDispositivo>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => apiDispositivoBLL.Save(x)); }
                    else if (ret.id == 115) { JsonConvert.DeserializeObject<List<ApiDrenagem>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => apiDrenagemBLL.Save(x)); }
                    else if (ret.id == 116) { JsonConvert.DeserializeObject<List<ApiEdificacoes>>(ret.retorno.Mensagem, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver() }).ForEach(x => apiEdificacoesBLL.Save(x)); }


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