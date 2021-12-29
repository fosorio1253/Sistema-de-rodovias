using DER.WebApp.ViewModels.API;

namespace DER.WebApp.ServiceAPI.Helpers
{
    public static class HistoricoCaracterizacoesApiHelper
    {
        public static APIViewModel CreateRequest(int id, string nome, string modulo, int? regId = null)
        {
            return new APIViewModel()
            {
                Id = id,
                Acao = "POST",
                NomeDoServico = nome,
                URL = @"http://der.planservi.com.br/Sirgeo/SIRGeoAPI/HistoricoCaracterizacoes",
                Parameters = @"?usu_id=851166&token=tokenReplace" +
                            ((modulo != null) ? "&modulo=" + modulo : string.Empty) +
                            ((regId != null) ? "&reg_id=" + regId : string.Empty)
            };
        }
    }
}