﻿using System;

namespace DER.WebApp.Domain.Models
{
    public class FaixasRolamentoLevantamento
    {
        public int          rod_id { get; set; }
        public double       frl_km_inicial { get; set; }
        public double       frl_km_final { get; set; }
        public int          sen_id { get; set; }
        public int          reg_id { get; set; }
        public DateTime?    frl_data_levantamento { get; set; }
        public double       frl_extensao { get; set; }
        public int          frl_num_faixas { get; set; }
        public DateTime?    frl_data_criacao { get; set; }
        public int          frl_id_segmento { get; set; }
        public bool         frl_dispositivo { get; set; }
        public double       frl_ext_geometria { get; set; }
    }
}