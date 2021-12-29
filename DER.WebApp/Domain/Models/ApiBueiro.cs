using System;

namespace DER.WebApp.Domain.Models
{
    public class ApiBueiro
    {
        public int rod_id { get; set; }
        public int dis_id { get; set; }
        public int rtr_id { get; set; }
        public double ace_km { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public double ace_latitude { get; set; }
        public double ace_longitude { get; set; }
        public string ace_foto { get; set; }
        public DateTime? ace_data_levantamento { get; set; }
        public int stp_id { get; set; }
        public double ace_largura { get; set; }
        public DateTime? ace_data_criacao { get; set; }
    }
}