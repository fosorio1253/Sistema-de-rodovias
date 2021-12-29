using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace DER.WebApp.ViewModels
{
    public class GestaoInteressadosViewModel
    {
        public GestaoInteressadosViewModel()
        {
            GruposIDs = new List<int>();
            EmpresasIDs = new List<int>();
            Requerimentos = new List<int>();
        }

        public string NumeroSPDOC { get; set; }
        public int StatusSPDOC { get; set; } = (int)StatusAprovacaoEnum.AguardandoAprovacao;
        public string Nome { get; set; }
        public string NaturezaJuridica { get; set; }
        public string CNPJ { get; set; }
        public string TipoEmpresa { get; set; }
        public DateTime Validade { get; set; }
        public int Status { get; set; } = (int)StatusAprovacaoEnum.AguardandoAprovacao;
        public string NomeFantasia { get; set; }
        public string TipoInteressado { get; set; }
        public string Endereco { get; set; }
        public string NumeroEndereco { get; set; }
        public string ComplementoEndereco { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Municipio { get; set; }

        [MaxLength(2, ErrorMessage = "A sigla do estado deve ter apenas 2 caracteres")]
        [MinLength(2, ErrorMessage = "A sigla do estado deve ter apenas 2 caracteres")] 
        public string Estado { get; set; }
        public string Telefone { get; set; }

        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        //Endereço de Cobrança Modal
        public string UnidadeCobranca { get; set; }
        public string EnderecoCobranca { get; set; }
        public string CEPCobranca { get; set; }
        public string NumeroCobranca { get; set; }
        public string ComplementoCobranca { get; set; }
        public string BairroCobranca { get; set; }
        public string MunicipioCobranca { get; set; }
        public string EstadoCobranca { get; set; }
        public string NomeContatoCobranca { get; set; }

        //Contato Externo Modal
        public List<int> GruposIDs { get; set; }

        public List<int> EmpresasIDs { get; set; }

        public string TelefoneRamal { get; set; }
        public string DDD { get; set; }

        [EmailAddress]
        [MaxLength(255, ErrorMessage = "O tamanho máximo é de 255 caracteres")]
        public string EmailContato { get; set; }
        public string Login { get; set; }
        public string Cargo { get; set; }
        public string NomeContato { get; set; }
        public string EnderecoContato { get; set; }
        public string NumeroContato { get; set; }
        public string ComplementoContato { get; set; }
        public string MunicipioContato { get; set; }        
        public string BairroContato { get; set; }
        public string CEPContato { get; set; }
        public string EstadoContato { get; set; }

        //Documentos Modal
        public List<int> Requerimentos { get; set; }

        //Observações Modal
        public string Observacao { get; set; }
    }
}