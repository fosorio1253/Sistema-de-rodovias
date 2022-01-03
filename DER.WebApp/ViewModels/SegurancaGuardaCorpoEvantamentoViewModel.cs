using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class SegurancaGuardaCorpoEvantamentoViewModel
    {
        public int rod_id { get; set; }
        public double sgc_km_inicial { get; set; }
        public double sgc_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public Datetime sgc_data_levantamento { get; set; }
        public double sgc_extensao { get; set; }
        public int mat_id { get; set; }
        public Datetime sgc_data_criacao { get; set; }
        public int sgc_id_segmento { get; set; }
        public string sgc_dispositivo { get; set; }
        public double sgc_ext_geometria { get; set; }
    }
}