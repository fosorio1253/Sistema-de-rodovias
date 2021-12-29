using System;

namespace DER.WebApp.Domain.Models
{
    public class DrenagensLinearesLevantamento
    {
        public int          rod_id { get; set; }
        public double       drl_km_inicial { get; set; }
        public double       drl_km_final { get; set; }
        public int          sen_id { get; set; }
        public int          reg_id { get; set; }
        public DateTime?    drl_data_levantamento { get; set; }
        public double       drl_extensao { get; set; }
        public int          drt_id { get; set; }
        public DateTime?    drl_data_criacao { get; set; }
        public int          drl_id_segmento { get; set; }
        public bool         drl_dispositivo { get; set; }
        public double       drl_ext_geometria { get; set; }
    }
}