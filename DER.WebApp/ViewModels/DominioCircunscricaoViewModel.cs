using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class DominioCircunscricaoViewModel
    {
        public int rod_id { get; set; }
        public double cer_km_inicial { get; set; }
        public double cer_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public datetime cer_data_levantamento { get; set; }
        public double cer_extensao { get; set; }
        public double cer_distancia_eixo { get; set; }
        public datetime cer_data_criacao { get; set; }
        public int cer_id_segmento { get; set; }
        public double cer_dispositivo { get; set; }
    }
}