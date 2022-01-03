using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class TachaFaixaBordoLevantamentoViewModel
    {
        public int rod_id { get; set; }
        public double tfb_km_inicial { get; set; }
        public double tfb_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public Datetime tfb_data_levantamento { get; set; }
        public double tfb_extensao { get; set; }
        public int sht_id { get; set; }
        public double tfb_quantidade { get; set; }
        public Datetime tfb_data_criacao { get; set; }
        public int tfb_id_segmento { get; set; }
        public string tfb_dispositivo { get; set; }
        public double tfb_ext_geometria { get; set; }
    }
}