using System;

namespace DER.WebApp.Domain.Models
{
    public class DominioCircunscricao
    {
        public int rod_id { get; set; }
        public double cer_km_inicial { get; set; }
        public double cer_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public DateTime? cer_data_levantamento { get; set; }
        public double cer_extensao { get; set; }
        public double cer_distancia_eixo { get; set; }
        public DateTime? cer_data_criacao { get; set; }
        public int cer_id_segmento { get; set; }
        public double cer_dispositivo { get; set; }

        public int res_id { get; set; }
        public string res_codigo { get; set; }
    }
}