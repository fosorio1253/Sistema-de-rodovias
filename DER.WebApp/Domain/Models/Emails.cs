using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace DER.WebApp.Domain.Models
{
    public class Emails
    {
        #region Propriedades

        public int Id { get; set; }
        public string Assunto { get; set; }
        public string CorpoEmail { get; set; }
        public string Codigo { get; set; }
        public string CC { get; set; }
        public string Destinatario { get; set; }
        public DateTime DataEnvio { get; set; }

        [NotMapped]
        public HttpPostedFileBase Anexo { get; set; }
        #endregion
    }
}