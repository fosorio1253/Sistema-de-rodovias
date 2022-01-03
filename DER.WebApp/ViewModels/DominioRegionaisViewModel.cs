using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class DominioRegionaisViewModel
    {
        public int reg_id { get; set; }
        public string reg_codigo { get; set; }
        public int mun_ibge_id { get; set; }
        public string reg_descricao { get; set; }
        public string reg_endereco { get; set; }
        public string reg_bairro { get; set; }
        public string reg_cep { get; set; }
        public string reg_ddd_telefone { get; set; }
        public string reg_telefone { get; set; }
        public string reg_email { get; set; }
        public string reg_diretor { get; set; }
        public string reg_email_diretor { get; set; }
        public string reg_ddd_telefone_cco { get; set; }
        public string reg_telefone_cco { get; set; }
    }
}