using System;

namespace DER.WebApp.ViewModels
{
    public class TerceiraFaixaLevantamentoViewModel
    {
        public int terceira_faixa_levantamento_id { get; set; }
        public double tfx_km_inicial { get; set; }
        public double tfx_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public DateTime? tfx_data_levantamento { get; set; }
        public double tfx_extensao { get; set; }
        public DateTime? tfx_data_criacao { get; set; }
        public int tfx_id_segmento { get; set; }
        public string tfx_dispositivo { get; set; }
         public double tfx_ext_geometria { get; set; }
    }
}