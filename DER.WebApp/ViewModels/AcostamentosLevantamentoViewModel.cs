using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class AcostamentosLevantamentoViewModel
    {
        public int rod_id { get; set; }
        public double aco_km_inicial { get; set; }
        public double aco_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public datetime aco_data_levantamento { get; set; }
        public double aco_extensao { get; set; }
        public int rev_id { get; set; }
        public double aco_largura { get; set; }
        public datetime aco_data_criacao { get; set; }
        public int aco_id_segmento { get; set; }
        public string aco_dispositivo { get; set; }
        public double aco_ext_geometria { get; set; }
    }
}