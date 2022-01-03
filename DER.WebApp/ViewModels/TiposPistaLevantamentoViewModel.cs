using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class TiposPistaLevantamentoViewModel
    {
        public int rod_id { get; set; }
        public double rpt_km_inicial { get; set; }
        public double rpt_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public Datetime rpt_data_levantamento { get; set; }
        public double rpt_extensao { get; set; }
        public int ptp_id { get; set; }
        public Datetime rpt_data_criacao { get; set; }
        public int rpt_id_segmento { get; set; }
        public string rpt_dispositivo { get; set; }
        public double rpt_ext_geometria { get; set; }
    }
}