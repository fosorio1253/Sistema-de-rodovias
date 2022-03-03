namespace DER.WebApp.ViewModels
{
    public class ApiGetOcupacaoRetornoViewModel
    {
        public int numero_termo { get; set; }
        public string interessado { get; set; }
        public string tipo_de_implantacao { get; set; }
        public string situacao { get; set; }
        public string tipo_de_ocupacao { get; set; }
        public double km_inicial { get; set; }
        public double km_final { get; set; }
        public string lado { get; set; }
        public double altura_da_ocupacao_aerea { get; set; }
        public double profundidade_da_ocupacao_subterranea { get; set; }
    }
}