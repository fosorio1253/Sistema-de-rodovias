using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class ApiDrenagemViewModel
    {
        public int rod_id { get; set; }
        public int dis_id { get; set; }
        public int rtr_id { get; set; }
        public double drp_km { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public double drp_latitude { get; set; }
        public double drp_longitude { get; set; }
        public string drp_foto { get; set; }
        public DateTime? drp_data_levantamento { get; set; }
        public int drt_id { get; set; }
        public DateTime? drp_data_criacao { get; set; }
    }
}