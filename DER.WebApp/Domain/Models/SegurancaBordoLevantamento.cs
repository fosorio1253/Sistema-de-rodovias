using System;

namespace DER.WebApp.Domain.Models
{
    public class SegurancaBordoLevantamento
    {
        public int rod_id { get; set; }
        public double sbd_km_inicial { get; set; }
        public double sbd_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public DateTime? sbd_data_levantamento { get; set; }
        public double sbd_extensao { get; set; }
        public int est_id { get; set; }
        public DateTime? sbd_data_criacao { get; set; }
        public int sbd_id_segmento { get; set; }
        public bool sbd_dispositivo { get; set; }
        public double sbd_ext_geometria { get; set; }
    }
}