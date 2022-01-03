using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class SegurancaCanteiroLevantamentoViewModel
    {
        public int rod_id { get; set; }
        public double scc_km_inicial { get; set; }
        public double scc_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public Datetime scc_data_levantamento { get; set; }
        public double scc_extensao { get; set; }
        public int est_id { get; set; }
        public Datetime scc_data_criacao { get; set; }
        public int scc_id_segmento { get; set; }
        public string scc_dispositivo { get; set; }
        public double scc_ext_geometria { get; set; }
    }
}