namespace DER.WebApp.ViewModels.ProjetosMelhorias
{
    public class RodoviaViewModel
    {
        public int RodoviaId { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public int rod_id { get; set; }
        public string rod_codigo { get; set; }
        public int jur_id_origem { get; set; }
        public int rte_id { get; set; }
        public int ror_id { get; set; }
        public double rod_km_inicial { get; set; }
        public double rod_km_final { get; set; }
        public double rod_km_extensao { get; set; }
    }
}