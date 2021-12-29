using System;

namespace DER.WebApp.Domain.Models
{
    public class OaeLevantamento
    {
        public int rod_id { get; set; }
        public double oae_km_inicial { get; set; }
        public double oae_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public DateTime? oae_data_levantamento { get; set; }
        public double oae_extensao { get; set; }
        public int oat_id { get; set; }
        public DateTime? oae_data_criacao { get; set; }
        public int oae_id_segmento { get; set; }
        public bool oae_dispositivo { get; set; }
        public double oae_ext_geometria { get; set; }
    }
}