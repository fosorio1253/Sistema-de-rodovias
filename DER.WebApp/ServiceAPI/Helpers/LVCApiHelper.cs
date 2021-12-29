using DER.WebApp.ViewModels.API;

namespace DER.WebApp.ServiceAPI.Helpers
{
    public static class LVCApiHelper
    {
        public static APIViewModel CreateRequest(int id, string nome, int? rodId = null, decimal? segmento_kmi = null, decimal? segmento_kmf = null)
        {
            return new APIViewModel()
            {
                Id = id,
                Acao = "POST",
                NomeDoServico = nome,
                URL = @"http://der.planservi.com.br/Sirgeo/SIRGeoAPI/Lvc",
                Parameters = @"?usu_id=851166&token=tokenReplace" +
                            ((rodId != null) ? "&rod_id=" + rodId : string.Empty) +
                            ((segmento_kmi != null) ? "&segmento_kmi=" + segmento_kmi : string.Empty) +
                            ((segmento_kmf != null) ? "&segmento_kmf=" + segmento_kmf : string.Empty)
            };
        }
    }
}