using DER.WebApp.Domain.Business;
using DER.WebApp.ViewModels.API;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace DER.WebApp.Controllers
{
    public class ApiSgfdController : APIController
    {
        private ApiGetOcupacaoBLL apiGetOcupacaoBLL;
        private string Key = "aZffHjk2@Qm#VNiMAs@c3aK4Ldtdf8#o";

        public ApiSgfdController()
        {
            apiGetOcupacaoBLL = new ApiGetOcupacaoBLL();
        }

        [HttpGet]
        public ActionResult GetOcupacoes(string api_key, int cod_rod = 0, double km_inicial = 0, double km_final = 0)
        {
            try
            {
                return Json(api_key.Equals(Key) ? 
                    new RetornoHealtCheckAPI(){ Sucesso = true, Mensagem = JsonConvert.SerializeObject(apiGetOcupacaoBLL.BuscarApiGetOcupacao(cod_rod, km_inicial, km_final))} :
                    new RetornoHealtCheckAPI() { Sucesso = false, Mensagem = "Você não possui permissão para acessar esta API. Entrar em contato com o Administrador." });
            }
            catch (Exception ex)
            {
                return Json(new RetornoHealtCheckAPI()
                {
                    Sucesso = false,
                    Mensagem = ex.Message
                });
            }
        }
    }
}