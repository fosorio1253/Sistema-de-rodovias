using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class FaixasRolamentoLevantamentoViewModel
    {
        public int rod_id { get; set; }
        public double frl_km_inicial { get; set; }
        public double frl_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public datetime frl_data_levantamento { get; set; }
        public double frl_extensao { get; set; }
        public double frl_num_faixas { get; set; }
        public datetime frl_data_criacao { get; set; }
        public int frl_id_segmento { get; set; }
        public string frl_dispositivo { get; set; }
        public double frl_ext_geometria { get; set; }
    }
}