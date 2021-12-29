﻿using System;

namespace DER.WebApp.Domain.Models
{
    public class PavimentacoesLevantamento
    {
        public int rod_id { get; set; }
        public double rpv_km_inicial { get; set; }
        public double rpv_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public DateTime? rpv_data_levantamento { get; set; }
        public int rev_id { get; set; }
        public double rpv_extensao { get; set; }
        public DateTime? rpv_data_criacao { get; set; }
        public int rpv_id_segmento { get; set; }
        public bool rpv_dispositivo { get; set; }
        public double rpv_ext_geometria { get; set; }
    }
}