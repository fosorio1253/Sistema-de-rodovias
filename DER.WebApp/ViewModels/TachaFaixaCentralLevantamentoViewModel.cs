using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class TachaFaixaCentralLevantamentoViewModel
    {
        public int rod_id { get; set; }
        public double tfc_km_inicial { get; set; }
        public double tfc_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public DateTime? tfc_data_levantamento { get; set; }
        public double tfc_extensao { get; set; }
        public int sht_id { get; set; }
        public double tfc_quantidade { get; set; }
        public DateTime? tfc_data_criacao { get; set; }
        public double tfc_id_segmento { get; set; }
        public string tfc_dispositivo { get; set; }
        public double tfc_ext_geometria { get; set; }
    }
}