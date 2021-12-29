using System;

namespace DER.WebApp.Domain.Models
{
    public class PavimentosRigidosLevantamento
    {
        public int rod_id { get; set; }
        public double pvr_km_inicial { get; set; }
        public double pvr_km_final { get; set; }
        public int sen_id { get; set; }
        public int reg_id { get; set; }
        public DateTime? pvr_data_levantamento { get; set; }
        public double pvr_extensao { get; set; }
        public int rev_id { get; set; }
        public DateTime? pvr_data_criacao { get; set; }
    }
}