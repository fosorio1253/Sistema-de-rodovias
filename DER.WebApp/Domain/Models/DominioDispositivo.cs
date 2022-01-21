using System;

namespace DER.WebApp.Domain.Models
{
    public class DominioDispositivo
    {
        public int dis_id { get; set; }
        public int rod_id { get; set; }
        public string dis_codigo { get; set; }
        public int dit_id { get; set; }
        public double dis_km_localizacao { get; set; }
        public double dis_extensao { get; set; }
        public string dis_descricao1 { get; set; }
        public string dis_descricao2 { get; set; }
        public int mun_ibge_id { get; set; }
        public int jur_id { get; set; }
        public int adm_id { get; set; }
        public int con_id { get; set; }
        public int stp_id { get; set; }
        public string dis_perimetro_urbano { get; set; }
        public string dis_denominacao { get; set; }
        public string dis_legislacao { get; set; }
        public string dis_TPUso { get; set; }
        public string dis_transf_mun { get; set; }
        public string dis_observacao { get; set; }
        public string dis_subtrecho { get; set; }
        public DateTime? dis_ano_implantacao { get; set; }
        public DateTime? dis_data_atualizacao { get; set; }
    }
}