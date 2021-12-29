using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DER.WebApp.ViewModels.ConsultarRodovias
{
    public class ConsultarRodoviasViewModels
    {
        public double Quilometro { get; set; }
        public string BordaEsquerda { get; set; }
        public string Centro { get; set; }
        public string BordaDireita { get; set; }        
    }

    public class ConsultarRodoviasViewModelsParams
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int RodoviaId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public double KmInicial { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public double KmFinal { get; set; }

        public bool RedeEletrica { get; set; }

        public bool RedeTelecomunicativa { get; set; }

        public bool EstacaoTelefonia { get; set; }

        public bool RedePluvial { get; set; }

        public bool AdutoraAgua { get; set; }

        public bool Oleodutos { get; set; }

        public bool Gasodutos { get; set; }

        public bool DispositivosOCR { get; set; }

        public bool Outros { get; set; }

        public virtual SelectList Rodovias { get; set; }
    }
}