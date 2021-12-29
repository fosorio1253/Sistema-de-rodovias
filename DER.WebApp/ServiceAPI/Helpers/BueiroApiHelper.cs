using DER.WebApp.ViewModels.API;


namespace DER.WebApp.ServiceAPI.Helpers
{
    public static class BueiroApiHelper
    {
        public static APIViewModel CreateRequest(int id, string nome, int? rodId = null, decimal? kmi = null, decimal? kmf = null)
        {
            return new APIViewModel()
            {
                Id = id,
                Acao = "POST",
                NomeDoServico = nome,
                URL = @"http://der.planservi.com.br/Sirgeo/SIRGeoAPI/Bueiros",
                Parameters = @"?usu_id=851166&token=tokenReplace" +
                            ((rodId != null) ? "&rod_id=" + rodId : string.Empty) +
                            ((kmi != null) ? "&kmi=" + kmi : string.Empty) +
                            ((kmf != null) ? "&kmf=" + kmf : string.Empty)
            };
        }
    }
}