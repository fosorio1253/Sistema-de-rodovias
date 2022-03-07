using DER.WebApp.Domain.Business;
using DER.WebApp.ViewModels.API;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace DER.WebApp.Controllers
{
    public class ApiSgfdController : APIController
    {
        private string Key = "aZffHjk2FQmFVNiMAsFc3aK4Ldtdf8Fo";
        private string Msg = "Você não possui permissão para acessar esta API. Entrar em contato com o Administrador.";
        private ApiGetOcupacaoBLL apiGetOcupacaoBLL;

        private int codRod;
        private double kmInicial;
        private double kmFinal;

        public ApiSgfdController()
        {
            apiGetOcupacaoBLL = new ApiGetOcupacaoBLL();
        }

        [HttpGet]
        public ActionResult GetOcupacoes(string api_key, int cod_rod = 0, double km_inicial = 0, double km_final = 0)
        {
            Setvalues(cod_rod, km_inicial, km_final); return Json(api_key.Equals(Key) ?  MessageTrue() : MessageFalse(), JsonRequestBehavior.AllowGet);
        }

        private void Setvalues(int cod_rod, double km_inicial, double km_final)
        {
            codRod = cod_rod;
            kmInicial = km_inicial;
            kmFinal = km_final;
        }

        private RetornoHealtCheckAPI MessageTrue()
        {
            try { return new RetornoHealtCheckAPI() { Sucesso = true, Mensagem = Execute() }; }
            catch (Exception ex) { return new RetornoHealtCheckAPI() { Sucesso = false, Mensagem = ex.Message }; }
        }

        private RetornoHealtCheckAPI MessageFalse()
        {
            return new RetornoHealtCheckAPI() { Sucesso = false, Mensagem = Msg };
        }

        private string Execute()
        {
            try                 { return JsonConvert.SerializeObject(apiGetOcupacaoBLL.BuscarApiGetOcupacao(codRod, kmInicial, kmFinal)); }
            catch (Exception e) { return e.Message; }
        }
    }
}