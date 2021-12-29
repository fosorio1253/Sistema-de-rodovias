using System.Collections.Generic;

namespace DER.WebApp.Domain.Models
{
    public class DadosMestresValores
    {
        #region Propriedades

        public int Id { get; set; }
        public int Linha { get; set; }
        public string Valor { get; set; }
        public int ColunaId { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual DadosMestresColuna Coluna { get; set; }
        public virtual ICollection<GestaoInteressado> GestaoInteressados { get; set; }
        public virtual ICollection<GestaoInteressado> GestaoInteressadosJuridica { get; set; }
        public virtual ICollection<GestaoInteressado> GestaoInteressadosTipoDeInteressado { get; set; }
        public virtual ICollection<GestaoInteressadoEndereco> GestaoInteressadosEnderecosUnidade { get; set; }
        public virtual ICollection<GestaoInteressadoEndereco> GestaoInteressadosEnderecosMunicipio { get; set; }
        public virtual ICollection<GestaoInteressadoContato> GestaoInteressadosContatosUnidades { get; set; }
        public virtual ICollection<GestaoInteressadoTipoDeConcessao> GestaoInteressadoTipoDeConcessoes { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<ProjetosMelhorias> ProjetosMelhoriasRodovia { get; set; }
        public virtual ICollection<ProjetosMelhorias> ProjetosMelhoriasRegional { get; set; }

        public virtual ICollection<GestaoOcupacao> GestoesOcupacoesRegionais { get; set; }
        public virtual ICollection<GestaoOcupacao> GestoesOcupacoesOrigens { get; set; }

        #endregion
    }
}