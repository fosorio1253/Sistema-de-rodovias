using System;

namespace DER.WebApp.Domain.Models
{
    public class ApiDispositivo
    {
        public int rod_id { get; set; }
        public int dis_id { get; set; }
        public int rtr_id { get; set; }
        public double dis_km { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public double dis_latitude { get; set; }
        public double dis_longitude { get; set; }
        public string dis_foto { get; set; }
        public DateTime? dis_data_levantamento { get; set; }
        public int dit_id { get; set; }
        public DateTime? dis_data_criacao { get; set; }
    }
}