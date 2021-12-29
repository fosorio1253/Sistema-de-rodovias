using System;

namespace DER.WebApp.Domain.Models
{
    public class RocadasLevantamento
    {
        public int rod_id { get; set; }
        public double rcd_km_inicial { get; set; }
        public double rcd_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public DateTime? rcd_data_levantamento { get; set; }
        public double rcd_extensao { get; set; }
        public DateTime? rcd_data_criacao { get; set; }
        public int rcd_id_segmento { get; set; }
        public bool rcd_dispositivo { get; set; }
        public double rcd_ext_geometria { get; set; }
    }
}