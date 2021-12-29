using DER.WebApp.ServiceAPI.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DER.WebApp.ViewModels.API
{
    public class APIViewModel
    {
        public int Id { get; set; }
        public string NomeDoServico { get; set; }
        public string URL { get; set; }
        public string Acao { get; set; }
        public string Parameters { get; set; }

        public List<APIViewModel> RetornaApisSirgeo()
        {
            const int rodId = 81;
            var retorno = new List<APIViewModel>();

            var tokenAPI = TokenApiHelper.CreateRequest(1, "Gerar Token");

            retorno.Add(tokenAPI);
            retorno.Add(RodoviaApiHelper.CreateRequest(2, "Rodovia - Todas"));
            retorno.Add(RodoviaApiHelper.CreateRequest(3, "Rodovia - Pelo Codigo Rodovia", "BR 354"));
            retorno.Add(DispositivoApiHelper.CreateRequest(4, "Dispositivo - Todos"));
            retorno.Add(DispositivoApiHelper.CreateRequest(5, "Dispositivo - Pelo Id", 685));
            retorno.Add(DispositivoApiHelper.CreateRequest(6, "Dispositivo - Pelo Codigo", null, "BR 354"));
            retorno.Add(DispositivoApiHelper.CreateRequest(7, "Dispositivo - Pela Rodovia", null, null, rodId, 1));
            retorno.Add(BueiroApiHelper.CreateRequest(8, "Bueiro - Todos"));
            retorno.Add(BueiroApiHelper.CreateRequest(9, "Bueiro - Pela Rodovia", rodId));
            retorno.Add(BueiroApiHelper.CreateRequest(10, "Bueiro - Pela Rodovia e KMInicial e Final", rodId, 0, 9999));
            retorno.Add(LVCApiHelper.CreateRequest(11, "LVC  - Todos"));
            retorno.Add(LVCApiHelper.CreateRequest(12, "LVC - Pela Rodovia", rodId));
            retorno.Add(LVCApiHelper.CreateRequest(13, "LVC - Pela Rodovia e KMInicial e Final", rodId, 0, 9999));
            retorno.Add(FWDApiHelper.CreateRequest(14, "FWD - Todos"));
            retorno.Add(FWDApiHelper.CreateRequest(15, "FWD - Pela Rodovia", rodId));
            retorno.Add(FWDApiHelper.CreateRequest(16, "FWD - Pela Rodovia e KMInicial e Final", rodId, 0, 9999));
            retorno.Add(HistoricoCaracterizacoesApiHelper.CreateRequest(17, "HistoricoCaracterizacoes - Todos", "historico_rodovia_full"));
            retorno.Add(HistoricoCaracterizacoesApiHelper.CreateRequest(18, "HistoricoCaracterizacoes - Pela RegId",  "historico_rodovia_full", 1));
            retorno.Add(HistoricoRestauracoesApiHelper.CreateRequest(19, "HistoricoRestauracoes - Todos",  "historico_rodovia_full"));
            retorno.Add(HistoricoRestauracoesApiHelper.CreateRequest(20, "HistoricoRestauracoes - Pela RegId",  "historico_rodovia_full", 12));
            retorno.Add(ElementosLinearesdeRodoviaApiHelper.CreateRequest(21, "ElementosLinearesdeRodovia - Acostamento", "AcostamentoLevantamento",  rodId));
            retorno.Add(ElementosLinearesdeRodoviaApiHelper.CreateRequest(22, "ElementosLinearesdeRodovia - Rolamento", "FaixasRolamentoLevantamento",  rodId));
            retorno.Add(ElementosLinearesdeRodoviaApiHelper.CreateRequest(23, "ElementosLinearesdeRodovia - Pavimentacoes", "PavimentacoesLevantamento",  rodId));
            retorno.Add(ElementosLinearesdeRodoviaApiHelper.CreateRequest(24, "ElementosLinearesdeRodovia - Terceira Faixa", "TerceiraFaixaLevantamento",  rodId));
            retorno.Add(ElementosLinearesdeRodoviaApiHelper.CreateRequest(25, "ElementosLinearesdeRodovia - Tipos Pista", "TiposPistaLevantamento",  rodId));
            retorno.Add(ElementosLinearesdeRodoviaApiHelper.CreateRequest(26, "ElementosLinearesdeRodovia - Tuneis", "TuneisLevantamento",  rodId));
            retorno.Add(ElementosLinearesdeSegurançaApiHelper.CreateRequest(27, "ElementosLinearesdeSegurança - Bordo", "SegurancaBordoLevantamento",  rodId));
            retorno.Add(ElementosLinearesdeSegurançaApiHelper.CreateRequest(28, "ElementosLinearesdeSegurança - Canteiro", "SegurancaCanteiroLevantamento",  rodId));
            retorno.Add(ElementosLinearesdeSegurançaApiHelper.CreateRequest(29, "ElementosLinearesdeSegurança - Guarda Corpo", "SegurancaGuardaCorpoLevantamento",  rodId));
            retorno.Add(ElementosLinearesSinalizaçãoHorizontalApiHelper.CreateRequest(30, "ElementosLinearesSinalizaçãoHorizontal - Bordo", "SinalFaixaBordoLevantamento",  rodId));
            retorno.Add(ElementosLinearesSinalizaçãoHorizontalApiHelper.CreateRequest(31, "ElementosLinearesSinalizaçãoHorizontal - Faixa Central", "SinalFaixaCentralLevantamento",  rodId));
            retorno.Add(ElementosLinearesSinalizaçãoHorizontalApiHelper.CreateRequest(32, "ElementosLinearesSinalizaçãoHorizontal - Tacha Faixa Bordo", "TachaFaixaBordoLevantamento",  rodId));
            retorno.Add(ElementosLinearesSinalizaçãoHorizontalApiHelper.CreateRequest(33, "ElementosLinearesSinalizaçãoHorizontal - Tacha Faixa Central", "TachaFaixaCentralLevantamento",  rodId));
            retorno.Add(ElementosLinearesAmbientaisApiHelper.CreateRequest(34, "ElementosLinearesAmbientais - Passivos Ambientais", "PassivosAmbientaisLinLevantamento", rodId));
            retorno.Add(ElementosLinearesAmbientaisApiHelper.CreateRequest(35, "ElementosLinearesAmbientais - Areas Gramadas", "AreasGramadasLevantamento", rodId));
            retorno.Add(ElementosLinearesAmbientaisApiHelper.CreateRequest(36, "ElementosLinearesAmbientais - Rocadas", "RocadasLevantamento", rodId));
            retorno.Add(FaixasdeDominioApiHelper.CreateRequest(37, "FaixasdeDominio - Cercas", "CercasLevantamento", rodId));
            retorno.Add(DrenagemLinearApiHelper.CreateRequest(38, "DrenagemLinear - Levantamento", "DrenagensLinearesLevantamento", rodId));
            retorno.Add(ObrasdeArteEspeciaisApiHelper.CreateRequest(38, "ObrasdeArteEspeciais - Oae", "OaeLevantamento", rodId));
            retorno.Add(PavimentosRigidosApiHelper.CreateRequest(39, "PavimentosRigidos - Levantamento", "PavimentosRigidosLevantamento", rodId));
            retorno.Add(ElementosPontuaisdeRodoviaApiHelper.CreateRequest(40, "ElementosPontuaisdeRodovia - Acessos", "AcessosLevantamento", rodId));
            retorno.Add(ElementosPontuaisdeRodoviaApiHelper.CreateRequest(41, "ElementosPontuaisdeRodovia - Dispositivos", "DispositivosLevantamento", rodId));
            retorno.Add(ElementosPontuaisdeRodoviaApiHelper.CreateRequest(42, "ElementosPontuaisdeRodovia - Drenagens Pontuais", "DrenagensPontuaisLevantamento", rodId));
            retorno.Add(ElementosPontuaisdeRodoviaApiHelper.CreateRequest(43, "ElementosPontuaisdeRodovia - Edificacoes", "EdificacoesLevantamento", rodId));
            retorno.Add(ElementosPontuaisdeRodoviaApiHelper.CreateRequest(44, "ElementosPontuaisdeRodovia - Eletricos Telefonia", "EletricosTelefoniaLevantamento", rodId));
            retorno.Add(ElementosPontuaisdeRodoviaApiHelper.CreateRequest(45, "ElementosPontuaisdeRodovia - Sensores Eletronicos", "SensoresEletronicosLevantamento", rodId));
            retorno.Add(ElementosPontuaisdeRodoviaApiHelper.CreateRequest(46, "ElementosPontuaisdeRodovia - Passivos Ambientais", "PassivosAmbientaisPonLevantamento", rodId));
            retorno.Add(ElementosPontuaisdeRodoviaApiHelper.CreateRequest(47, "ElementosPontuaisdeRodovia - Pontos de Onibus", "PontosOnibusLevantamento", rodId));
            retorno.Add(ElementosPontuaisdeRodoviaApiHelper.CreateRequest(48, "ElementosPontuaisdeRodovia - Instalacoes Operacionais", "InstalacoesOperacionaisLevantamento", rodId));
            retorno.Add(ElementosPontuaisdeRodoviaApiHelper.CreateRequest(49, "ElementosPontuaisdeRodovia - Propagandas", "PropagandasLevantamento", rodId));
            retorno.Add(ElementosPontuaisdeRodoviaApiHelper.CreateRequest(50, "ElementosPontuaisdeRodovia - Seguranca Terminais", "SegurancaTerminaisLevantamento", rodId));
            retorno.Add(ElementosPontuaisdeRodoviaApiHelper.CreateRequest(51, "ElementosPontuaisdeRodovia - Sinalizacoes Horizontais", "SinalizacoesHorizontaisPonLevantamento", rodId));
            retorno.Add(ElementosPontuaisdeRodoviaApiHelper.CreateRequest(52, "ElementosPontuaisdeRodovia - Sinalizacoes Verticais", "SinalizacoesVerticaisLevantamento", rodId));
            retorno.Add(ElementosPontuaisdeRodoviaApiHelper.CreateRequest(53, "ElementosPontuaisdeRodovia - Sub Estacoes Reservatorios", "SubestacoesReservatoriosLevantamento", rodId));
            retorno.Add(ElementosPontuaisdeRodoviaApiHelper.CreateRequest(54, "ElementosPontuaisdeRodovia - Passarelas", "PassarelasLevantamento", rodId));
            retorno.Add(ElementosPontuaisdeRodoviaApiHelper.CreateRequest(55, "ElementosPontuaisdeRodovia - Travessias", "TravessiasLevantamento", rodId));
            retorno.Add(ElementosSegmentosdeRodoviaApiHelper.CreateRequest(56, "LevantamentosSegmentos - AreasGramadasLevantamento", "AreasGramadasLevantamento"));
            retorno.Add(ElementosSegmentosdeRodoviaApiHelper.CreateRequest(57, "LevantamentosSegmentos - DrenagensLinearesLevantamento", "DrenagensLinearesLevantamento"));
            retorno.Add(ElementosSegmentosdeRodoviaApiHelper.CreateRequest(58, "LevantamentosSegmentos - CercasLevantamento", "CercasLevantamento"));
            retorno.Add(ElementosSegmentosdeRodoviaApiHelper.CreateRequest(59, "LevantamentosSegmentos - FaixasRolamentoLevantamento", "FaixasRolamentoLevantamento"));
            retorno.Add(ElementosSegmentosdeRodoviaApiHelper.CreateRequest(60, "LevantamentosSegmentos - PassivosAmbientaisLinLevantamento", "PassivosAmbientaisLinLevantamento"));
            retorno.Add(ElementosSegmentosdeRodoviaApiHelper.CreateRequest(61, "LevantamentosSegmentos - OaeLevantamento", "OaeLevantamento"));
            retorno.Add(ElementosSegmentosdeRodoviaApiHelper.CreateRequest(62, "LevantamentosSegmentos - PavimentacoesLevantamento", "PavimentacoesLevantamento"));
            retorno.Add(ElementosSegmentosdeRodoviaApiHelper.CreateRequest(63, "LevantamentosSegmentos - PavimentosRigidosLevantamento", "PavimentosRigidosLevantamento"));
            retorno.Add(ElementosSegmentosdeRodoviaApiHelper.CreateRequest(64, "LevantamentosSegmentos - SegurancaBordoLevantamento", "SegurancaBordoLevantamento"));
            retorno.Add(ElementosSegmentosdeRodoviaApiHelper.CreateRequest(65, "LevantamentosSegmentos - RocadasLevantamento", "RocadasLevantamento"));
            retorno.Add(ElementosSegmentosdeRodoviaApiHelper.CreateRequest(66, "LevantamentosSegmentos - SegurancaCanteiroLevantamento", "SegurancaCanteiroLevantamento"));
            retorno.Add(ElementosSegmentosdeRodoviaApiHelper.CreateRequest(67, "LevantamentosSegmentos - SegurancaGuardaCorpoLevantamento", "SegurancaGuardaCorpoLevantamento"));
            retorno.Add(ElementosSegmentosdeRodoviaApiHelper.CreateRequest(68, "LevantamentosSegmentos - SinalFaixaBordoLevantamento", "SinalFaixaBordoLevantamento"));
            retorno.Add(ElementosSegmentosdeRodoviaApiHelper.CreateRequest(69, "LevantamentosSegmentos - SinalFaixaCentralLevantamento", "SinalFaixaCentralLevantamento"));
            retorno.Add(ElementosSegmentosdeRodoviaApiHelper.CreateRequest(70, "LevantamentosSegmentos - TerceiraFaixaLevantamento", "TerceiraFaixaLevantamento"));
            retorno.Add(ElementosSegmentosdeRodoviaApiHelper.CreateRequest(71, "LevantamentosSegmentos - TachaFaixaBordoLevantamento", "TachaFaixaBordoLevantamento"));
            retorno.Add(ElementosSegmentosdeRodoviaApiHelper.CreateRequest(72, "LevantamentosSegmentos - TachaFaixaCentralLevantamento", "TachaFaixaCentralLevantamento"));
            retorno.Add(ElementosSegmentosdeRodoviaApiHelper.CreateRequest(73, "LevantamentosSegmentos - TiposPistaLevantamento", "TiposPistaLevantamento"));
            retorno.Add(ElementosSegmentosdeRodoviaApiHelper.CreateRequest(74, "LevantamentosSegmentos - TuneisLevantamento", "TuneisLevantamento"));
            retorno.Add(ElementosSegmentosdeRodoviaApiHelper.CreateRequest(75, "LevantamentosSegmentos - AcostamentosLevantamento", "AcostamentosLevantamento"));

            retorno.Add(DominioApiHelper.CreateRequest(76, "Dominio - flags", "Dominio", "flags"));
            retorno.Add(DominioApiHelper.CreateRequest(77, "Dominio - eixos_tipos", "Dominio", "eixos_tipos"));
            retorno.Add(DominioApiHelper.CreateRequest(78, "Dominio - hidraulica_posicoes", "Dominio", "hidraulica_posicoes"));
            retorno.Add(DominioApiHelper.CreateRequest(79, "Dominio - pista_tipos", "Dominio", "pista_tipos"));
            retorno.Add(DominioApiHelper.CreateRequest(80, "Dominio - regionais", "Dominio", "regionais"));
            retorno.Add(DominioApiHelper.CreateRequest(81, "Dominio - regionais_code", "Dominio", "regionais_code"));
            retorno.Add(DominioApiHelper.CreateRequest(82, "Dominio - residencias", "Dominio", "residencias"));
            retorno.Add(DominioApiHelper.CreateRequest(83, "Dominio - relevos", "Dominio", "relevos"));
            retorno.Add(DominioApiHelper.CreateRequest(84, "Dominio - revestimentos", "Dominio", "revestimentos"));
            retorno.Add(DominioApiHelper.CreateRequest(85, "Dominio - rodovias_sentidos", "Dominio", "rodovias_sentidos"));
            retorno.Add(DominioApiHelper.CreateRequest(86, "Dominio - rodovias_tipos", "Dominio", "rodovias_tipos"));
            retorno.Add(DominioApiHelper.CreateRequest(87, "Dominio - arquivo_tipos", "Dominio", "arquivo_tipos"));
            retorno.Add(DominioApiHelper.CreateRequest(88, "Dominio - bueiros_diagnosticos", "Dominio", "bueiros_diagnosticos"));
            retorno.Add(DominioApiHelper.CreateRequest(89, "Dominio - bueiros_materiais", "Dominio", "bueiros_materiais"));
            retorno.Add(DominioApiHelper.CreateRequest(90, "Dominio - bueiros_tipos", "Dominio", "bueiros_tipos"));
            retorno.Add(DominioApiHelper.CreateRequest(91, "Dominio - gradacoes", "Dominio", "gradacoes"));
            retorno.Add(DominioApiHelper.CreateRequest(92, "Dominio - pesos_ids", "Dominio", "pesos_ids"));
            retorno.Add(DominioApiHelper.CreateRequest(93, "Dominio - superficies_tipos", "Dominio", "superficies_tipos"));
            retorno.Add(DominioApiHelper.CreateRequest(94, "Dominio - drenagens_tipos", "Dominio", "drenagens_tipos"));
            retorno.Add(DominioApiHelper.CreateRequest(95, "Dominio - oae_tipos", "Dominio", "oae_tipos"));
            retorno.Add(DominioApiHelper.CreateRequest(96, "Dominio - passivos_ambientais_tipos", "Dominio", "passivos_ambientais_tipos"));
            retorno.Add(DominioApiHelper.CreateRequest(97, "Dominio - elementos_seguranca_tipos", "Dominio", "elementos_seguranca_tipos"));
            retorno.Add(DominioApiHelper.CreateRequest(98, "Dominio - sinalizacoes_horizontais_tipos", "Dominio", "sinalizacoes_horizontais_tipos"));
            retorno.Add(DominioApiHelper.CreateRequest(99, "Dominio - dispositivos_tipos", "Dominio", "dispositivos_tipos"));
            retorno.Add(DominioApiHelper.CreateRequest(100, "Dominio - edificacoes_tipos", "Dominio", "edificacoes_tipos"));
            retorno.Add(DominioApiHelper.CreateRequest(101, "Dominio - instalacoes_operacionais_tipos", "Dominio", "instalacoes_operacionais_tipos"));
            retorno.Add(DominioApiHelper.CreateRequest(102, "Dominio - subestacoes_reservatorios_tipos", "Dominio", "subestacoes_reservatorios_tipos"));
            retorno.Add(DominioApiHelper.CreateRequest(103, "Dominio - porticos_pmvs_tipos", "Dominio", "porticos_pmvs_tipos"));
            retorno.Add(DominioApiHelper.CreateRequest(104, "Dominio - eletricos_telefonia_tipos", "Dominio", "eletricos_telefonia_tipos"));
            retorno.Add(DominioApiHelper.CreateRequest(105, "Dominio - sensores_eletronicos_tipos", "Dominio", "sensores_eletronicos_tipos"));
            retorno.Add(DominioApiHelper.CreateRequest(106, "Dominio - sinalizacoes_verticais_tipos", "Dominio", "sinalizacoes_verticais_tipos"));
            retorno.Add(DominioApiHelper.CreateRequest(107, "Dominio - travessias_tipos", "Dominio", "travessias_tipos"));
            retorno.Add(DominioApiHelper.CreateRequest(108, "Dominio - materiais", "Dominio", "materiais"));
            retorno.Add(DominioApiHelper.CreateRequest(109, "Dominio - administradores", "Dominio", "administradores"));
            retorno.Add(DominioApiHelper.CreateRequest(110, "Dominio - jurisdicoes", "Dominio", "jurisdicoes"));
            retorno.Add(DominioApiHelper.CreateRequest(111, "Dominio - conservadores", "Dominio", "conservadores"));
            retorno.Add(DominioApiHelper.CreateRequest(112, "Dominio - circunscricao", "Dominio", "circunscricao"));

            retorno.Add(ElementosPontuaisdeRodoviaApiHelper.CreateRequest(113, "LevantamentosSegmentos - AcessosLevantamento", "AcessosLevantamento", null));
            retorno.Add(ElementosPontuaisdeRodoviaApiHelper.CreateRequest(114, "LevantamentosSegmentos - DispositivosLevantamento", "DispositivosLevantamento", null));
            retorno.Add(ElementosPontuaisdeRodoviaApiHelper.CreateRequest(115, "LevantamentosSegmentos - DrenagensPontuaisLevantamento", "DrenagensPontuaisLevantamento", null));
            retorno.Add(ElementosPontuaisdeRodoviaApiHelper.CreateRequest(116, "LevantamentosSegmentos - EdificacoesLevantamento", "EdificacoesLevantamento", null));

            return retorno;
        }

        public List<APIViewModel> RetornaApisBancoBrasil()
        {
            var retorno = new List<APIViewModel>();

            retorno.Add(BancoBrasilTokenApiHelper.CreateRequestHomolog(0, "Gerar Token Banco do Brasil Homologação"));
            retorno.Add(BancoBrasilTokenApiHelper.CreateRequestProd(1, "Gerar Token Banco do Brasil Produção", "a", "b"));

            return retorno;
        }

        public RetornoHealtCheckAPI HealtCheckAPI(int id)
        {
            var lista = this.RetornaApisSirgeo();

            var token = ExecServiceApiHelper.ExecRequestToken(lista.FirstOrDefault(x => x.Id == 1));

            if (id != 1)
            {
                return ExecServiceApiHelper.ExecRequest(lista.FirstOrDefault(x => x.Id == id), token);
            } else
            {
                return new RetornoHealtCheckAPI()
                {
                    Sucesso = true,
                    Mensagem = "Token: " + token
                };
            }
        }

        public RetornoHealtCheckAPI HealtCheckBancoBrasilBoletoAPI(string ClientID = "", string Secret = "")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ClientID) || string.IsNullOrWhiteSpace(Secret))
                    return new RetornoHealtCheckAPI() { Sucesso = true, Mensagem = ExecServiceApiHelper.ExecRequestToken(RetornaApisBancoBrasil().FirstOrDefault(x => x.Id == 0)) };
                else
                    return new RetornoHealtCheckAPI() { Sucesso = true, Mensagem = ExecServiceApiHelper.ExecRequestToken(RetornaApisBancoBrasil().FirstOrDefault(x => x.Id == 1)) };
            }
            catch
            {
                return new RetornoHealtCheckAPI(){ Sucesso = false, Mensagem = "Erro" };
            }
        }
    }

    public class RetornoHealtCheckAPI
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
    }
}