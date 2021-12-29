using System;

namespace DER.WebApp.Domain.Models
{
    public class TachaFaixaBordoLevantamento
    {
        public int rod_id { get; set; }
        public double tfb_km_inicial { get; set; }
        public double tfb_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public DateTime? tfb_data_levantamento { get; set; }
        public double tfb_extensao { get; set; }
        public int sht_id { get; set; }
        public int tfb_quantidade { get; set; }
        public DateTime? tfb_data_criacao { get; set; }
        public int tfb_id_segmento { get; set; }
        public bool tfb_dispositivo { get; set; }
        public double tfb_ext_geometria { get; set; }
    }
}