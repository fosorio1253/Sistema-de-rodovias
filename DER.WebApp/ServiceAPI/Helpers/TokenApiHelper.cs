using DER.WebApp.ViewModels.API;

namespace DER.WebApp.ServiceAPI.Helpers
{
    public static class TokenApiHelper
    {
        public static APIViewModel CreateRequest(int id, string nome)
        {
            return new APIViewModel()
            {
                Id = id,
                Acao = "POST",
                NomeDoServico = nome,
                URL = @"http://der.planservi.com.br/Sirgeo/SIRGeoAPI/Token?usu_id=851166",
            };
        }
    }
}