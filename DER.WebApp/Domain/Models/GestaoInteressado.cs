using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace DER.WebApp.Domain.Models
{
    public class GestaoInteressado
    {
        #region Propriedades

        public int Id { get; set; }
        public bool Ativo { get; set; }
        public string NumeroSPDOC { get; set; }
        public string StatusSPDOC { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int? NaturezaJuridicaId { get; set; }
        public string Documento { get; set; }
        public string MatrizOuFilial { get; set; }
        public DateTime? ValidoAte { get; set; }
        public int? StatusAprovacaoId { get; set; }
        public string UsuarioAtualizacao { get; set; }
        public int UsuarioId { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string NomeFantasia { get; set; }
        public int? TipoDeInteressadoId { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual DadosMestresValores NaturezaJuridica { get; set; }
        public virtual StatusAprovacao StatusAprovacao { get; set; }
        public virtual DadosMestresValores TipoDeInteressado { get; set; }
        public virtual ICollection<GestaoInteressadoTipoDeConcessao> GestaoInteressadosTiposDeConcessoes { get; set; }
        public virtual ICollection<GestaoInteressadoContato> Contatos { get; set; }
        public virtual ICollection<GestaoInteressadoEndereco> Enderecos { get; set; }
        public virtual ICollection<GestaoInteressadoDocumento> Documentos { get; set; }
        public virtual ICollection<GestaoInteressadoObservacao> Observacoes { get; set; }
        public virtual ICollection<GestaoOcupacao> GestoesOcupacoes { get; set; }

        [NotMapped]
        public HttpPostedFileBase[] Files { get; set; }

        #endregion
    }
}