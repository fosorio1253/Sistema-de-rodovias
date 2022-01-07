using System;

namespace DER.WebApp.ViewModels
{
    public class AreasGramadasLevantamentoViewModel
    {
        public int rod_id { get; set; }
        public double agr_km_inicial { get; set; }
        public double agr_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public DateTime? agr_data_levantamento { get; set; }
        public double agr_extensao { get; set; }
        public double agr_largura { get; set; }
        public int agr_id_segmento { get; set; }
        public string agr_dispositivo { get; set; }
        public double agr_ext_geometria { get; set; }
        public DateTime? agr_data_criacao { get; set; }
}
}