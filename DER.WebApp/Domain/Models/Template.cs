using System;
namespace DER.WebApp.Domain.Models
{
    public class Template
    {
        public int Id { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }

        public Template(){}
    }
}
