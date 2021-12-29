namespace DER.WebApp.ViewModels.GestaoInteressados
{
    public class TipoDeConcessaoViewModel
    {
        public int TipoConcessaoId { get; set; }
        public int IdGestao { get; set; }
        public string Nome { get; set; }
        public bool Marcado { get; set; }
        public string Documentos { get; set; }
        public double AlturaMinima { get; set; }
        public double ProfundidadeMinima { get; set; }
    }
}