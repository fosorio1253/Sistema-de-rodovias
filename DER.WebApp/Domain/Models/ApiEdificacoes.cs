using System;

namespace DER.WebApp.Domain.Models
{
    public class ApiEdificacoes
    {
        public int rod_id { get; set; }
        public int dis_id { get; set; }
        public int rtr_id { get; set; }
        public double edi_km { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public double edi_latitude { get; set; }
        public double edi_longitude { get; set; }
        public string edi_foto { get; set; }
        public DateTime? edi_data_levantamento { get; set; }
        public int edt_id { get; set; }
        public DateTime? edi_data_criacao { get; set; }
    }
}