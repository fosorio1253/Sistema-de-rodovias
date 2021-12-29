using System;

namespace DER.WebApp.Domain.Models
{
    public class AcoesJudiciais
    {
        public int          ocu_acoesjud_id                     { get; set; }
        public int          ocu_acoesjud_idinteressado          { get; set; }
        public int          ocu_acoesjud_idocupacao             { get; set; }
        public int          ocu_acoesjud_idrodovia              { get; set; }
        public int          ocu_acoesjud_idtipocupacao          { get; set; }
        public int          ocu_acoesjud_idsituacaoprocessual   { get; set; }
        public string       ocu_acoesjud_cnpj                   { get; set; }
        public string       ocu_acoesjud_protocolo              { get; set; }
        public string       ocu_acoesjud_processojudicial       { get; set; }
        public string       ocu_acoesjud_historicoresumido      { get; set; }
        public string       ocu_acoesjud_motivoassinatura       { get; set; }
        public string       ocu_acoesjud_observacao             { get; set; }
        public double       ocu_acoesjud_kminicial              { get; set; }
        public double       ocu_acoesjud_kmfinal                { get; set; }
        public bool         ocu_acoesjud_cobrancapep            { get; set; }
        public bool         ocu_acoesjud_cobrancaregularizacao  { get; set; }
        public bool         ocu_acoesjud_cobrancaanuidade       { get; set; }
        public bool         ocu_acoesjud_cobrancalevantamento   { get; set; }
        public bool         ocu_acoesjud_assinatura             { get; set; }
        public DateTime?    ocu_acoesjud_datadespacho           { get; set; }
        
    }
}