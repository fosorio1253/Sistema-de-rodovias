namespace DER.WebApp.ViewModels.Validadores
{
    public class GestaoInteressadoValidatorViewModel
    {
        public int id { get; set; }
        public bool validCNPJ { get; set; }
        public bool validCPF { get; set; }
        public bool valid { get; set; }
    }
}