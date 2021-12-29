using System;

namespace DER.WebApp.Domain.Models
{
    public class SinalFaixaCentralLevantamento
    {
        public int rod_id { get; set; }
        public double sfc_km_inicial { get; set; }
        public double sfc_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public DateTime? sfc_data_levantamento { get; set; }
        public double sfc_extensao { get; set; }
        public int sht_id { get; set; }
        public double sfc_largura_faixa { get; set; }
        public DateTime? sfc_data_criacao { get; set; }
        public int sfc_id_segmento { get; set; }
        public bool sfc_dispositivo { get; set; }
        public double sfc_ext_geometria { get; set; }
    }
}