using DER.WebApp.ServiceAPI.Model;
using DER.WebApp.ViewModels.API;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;

namespace DER.WebApp.ServiceAPI.Helpers
{
    public static class ExecServiceApiHelper
    {
        public static string ExecRequestToken(APIViewModel viewModel)
        {
            string retorno = string.Empty;

            var dados = Encoding.UTF8.GetBytes(string.Empty);
            var request = WebRequest.CreateHttp(viewModel.URL);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = dados.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(dados, 0, dados.Length);
                stream.Close();
            }

            using (var resposta = request.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                var post = JsonConvert.DeserializeObject<TokenResponse>(objResponse.ToString());
                retorno = post.tok_token;
                streamDados.Close();
                
                resposta.Close();
            }

            return retorno;
        }

        public static RetornoHealtCheckAPI ExecRequest(APIViewModel viewModel, string token)
        {
            var retorno = new RetornoHealtCheckAPI()
            {
                Sucesso = true,
                Mensagem = string.Empty
            };

            viewModel.URL += viewModel.Parameters.Replace("tokenReplace", token);

            var dados = Encoding.UTF8.GetBytes(string.Empty);
            var request = WebRequest.CreateHttp(viewModel.URL);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = dados.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(dados, 0, dados.Length);
                stream.Close();
            }

            using (var resposta = request.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                retorno.Mensagem = objResponse.ToString();
                streamDados.Close();
                resposta.Close();
            }

            return retorno;
        }
    }
}