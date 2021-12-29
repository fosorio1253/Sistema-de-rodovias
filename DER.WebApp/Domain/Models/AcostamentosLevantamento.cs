using System;

namespace DER.WebApp.Domain.Models
{
    public class AcostamentosLevantamento
    {
        public int rod_id { get; set; }
        public double aco_km_inicial { get; set; }
        public double aco_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public DateTime? aco_data_levantamento { get; set; }
        public double aco_extensao { get; set; }
        public int rev_id { get; set; }
        public double aco_largura { get; set; }
        public DateTime? aco_data_criacao { get; set; }
        public int aco_id_segmento { get; set; }
        public bool aco_dispositivo { get; set; }
        public double aco_ext_geometria { get; set; }
    }
}