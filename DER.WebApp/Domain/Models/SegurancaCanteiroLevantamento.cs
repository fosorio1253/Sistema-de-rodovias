using System;

namespace DER.WebApp.Domain.Models
{
    public class SegurancaCanteiroLevantamento
    {
        public int rod_id { get; set; }
        public double scc_km_inicial { get; set; }
        public double scc_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public DateTime? scc_data_levantamento { get; set; }
        public double scc_extensao { get; set; }
        public int est_id { get; set; }
        public DateTime? scc_data_criacao { get; set; }
        public int scc_id_segmento { get; set; }
        public bool scc_dispositivo { get; set; }
        public double scc_ext_geometria { get; set; }
    }
}