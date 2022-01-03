﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class OaeLevantamentoViewModel
    {
        public int rod_id { get; set; }
        public double oae_km_inicial { get; set; }
        public double oae_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public Datetime oae_data_levantamento { get; set; }
        public double oae_extensao { get; set; }
        public int oat_id { get; set; }
        public Datetime oae_data_criacao { get; set; }
        public int oae_id_segmento { get; set; }
    public double oae_ext_geometria { get; set; }
}
}