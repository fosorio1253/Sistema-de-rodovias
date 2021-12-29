using DER.WebApp.ViewModels.API;

namespace DER.WebApp.ServiceAPI.Helpers
{
    public static class DominioApiHelper
    {
        public static APIViewModel CreateRequest(int id, string nome, string sufixoURL, string dominio)
        {
            return new APIViewModel()
            {
                Id = id,
                Acao = "POST",
                NomeDoServico = nome,
                URL = @"http://der.planservi.com.br/Sirgeo/SIRGeoAPI/" + sufixoURL,
                Parameters = @"?usu_id=851166&token=tokenReplace" +
                            ((dominio != null) ? "&dominio=" + dominio : string.Empty)
            }; 
        }
    }
}