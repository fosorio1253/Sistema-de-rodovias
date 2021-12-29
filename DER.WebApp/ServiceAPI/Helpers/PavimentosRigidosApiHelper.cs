using DER.WebApp.ViewModels.API;

namespace DER.WebApp.ServiceAPI.Helpers
{
    public static class PavimentosRigidosApiHelper
    {
        public static APIViewModel CreateRequest(int id, string nome, string sufixoURL, int? rodId)
        {
            return new APIViewModel()
            {
                Id = id,
                Acao = "POST",
                NomeDoServico = nome,
                URL = @"http://der.planservi.com.br/Sirgeo/SIRGeoAPI/" + sufixoURL,
                Parameters = @"?usu_id=851166&token=tokenReplace" +
                            ((rodId != null) ? "&rod_id=" + rodId : string.Empty)
            };
        }
    }
}