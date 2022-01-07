using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class SinalFaixaBordoLevantamentoViewModel
    {
        public int rod_id { get; set; }
        public double sfb_km_inicial { get; set; }
        public double sfb_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public DateTime? sfb_data_levantamento { get; set; }
        public int sfb_extensao { get; set; }
        public int sht_id { get; set; }
        public int sfb_largura_faixa { get; set; }
        public DateTime? sfb_data_criacao { get; set; }
        public int sfb_id_segmento { get; set; }
        public string sfb_dispositivo { get; set; }
        public double sfb_ext_geometria { get; set; }
    }
}