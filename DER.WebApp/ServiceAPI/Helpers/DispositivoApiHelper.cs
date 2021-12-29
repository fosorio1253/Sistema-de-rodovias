using DER.WebApp.ViewModels.API;

namespace DER.WebApp.ServiceAPI.Helpers
{
    public class DispositivoApiHelper
    {
        public static APIViewModel CreateRequest(int id, string nome, int? disId = null, string disCodigo = null, int? rodId = null, int? ativo = null)
        {
            return new APIViewModel()
            {
                Id = id,
                Acao = "POST",
                NomeDoServico = nome,
                URL = @"http://der.planservi.com.br/Sirgeo/SIRGeoAPI/Dispositivos",
                Parameters = @"?usu_id=851166&token=tokenReplace" +
                            ((disId != null) ? "&dis_id=" + disId : string.Empty) +
                            ((disCodigo != null) ? "&dis_codigo=" + disCodigo : string.Empty) +
                            ((rodId != null) ? "&rod_id=" + rodId : string.Empty) +
                            ((ativo != null) ? "&ativo=1" : string.Empty)
            };
        }
    }
}