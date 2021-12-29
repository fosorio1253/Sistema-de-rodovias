using System;

namespace DER.WebApp.Domain.Models
{
    public class CercasLevantamento
    {
        public int          rod_id { get; set; }
        public double       cer_km_inicial { get; set; }
        public double       cer_km_final { get; set; }
        public int          sen_id { get; set; }
        public int          reg_id { get; set; }
        public DateTime?    cer_data_levantamento { get; set; }
        public double       cer_extensao { get; set; }
        public double       cer_distancia_eixo { get; set; }
        public DateTime?    cer_data_criacao { get; set; }
        public int          cer_id_segmento { get; set; }
        public bool         cer_dispositivo { get; set; }
        public double       cer_ext_geometria { get; set; }
    }
}