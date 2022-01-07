using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class PassivosAmbientaisLinLevantamentoViewModel
    {
        public int rod_id { get; set; }
        public double pal_km_inicial { get; set; }
        public double pal_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public DateTime? pal_data_levantamento { get; set; }
        public double pal_extensao { get; set; }
        public int pat_id { get; set; }
        public DateTime? pal_data_criacao { get; set; }
        public int pal_id_segmento { get; set; }
        public string pal_dispositivo { get; set; }
        public double pal_ext_geometria { get; set; }
    }
}