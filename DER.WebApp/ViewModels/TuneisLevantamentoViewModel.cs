using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class TuneisLevantamentoViewModel
    {
        public int rod_id { get; set; }
        public double tun_km_inicial { get; set; }
        public double tun_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public DateTime? tun_data_levantamento { get; set; }
        public double tun_extensao { get; set; }
        public DateTime? tun_data_criacao { get; set; }
        public int tun_id_segmento { get; set; }
        public string tun_dispositivo { get; set; }
        public double tun_ext_geometria { get; set; }
    }
}