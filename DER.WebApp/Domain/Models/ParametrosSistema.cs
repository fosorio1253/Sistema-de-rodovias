using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Models
{
    public class ParametrosSistema
    {
        public int parametros_sistema_id { get; set; }
        public string area_nome { get; set; }
        public string lado_nome { get; set; }
        public string natureza_juridica_descricao { get; set; }
        public string origem_da_solicitacao_nome { get; set; }
        public string ocorrencia_severidade_nome { get; set; }
        public string ocorrencia_status_nome { get; set; }
        public string ocorrencia_trecho_nome { get; set; }
        public string situacao_solicitacao_nome { get; set; }
        public string situacao_ocupacao_nome { get; set; }
        public string tipo_documento_descricao { get; set; }
        public string tipo_implantacao_nome { get; set; }
        public string tipo_passagem_nome { get; set; }
        public string tipo_empresa_descricao { get; set; }
        public string tipo_interferencia_nome { get; set; }
        public string tipo_documento_ocupao_descricao { get; set; }
    }
}