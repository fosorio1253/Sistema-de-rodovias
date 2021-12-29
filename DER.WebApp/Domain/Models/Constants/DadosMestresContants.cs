using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Models.Constants
{
    public static class DadosMestresConstants
    {
        public static readonly StaticPermissao TipoInteressado = new StaticPermissao("TIN","Tipo Interessado");
        public static readonly StaticPermissao TipoOcupacao = new StaticPermissao("TOC", "Tipo Ocupação");
        public static readonly StaticPermissao Rodovia = new StaticPermissao("ROD","Rodovia");
        public static readonly StaticPermissao UA = new StaticPermissao("UA","UA");
        public static readonly StaticPermissao Unidade = new StaticPermissao("UNI","Unidade");
        public static readonly StaticPermissao Municipio = new StaticPermissao("MUN", "Municipio");
        public static readonly StaticPermissao Estado = new StaticPermissao("EST", "Estado");
        public static readonly StaticPermissao NaturezaJuridica = new StaticPermissao("NTJ", "Natureza Jurídica");
        public static readonly StaticPermissao DivisaoRegional = new StaticPermissao("DRG", "Divisão Regional");
        public static readonly StaticPermissao PI = new StaticPermissao("PI", "PI");
        public static readonly StaticPermissao IGPM = new StaticPermissao("IGP", "IGPM");
        public static readonly StaticPermissao UFESP = new StaticPermissao("UFE", "UFESP");
        public static readonly StaticPermissao ParametroMensal = new StaticPermissao("PMS", "Parâmetro Mensal");
        public static readonly StaticPermissao Concessionaria = new StaticPermissao("COS", "Concessionária");
        public static readonly StaticPermissao Dispositivo = new StaticPermissao("DIS", "Dispositivo");
        public static readonly StaticPermissao AreasGramadasLevantamento = new StaticPermissao("ARG", "AreasGramadasLevantamento");
        public static readonly StaticPermissao DrenagensLinearesLevantamento = new StaticPermissao("DLL", "DrenagensLinearesLevantamento");
        public static readonly StaticPermissao CercasLevantamento = new StaticPermissao("CCT", "CercasLevantamento");
        public static readonly StaticPermissao FaixasRolamentoLevantamento = new StaticPermissao("FLT", "FaixasRolamentoLevantamento");
        public static readonly StaticPermissao PassivosAmbientaisLinLevantamento = new StaticPermissao("PLL", "PassivosAmbientaisLinLevantamento");
        public static readonly StaticPermissao OaeLevantamento = new StaticPermissao("OEL", "OaeLevantamento");
        public static readonly StaticPermissao PavimentacoesLevantamento = new StaticPermissao("PVL", "PavimentacoesLevantamento");
        public static readonly StaticPermissao PavimentosRigidosLevantamento = new StaticPermissao("PVR", "PavimentosRigidosLevantamento");
        public static readonly StaticPermissao SegurancaBordoLevantamento = new StaticPermissao("SGB", "SegurancaBordoLevantamento");
        public static readonly StaticPermissao RocadasLevantamento = new StaticPermissao("RCL", "RocadasLevantamento");
        public static readonly StaticPermissao SegurancaCanteiroLevantamento = new StaticPermissao("SRG", "SegurancaCanteiroLevantamento");
        public static readonly StaticPermissao SegurancaGuardaCorpoLevantamento = new StaticPermissao("SGC", "SegurancaGuardaCorpoLevantamento");
        public static readonly StaticPermissao SinalFaixaBordoLevantamento = new StaticPermissao("SNF", "SinalFaixaBordoLevantamento");
        public static readonly StaticPermissao SinalFaixaCentralLevantamento = new StaticPermissao("SNC", "SinalFaixaCentralLevantamento");
        public static readonly StaticPermissao TerceiraFaixaLevantamento = new StaticPermissao("TCF", "TerceiraFaixaLevantamento");
        public static readonly StaticPermissao TachaFaixaBordoLevantamento = new StaticPermissao("TCB", "TachaFaixaBordoLevantamento");
        public static readonly StaticPermissao TachaFaixaCentralLevantamento = new StaticPermissao("TCC", "TachaFaixaCentralLevantamento");
        public static readonly StaticPermissao TiposPistaLevantamento = new StaticPermissao("TPP", "TiposPistaLevantamento");
        public static readonly StaticPermissao TuneisLevantamento = new StaticPermissao("TNL", "TuneisLevantamento");
        public static readonly StaticPermissao AcostamentosLevantamento = new StaticPermissao("ALV", "AcostamentosLevantamento");
    }
}