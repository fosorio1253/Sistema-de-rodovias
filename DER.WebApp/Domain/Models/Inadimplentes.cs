using System;

namespace DER.WebApp.Domain.Models
{
    public class Inadimplentes
    {
        public int          ina_id              { get; set; }
        public Int64        ina_cpfcnpj         { get; set; }
        public Int64        ina_protocolo       { get; set; }
        public Int64        ina_processo        { get; set; }
        public int          ina_interessadoid   { get; set; }
        public int          ina_tipoocupacaoid  { get; set; }
        public int          ina_dias            { get; set; }
        public string       ina_tipofaturamento { get; set; }
        public string       ina_statusboleto    { get; set; }
        public decimal      ina_valortotal      { get; set; }
        public decimal      ina_valorprevisto   { get; set; }
        public bool         ina_ativo           { get; set; }
        public DateTime?    ina_periodo         { get; set; }
        public DateTime?    ina_datavenciemntoprimeiro  { get; set; }
        public DateTime?    ina_datavenciemntosegundo   { get; set; }
    }
}