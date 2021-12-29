using System;

namespace DER.WebApp.ServiceAPI.Model
{
    public class TokenResponse
    {
        public string tok_token { get; set; }
        public DateTime tok_validade { get; set; }
        public string tok_mensagem { get; set; }
        public bool tok_valido { get; set; }
    }
}