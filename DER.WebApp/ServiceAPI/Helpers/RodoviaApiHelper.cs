using DER.WebApp.ViewModels.API;

namespace DER.WebApp.ServiceAPI.Helpers
{
    public static class RodoviaApiHelper
    {
        public static APIViewModel CreateRequest(int id, string nome, string codRodovia = null)
        {
            return new APIViewModel()
            {
                Id = id,
                Acao = "POST",
                NomeDoServico = nome,
                URL = @"http://der.planservi.com.br/Sirgeo/SIRGeoAPI/Rodovias",
                Parameters = "?usu_id=851166&token=tokenReplace" + ((codRodovia != null) ? "&rod_Codigo=" + codRodovia : string.Empty)
            };
        }
    }
}