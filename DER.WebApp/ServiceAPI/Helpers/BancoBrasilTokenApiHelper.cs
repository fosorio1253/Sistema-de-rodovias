using DER.WebApp.Helper;
using DER.WebApp.ViewModels.API;

namespace DER.WebApp.ServiceAPI.Helpers
{
    public static class BancoBrasilTokenApiHelper
    {
        public static APIViewModel CreateRequestHomolog(int id, string nome)
        {
            var CLI = "eyJpZCI6IjgwNDNiNTMtZjQ5Mi00YyIsImNvZGlnb1B1YmxpY2Fkb3IiOjEwOSwiY29kaWdvU29mdHdhcmUiOjEsInNlcXVlbmNpYWxJbnN0YWxhY2FvIjoxfQ";
            var SEC = "eyJpZCI6IjBjZDFlMGQtN2UyNC00MGQyLWI0YSIsImNvZGlnb1B1YmxpY2Fkb3IiOjEwOSwiY29kaWdvU29mdHdhcmUiOjEsInNlcXVlbmNpYWxJbnN0YWxhY2FvIjoxLCJzZXF1ZW5jaWFsQ3JlZGVuY2lhbCI6MX0";
            
            var HOMOLOGAUTH = FileBase64.EncodeToBase64(CLI +":"+SEC);
            return new APIViewModel()
            {
                Id = id,
                Acao = "POST",
                NomeDoServico = nome,
                URL = @"https://oauth.hm.bb.com.br/oauth/token",
                Parameters = $"?Content-Type=application/x-www-form-urlencoded&cache-control=no-cache&grant_type=client_credentials&Authorization=Basic {HOMOLOGAUTH}"
            };
        }

        public static APIViewModel CreateRequestProd(int id, string nome, string ClientID, string Secret)
        {
            var HOMOLOGAUTH = FileBase64.EncodeToBase64(ClientID + ":" + Secret);
            return new APIViewModel()
            {
                Id = id,
                Acao = "POST",
                NomeDoServico = nome,
                URL = @"https://oauth.bb.com.br/oauth/token",
                Parameters = $"?Content-Type=application/x-www-form-urlencoded&cache-control=no-cache&grant_type=client_credentials&Authorization=Basic {HOMOLOGAUTH}"
            };
        }
    }
}