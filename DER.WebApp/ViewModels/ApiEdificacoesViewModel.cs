using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class ApiEdificacoesViewModel
    {
        public int rod_id { get; set; }
        public int dis_id { get; set; }
        public int rtr_id { get; set; }
        public double edi_km { get; set; }
        public int sen_id { get; set; }
        public double edi_latitude { get; set; }
        public double edi_longitude { get; set; }
        public string edi_foto { get; set; }
        public datetime edi_data_levantamento { get; set; }
        public int edt_id { get; set; }
        public datetime edi_data_criacao { get; set; }
    }
}