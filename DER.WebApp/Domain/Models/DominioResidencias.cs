namespace DER.WebApp.Domain.Models
{
    public class DominioResidencias
    {
        public int res_id { get; set; }
        public int reg_id { get; set; }
        public string res_codigo { get; set; }
        public int mun_ibge_id { get; set; }
        public string res_descricao { get; set; }
        public string res_endereco { get; set; }
        public string res_bairro { get; set; }
        public string res_cep { get; set; }
        public string res_ddd_telefone { get; set; }
        public string res_telefone { get; set; }
        public string res_ddd_telefone_cco { get; set; }
        public string res_telefone_cco { get; set; }
        public string res_email { get; set; }
        public string res_eng_responsavel { get; set; }
        public string res_email_eng_responsavel { get; set; }
        public string res_ddd_celular_eng { get; set; }
        public string res_celular_eng { get; set; }
    }
}