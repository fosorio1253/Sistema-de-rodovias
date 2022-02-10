using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.Domain.Models;
using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Text;

namespace DER.WebApp.Domain.Business
{
    public class DadosMestresBLL
    {
        private DadoMestreBLL dadoMestreBLL;
        private AreasBLL areaBLL;
        private ConcessionariaBLL concessionariaBLL;
        private DivisaoRegionalBLL divisaoRegionalBLL;
        private IgpBLL igpBLL;
        private MunicipiosBLL municipioBLL;
        private NaturezaJuridicasBLL naturezaJuridicaBLL;
        private AssuntosBLL assuntoBLL;
        private OrigemSolicitacaoBLL origemSolicitacaoBLL;
        private OcorrenciaSeveridadeBLL ocorrenciaSeveridadeBLL;
        private OcorrenciaStatusBLL ocorrenciaStatusBLL;
        private OcorrenciaTrechoBLL ocorrenciaTrechoBLL;
        private PiBLL piBLL;
        private ResidenciaConservacaoBLL residenciaConservacaoBLL;
        private RodoviasBLL rodoviaBLL;
        private SituacaoSolicitacaoBLL situacaoSolicitacaoBLL;
        private SituacaoOcupacaoBLL situacaoOcupacaoBLL;
        private TipoConcessaoBLL tipoConcessaoBLL;
        private TipoDocumentoBLL tipoDocumentoBLL;
        private TipoImplantacaoBLL tipoImplantacaoBLL;
        private TipoPassagemBLL tipoPassagemBLL;
        private TipoEmpresasBLL tipoEmpresaBLL;
        private TipoInteressadosBLL tipoInteressadoBLL;
        private TipoOcupacaoBLL tipoOcupacaoBLL;
        private TipoDocumentoInteressadoBLL tipoDocumentoInteressadoBLL;
        private TipoDocumentoOcupacaoBLL tipoDocumentoOcupacaoBLL;
        private UaBLL uaBLL;
        private UfespBLL ufespBLL;
        private UnidadesBLL unidadeBLL;

        public DadosMestresBLL()
        {
            dadoMestreBLL = new DadoMestreBLL();
            areaBLL = new AreasBLL();
            concessionariaBLL = new ConcessionariaBLL();
            divisaoRegionalBLL = new DivisaoRegionalBLL();
            igpBLL = new IgpBLL();
            municipioBLL = new MunicipiosBLL();
            naturezaJuridicaBLL = new NaturezaJuridicasBLL();
            assuntoBLL = new AssuntosBLL();
            origemSolicitacaoBLL = new OrigemSolicitacaoBLL();
            ocorrenciaSeveridadeBLL = new OcorrenciaSeveridadeBLL();
            ocorrenciaStatusBLL = new OcorrenciaStatusBLL();
            ocorrenciaTrechoBLL = new OcorrenciaTrechoBLL();
            piBLL = new PiBLL();
            residenciaConservacaoBLL = new ResidenciaConservacaoBLL();
            rodoviaBLL = new RodoviasBLL();
            situacaoSolicitacaoBLL = new SituacaoSolicitacaoBLL();
            situacaoOcupacaoBLL = new SituacaoOcupacaoBLL();
            tipoConcessaoBLL = new TipoConcessaoBLL();
            tipoDocumentoBLL = new TipoDocumentoBLL();
            tipoImplantacaoBLL = new TipoImplantacaoBLL();
            tipoPassagemBLL = new TipoPassagemBLL();
            tipoEmpresaBLL = new TipoEmpresasBLL();
            tipoInteressadoBLL = new TipoInteressadosBLL();
            tipoOcupacaoBLL = new TipoOcupacaoBLL();
            tipoDocumentoInteressadoBLL = new TipoDocumentoInteressadoBLL();
            tipoDocumentoOcupacaoBLL = new TipoDocumentoOcupacaoBLL();
            uaBLL = new UaBLL();
            ufespBLL = new UfespBLL();
            unidadeBLL = new UnidadesBLL();
        }

        public List<DadoMestreViewModel> ObtemDadoMestre()
        {
            return dadoMestreBLL.LoadView();
        }

        public DadoMestreTabelaViewModel ObtemDadoMestreTabela(string tabelaId)
        {
            var tabela = new DadoMestreTabelaViewModel();
            tabela.valores = new List<List<DadoMestreTabelaValoresViewModel>>();
            tabela.nome_tabela = dadoMestreBLL.LoadView().Where(x => x.sigla.Equals(tabelaId)).Select(x => x.nome).FirstOrDefault();
            tabela.sigla = tabelaId;

            if (tabelaId == "ARE")
                areaBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "COS")
                concessionariaBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "DRG")
                divisaoRegionalBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "IGP")
                igpBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "MUN")
                municipioBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "NAT")
                naturezaJuridicaBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "OAS")
                assuntoBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "ORS")
                origemSolicitacaoBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "OSE")
                ocorrenciaSeveridadeBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "OST")
                ocorrenciaStatusBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "OTR")
                ocorrenciaTrechoBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "PI")
                piBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "REC")
                residenciaConservacaoBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "ROD")
                rodoviaBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "SIS")
                situacaoSolicitacaoBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "SOC")
                situacaoOcupacaoBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "TDC")
                tipoConcessaoBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "TDD")
                tipoDocumentoBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "TDI")
                tipoImplantacaoBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "TDP")
                tipoPassagemBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "TEM")
                tipoEmpresaBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "TIN")
                tipoInteressadoBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "TOC")
                tipoOcupacaoBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "TPI")
                tipoDocumentoInteressadoBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "TPO")
                tipoDocumentoOcupacaoBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "UA")
                uaBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "UFE")
                ufespBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));
            else if (tabelaId == "UNI")
                unidadeBLL.LoadView().ForEach(x => tabela.valores.Add(CreateDadoMestre(x)));

            return tabela;
        }

        private List<DadoMestreTabelaValoresViewModel> CreateDadoMestre(object obj)
        {
            var lvalor = new List<DadoMestreTabelaValoresViewModel>();
            obj.GetType().GetProperties().ToList().ForEach(x => lvalor.Add(new DadoMestreTabelaValoresViewModel() { nome_coluna = x.Name, valor = x.GetValue(obj, null).ToString() }));
            return lvalor;
        }

        public bool Salvar(DadoMestreTabelaViewModel dadosMestres)
        {
            try
            {
                if (dadosMestres.sigla == "ARE")
                    dadosMestres.valores.ForEach(x => areaBLL.Save(x));
                else if (dadosMestres.sigla == "COS")
                    dadosMestres.valores.ForEach(x => concessionariaBLL.Save(x));
                else if (dadosMestres.sigla == "DRG")
                    dadosMestres.valores.ForEach(x => divisaoRegionalBLL.Save(x));
                else if (dadosMestres.sigla == "IGP")
                    dadosMestres.valores.ForEach(x => igpBLL.Save(x));
                else if (dadosMestres.sigla == "MUN")
                    dadosMestres.valores.ForEach(x => municipioBLL.Save(x));
                else if (dadosMestres.sigla == "NAT")
                    dadosMestres.valores.ForEach(x => naturezaJuridicaBLL.Save(x));
                else if (dadosMestres.sigla == "OAS")
                    dadosMestres.valores.ForEach(x => assuntoBLL.Save(x));
                else if (dadosMestres.sigla == "ORS")
                    dadosMestres.valores.ForEach(x => origemSolicitacaoBLL.Save(x));
                else if (dadosMestres.sigla == "OSE")
                    dadosMestres.valores.ForEach(x => ocorrenciaSeveridadeBLL.Save(x));
                else if (dadosMestres.sigla == "OST")
                    dadosMestres.valores.ForEach(x => ocorrenciaStatusBLL.Save(x));
                else if (dadosMestres.sigla == "OTR")
                    dadosMestres.valores.ForEach(x => ocorrenciaTrechoBLL.Save(x));
                else if (dadosMestres.sigla == "PI")
                    dadosMestres.valores.ForEach(x => piBLL.Save(x));
                else if (dadosMestres.sigla == "REC")
                    dadosMestres.valores.ForEach(x => residenciaConservacaoBLL.Save(x));
                else if (dadosMestres.sigla == "ROD")
                    dadosMestres.valores.ForEach(x => rodoviaBLL.Save(x));
                else if (dadosMestres.sigla == "SIS")
                    dadosMestres.valores.ForEach(x => situacaoSolicitacaoBLL.Save(x));
                else if (dadosMestres.sigla == "SOC")
                    dadosMestres.valores.ForEach(x => situacaoOcupacaoBLL.Save(x));
                else if (dadosMestres.sigla == "TDC")
                    dadosMestres.valores.ForEach(x => tipoConcessaoBLL.Save(x));
                else if (dadosMestres.sigla == "TDD")
                    dadosMestres.valores.ForEach(x => tipoDocumentoBLL.Save(x));
                else if (dadosMestres.sigla == "TDI")
                    dadosMestres.valores.ForEach(x => tipoImplantacaoBLL.Save(x));
                else if (dadosMestres.sigla == "TDP")
                    dadosMestres.valores.ForEach(x => tipoPassagemBLL.Save(x));
                else if (dadosMestres.sigla == "TEM")
                    dadosMestres.valores.ForEach(x => tipoEmpresaBLL.Save(x));
                else if (dadosMestres.sigla == "TIN")
                    dadosMestres.valores.ForEach(x => tipoInteressadoBLL.Save(x));
                else if (dadosMestres.sigla == "TOC")
                    dadosMestres.valores.ForEach(x => tipoOcupacaoBLL.Save(x));
                else if (dadosMestres.sigla == "TPI")
                    dadosMestres.valores.ForEach(x => tipoDocumentoInteressadoBLL.Save(x));
                else if (dadosMestres.sigla == "TPO")
                    dadosMestres.valores.ForEach(x => tipoDocumentoOcupacaoBLL.Save(x));
                else if (dadosMestres.sigla == "UA")
                    dadosMestres.valores.ForEach(x => uaBLL.Save(x));
                else if (dadosMestres.sigla == "UFE")
                    dadosMestres.valores.ForEach(x => ufespBLL.Save(x));
                else if (dadosMestres.sigla == "UNI")
                    dadosMestres.valores.ForEach(x => unidadeBLL.Save(x));

                return true;
            }
            catch
            {
                return false;
            }
        }

        /*

        public List<DadosMestresTabela> obtemTodasTabelas()
        {
            var ldm = new List<DadosMestresTabela>();
            for (int i = 0; i < 28; i++)
            {
                var dm = new DadosMestresTabela();
                if (i == 0) { dm.Nome = "Área"; dm.Codigo = "ARE"; }
                else if (i == 1) { dm.Nome = "Concessionária"; dm.Codigo = "COS"; }
                else if (i == 2) { dm.Nome = "Divisão Regional"; dm.Codigo = "DRG"; }
                else if (i == 3) { dm.Nome = "IGPM"; dm.Codigo = "IGP"; }
                else if (i == 4) { dm.Nome = "Municipio"; dm.Codigo = "MUN"; }
                else if (i == 5) { dm.Nome = "Natureza Jurídica"; dm.Codigo = "NAT"; }
                else if (i == 6) { dm.Nome = "Ocorrência Assunto"; dm.Codigo = "OAS"; }
                else if (i == 7) { dm.Nome = "Origem da Solicitação"; dm.Codigo = "ORS"; }
                else if (i == 8) { dm.Nome = "Ocorrência Severidade"; dm.Codigo = "OSE"; }
                else if (i == 9) { dm.Nome = "Ocorrência Status"; dm.Codigo = "OST"; }
                else if (i == 10) { dm.Nome = "Ocorrência Trecho"; dm.Codigo = "OTR"; }
                else if (i == 11) { dm.Nome = "PI"; dm.Codigo = "PI"; }
                else if (i == 12) { dm.Nome = "Residência de Conservação"; dm.Codigo = "REC"; }
                else if (i == 13) { dm.Nome = "Rodovia"; dm.Codigo = "ROD"; }
                else if (i == 14) { dm.Nome = "Situação da Solicitação"; dm.Codigo = "SIS"; }
                else if (i == 15) { dm.Nome = "Situação da Ocupação"; dm.Codigo = "SOC"; }
                else if (i == 16) { dm.Nome = "Tipo de Concessão"; dm.Codigo = "TDC"; }
                else if (i == 17) { dm.Nome = "Tipo de Documento"; dm.Codigo = "TDD"; }
                else if (i == 18) { dm.Nome = "Tipo de Implantação"; dm.Codigo = "TDI"; }
                else if (i == 19) { dm.Nome = "Tipo de Passagem"; dm.Codigo = "TDP"; }
                else if (i == 20) { dm.Nome = "Tipo de Empresa"; dm.Codigo = "TEM"; }
                else if (i == 21) { dm.Nome = "Tipo Interessado"; dm.Codigo = "TIN"; }
                else if (i == 22) { dm.Nome = "Tipo Ocupação"; dm.Codigo = "TOC"; }
                else if (i == 23) { dm.Nome = "Tipo de Documento Interessado"; dm.Codigo = "TPI"; }
                else if (i == 24) { dm.Nome = "Tipo de Documento Ocupação"; dm.Codigo = "TPO"; }
                else if (i == 25) { dm.Nome = "UA"; dm.Codigo = "UA"; }
                else if (i == 26) { dm.Nome = "UFESP"; dm.Codigo = "UFE"; }
                else if (i == 27) { dm.Nome = "Unidade"; dm.Codigo = "UNI"; }
                ldm.Add(dm);
            }
            return ldm;
        }

        public DadosMestresViewModels obtemTabela(string tabelaId)
        {
            var DadosMestres = new DadosMestresViewModels();
            DadosMestres.Tabela = new Dictionary<int, List<DMValores>>();
            DadosMestres.Colunas = new List<DMColunas>();
            DadosMestres.CodigoTabela = tabelaId;
            int linha = 0;

            if (tabelaId == "ARE")      
            { 
                DadosMestres.NomeTabela = "Área";
                var t = areaBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas(){ idColuna = 0,NomeColuna = x.Name,TipoDadoColuna = 0 }));
                t.ForEach(x => 
                { 
                    DadosMestres.Tabela.Add(linha, new List<DMValores>() 
                    { 
                        new DMValores() { id = x.AreaId, valor = x.Nome, linha = linha, colunaId = 0 }
                    });
                    linha++; 
                });
            }
            else if (tabelaId == "COS") 
            { 
                DadosMestres.NomeTabela = "Concessionária";
                var t = concessionariaBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.concessionaria_id, valor = x.nome, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "DRG") 
            { 
                DadosMestres.NomeTabela = "Divisão Regional";
                var t = divisaoRegionalBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.divisao_regional_id, valor = x.descricao, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "IGP") 
            { 
                DadosMestres.NomeTabela = "IGPM";
                var t = igpBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.IGP_id, valor = x.valor.ToString(), linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "MUN") 
            { 
                DadosMestres.NomeTabela = "Municipio";
                var t = municipioBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.municipio_id, valor = x.municipio, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "NAT") 
            { 
                DadosMestres.NomeTabela = "Natureza Jurídica";
                var t = naturezaJuridicaBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.NaturezaJuridicaId, valor = x.Nome, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "OAS") 
            { 
                DadosMestres.NomeTabela = "Ocorrência Assunto";
                var t = assuntoBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.assunto_id, valor = x.nome, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "ORS") 
            { 
                DadosMestres.NomeTabela = "Origem da Solicitação";
                var t = origemSolicitacaoBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.origem_da_solicitacao_id, valor = x.nome, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "OSE") 
            { 
                DadosMestres.NomeTabela = "Ocorrência Severidade";
                var t = ocorrenciaSeveridadeBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.ocorrencia_severidade_id, valor = x.nome, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "OST") 
            { 
                DadosMestres.NomeTabela = "Ocorrência Status";
                var t = ocorrenciaStatusBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.ocorrencia_status_id, valor = x.nome, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "OTR") 
            { 
                DadosMestres.NomeTabela = "Ocorrência Trecho";
                var t = ocorrenciaTrechoBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.ocorrencia_trecho_id, valor = x.nome, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "PI")  
            { 
                DadosMestres.NomeTabela = "PI";
                var t = piBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.pi_id, valor = x.Valor_PI.ToString(), linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "REC") 
            { 
                DadosMestres.NomeTabela = "Residência de Conservação";
                var t = residenciaConservacaoBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.residencia_conservacao_id, valor = x.Nome, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "ROD") 
            { 
                DadosMestres.NomeTabela = "Rodovia";
                var t = rodoviaBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.rodovia_id, valor = x.Nome, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "SIS") 
            { 
                DadosMestres.NomeTabela = "Situação da Solicitação";
                var t = situacaoSolicitacaoBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.SituacaoSolicitacaoId, valor = x.Nome, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "SOC") 
            { 
                DadosMestres.NomeTabela = "Situação da Ocupação";
                var t = situacaoOcupacaoBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.SituacaoOcupacaoId, valor = x.Nome, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "TDC") 
            { 
                DadosMestres.NomeTabela = "Tipo de Concessão";
                var t = tipoConcessaoBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.tipo_concessao_id, valor = x.Descricao, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "TDD") 
            { 
                DadosMestres.NomeTabela = "Tipo de Documento";
                var t = tipoDocumentoBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.tipo_documento_id, valor = x.descricao, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "TDI") 
            { 
                DadosMestres.NomeTabela = "Tipo de Implantação";
                var t = tipoImplantacaoBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = (int)x.TipoImplantacaoId, valor = x.Nome, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "TDP") 
            { 
                DadosMestres.NomeTabela = "Tipo de Passagem";
                var t = tipoPassagemBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = (int)x.TipoPassagemId, valor = x.Nome, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "TEM") 
            { 
                DadosMestres.NomeTabela = "Tipo de Empresa";
                var t = tipoEmpresaBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.TipoEmpresaId, valor = x.Nome, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "TIN") 
            { 
                DadosMestres.NomeTabela = "Tipo Interessado";
                var t = tipoInteressadoBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.tipo_interessado_id, valor = x.descricao, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "TOC") 
            { 
                DadosMestres.NomeTabela = "Tipo Ocupação";
                var t = tipoOcupacaoBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.tipo_ocupacao_id, valor = x.nome, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "TPI") 
            { 
                DadosMestres.NomeTabela = "Tipo de Documento Interessado";
                var t = tipoDocumentoInteressadoBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.tipo_documento_interessado_id, valor = x.descricao, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "TPO") 
            { 
                DadosMestres.NomeTabela = "Tipo de Documento Ocupação";
                var t = tipoDocumentoOcupacaoBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.TipoDeDocumentoOcupacaoId, valor = x.Nome, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "UA")  
            { 
                DadosMestres.NomeTabela = "UA";
                var t = uaBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.ua_id, valor = x.nome_ua, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "UFE") 
            { 
                DadosMestres.NomeTabela = "UFESP";
                var t = ufespBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.ufesp_id, valor = x.valor.ToString(), linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            else if (tabelaId == "UNI") 
            { 
                DadosMestres.NomeTabela = "Unidade";
                var t = unidadeBLL.LoadView();
                t.GetType().GetProperties().ToList().ForEach(x => DadosMestres.Colunas.Add(new DMColunas() { idColuna = 0, NomeColuna = x.Name, TipoDadoColuna = 0 }));
                t.ForEach(x =>
                {
                    DadosMestres.Tabela.Add(linha, new List<DMValores>()
                    {
                        new DMValores() { id = x.unidade_id, valor = x.nome, linha = linha, colunaId = 0 }
                    });
                    linha++;
                });
            }
            
            return DadosMestres;
        }

        public bool Salvar(DadosMestresRetornoViewModel dadosMestres)
        {
            try
            {
                if (dadosMestres.TabelaId == "ARE")
                    dadosMestres.Valores.ForEach(x => areaBLL.Save(new AreaViewModel() { AreaId = x.id, Nome = x.valor}));
                else if (dadosMestres.TabelaId == "COS")
                    dadosMestres.Valores.ForEach(x => concessionariaBLL.Save(new ConcessionariaViewModel() { concessionaria_id = x.id, nome = x.valor }));
                else if (dadosMestres.TabelaId == "DRG")
                    dadosMestres.Valores.ForEach(x => divisaoRegionalBLL.Save(new DivisaoRegionalViewModel() { divisao_regional_id = x.id, descricao = x.valor }));
                else if (dadosMestres.TabelaId == "IGP")
                    dadosMestres.Valores.ForEach(x => igpBLL.Save(new IgpViewModel() { IGP_id = x.id, valor = Convert.ToDouble(x.valor) }));
                else if (dadosMestres.TabelaId == "MUN")
                    dadosMestres.Valores.ForEach(x => municipioBLL.Save(new MunicipioViewModel() { municipio_id = x.id, municipio = x.valor }));
                else if (dadosMestres.TabelaId == "NAT")
                    dadosMestres.Valores.ForEach(x => naturezaJuridicaBLL.Save(new NaturezaJuridicaViewModel() { NaturezaJuridicaId = x.id, Nome = x.valor }));
                else if (dadosMestres.TabelaId == "OAS")
                    dadosMestres.Valores.ForEach(x => assuntoBLL.Save(new AssuntoViewModel() { assunto_id = x.id, nome = x.valor }));
                else if (dadosMestres.TabelaId == "ORS")
                    dadosMestres.Valores.ForEach(x => origemSolicitacaoBLL.Save(new OrigemSolicitacaoViewModel() { origem_da_solicitacao_id = x.id, nome = x.valor }));
                else if (dadosMestres.TabelaId == "OSE")
                    dadosMestres.Valores.ForEach(x => ocorrenciaSeveridadeBLL.Save(new OcorrenciaSeveridadeViewModel() { ocorrencia_severidade_id = x.id, nome = x.valor }));
                else if (dadosMestres.TabelaId == "OST")
                    dadosMestres.Valores.ForEach(x => ocorrenciaStatusBLL.Save(new OcorrenciaStatusViewModel() { ocorrencia_status_id = x.id, nome = x.valor }));
                else if (dadosMestres.TabelaId == "OTR")
                    dadosMestres.Valores.ForEach(x => ocorrenciaTrechoBLL.Save(new OcorrenciaTrechoViewModel() { ocorrencia_trecho_id = x.id, nome = x.valor }));
                else if (dadosMestres.TabelaId == "PI")
                    dadosMestres.Valores.ForEach(x => piBLL.Save(new PiViewModel() { pi_id = x.id, Valor_PI = Convert.ToDouble(x.valor) }));
                else if (dadosMestres.TabelaId == "REC")
                    dadosMestres.Valores.ForEach(x => residenciaConservacaoBLL.Save(new ResidenciaConservacaoViewModel() { residencia_conservacao_id = x.id, Nome = x.valor }));
                else if (dadosMestres.TabelaId == "ROD")
                    dadosMestres.Valores.ForEach(x => rodoviaBLL.Save(new RodoviaViewModel() { rodovia_id = x.id, Nome = x.valor }));
                else if (dadosMestres.TabelaId == "SIS")
                    dadosMestres.Valores.ForEach(x => situacaoSolicitacaoBLL.Save(new GestaoOcupacoesSituacaoSolicitacaoViewModel() { SituacaoSolicitacaoId = x.id, Nome = x.valor }));
                else if (dadosMestres.TabelaId == "SOC")
                    dadosMestres.Valores.ForEach(x => situacaoOcupacaoBLL.Save(new GestaoOcupacoesSituacaoOcupacaoViewModel() { SituacaoOcupacaoId = x.id, Nome = x.valor }));
                else if (dadosMestres.TabelaId == "TDC")
                    dadosMestres.Valores.ForEach(x => tipoConcessaoBLL.Save(new TipoConcessaoViewModel() { tipo_concessao_id = x.id, Descricao = x.valor }));
                else if (dadosMestres.TabelaId == "TDD")
                    dadosMestres.Valores.ForEach(x => tipoDocumentoBLL.Save(new TipoDocumentoViewModel() { tipo_documento_id = x.id, descricao = x.valor }));
                else if (dadosMestres.TabelaId == "TDI")
                    dadosMestres.Valores.ForEach(x => tipoImplantacaoBLL.Save(new TipoImplantacaoViewModel() { TipoImplantacaoId = x.id, Nome = x.valor }));
                else if (dadosMestres.TabelaId == "TDP")
                    dadosMestres.Valores.ForEach(x => tipoPassagemBLL.Save(new TipoPassagemViewModel() { TipoPassagemId = x.id, Nome = x.valor }));
                else if (dadosMestres.TabelaId == "TEM")
                    dadosMestres.Valores.ForEach(x => tipoEmpresaBLL.Save(new ViewModels.GestaoInteressados.TipoEmpresaViewModel() { TipoEmpresaId = x.id, Nome = x.valor }));
                else if (dadosMestres.TabelaId == "TIN")
                    dadosMestres.Valores.ForEach(x => tipoInteressadoBLL.Save(new TipoInteressadoViewModel() { tipo_interessado_id = x.id, descricao = x.valor }));
                else if (dadosMestres.TabelaId == "TOC")
                    dadosMestres.Valores.ForEach(x => tipoOcupacaoBLL.Save(new TipoOcupacaoViewModel() { tipo_ocupacao_id = x.id, nome = x.valor }));
                else if (dadosMestres.TabelaId == "TPI")
                    dadosMestres.Valores.ForEach(x => tipoDocumentoInteressadoBLL.Save(new TipoDocumentoInteressadoViewModel() { tipo_documento_interessado_id = x.id, descricao = x.valor }));
                else if (dadosMestres.TabelaId == "TPO")
                    dadosMestres.Valores.ForEach(x => tipoDocumentoOcupacaoBLL.Save(new TipoDeDocumentoOcupacaoViewModel() { TipoDeDocumentoOcupacaoId = x.id, Nome = x.valor }));
                else if (dadosMestres.TabelaId == "UA")
                    dadosMestres.Valores.ForEach(x => uaBLL.Save(new UaViewModel() { ua_id = x.id, nome_ua = x.valor }));
                else if (dadosMestres.TabelaId == "UFE")
                    dadosMestres.Valores.ForEach(x => ufespBLL.Save(new UfespViewModel() { ufesp_id = x.id, valor = Convert.ToDouble(x.valor) }));
                else if (dadosMestres.TabelaId == "UNI")
                    dadosMestres.Valores.ForEach(x => unidadeBLL.Save(new UnidadeViewModel() { unidade_id = x.id, nome = x.valor }));

                return true;
            }
            catch
            {
                return false;
            }
        }

        */

        public bool Excluir(string tabelaId, int id)
        {
            try
            {
                if (tabelaId == "ARE")
                    areaBLL.Remove(new AreaViewModel() { AreaId = id });
                else if (tabelaId == "COS")
                    concessionariaBLL.Remove(new ConcessionariaViewModel() { concessionaria_id = id });
                else if (tabelaId == "DRG")
                    divisaoRegionalBLL.Remove(new DivisaoRegionalViewModel() { divisao_regional_id = id });
                else if (tabelaId == "IGP")
                    igpBLL.Remove(new IgpViewModel() { IGP_id = id });
                else if (tabelaId == "MUN")
                    municipioBLL.Remove(new MunicipioViewModel() { municipio_id = id });
                else if (tabelaId == "NAT")
                    naturezaJuridicaBLL.Remove(new NaturezaJuridicaViewModel() { NaturezaJuridicaId = id });
                else if (tabelaId == "OAS")
                    assuntoBLL.Remove(new AssuntoViewModel() { assunto_id = id });
                else if (tabelaId == "ORS")
                    origemSolicitacaoBLL.Remove(new OrigemSolicitacaoViewModel() { origem_da_solicitacao_id = id });
                else if (tabelaId == "OSE")
                    ocorrenciaSeveridadeBLL.Remove(new OcorrenciaSeveridadeViewModel() { ocorrencia_severidade_id = id });
                else if (tabelaId == "OST")
                    ocorrenciaStatusBLL.Remove(new OcorrenciaStatusViewModel() { ocorrencia_status_id = id });
                else if (tabelaId == "OTR")
                    ocorrenciaTrechoBLL.Remove(new OcorrenciaTrechoViewModel() { ocorrencia_trecho_id = id });
                else if (tabelaId == "PI")
                    piBLL.Remove(new PiViewModel() { pi_id = id });
                else if (tabelaId == "REC")
                    residenciaConservacaoBLL.Remove(new ResidenciaConservacaoViewModel() { residencia_conservacao_id = id });
                else if (tabelaId == "ROD")
                    rodoviaBLL.Remove(new RodoviaViewModel() { rodovia_id = id });
                else if (tabelaId == "SIS")
                    situacaoSolicitacaoBLL.Remove(new GestaoOcupacoesSituacaoSolicitacaoViewModel() { SituacaoSolicitacaoId = id });
                else if (tabelaId == "SOC")
                    situacaoOcupacaoBLL.Remove(new GestaoOcupacoesSituacaoOcupacaoViewModel() { SituacaoOcupacaoId = id });
                else if (tabelaId == "TDC")
                    tipoConcessaoBLL.Remove(new TipoConcessaoViewModel() { tipo_concessao_id = id });
                else if (tabelaId == "TDD")
                    tipoDocumentoBLL.Remove(new TipoDocumentoViewModel() { tipo_documento_id = id });
                else if (tabelaId == "TDI")
                    tipoImplantacaoBLL.Remove(new TipoImplantacaoViewModel() { TipoImplantacaoId = id });
                else if (tabelaId == "TDP")
                    tipoPassagemBLL.Remove(new TipoPassagemViewModel() { TipoPassagemId = id });
                else if (tabelaId == "TEM")
                    tipoEmpresaBLL.Remove(new ViewModels.GestaoInteressados.TipoEmpresaViewModel() { TipoEmpresaId = id });
                else if (tabelaId == "TIN")
                    tipoInteressadoBLL.Remove(new TipoInteressadoViewModel() { tipo_interessado_id = id });
                else if (tabelaId == "TOC")
                    tipoOcupacaoBLL.Remove(new TipoOcupacaoViewModel() { tipo_ocupacao_id = id });
                else if (tabelaId == "TPI")
                    tipoDocumentoInteressadoBLL.Remove(new TipoDocumentoInteressadoViewModel() { tipo_documento_interessado_id = id });
                else if (tabelaId == "TPO")
                    tipoDocumentoOcupacaoBLL.Remove(new TipoDeDocumentoOcupacaoViewModel() { TipoDeDocumentoOcupacaoId = id });
                else if (tabelaId == "UA")
                    uaBLL.Remove(new UaViewModel() { ua_id = id });
                else if (tabelaId == "UFE")
                    ufespBLL.Remove(new UfespViewModel() { ufesp_id = id });
                else if (tabelaId == "UNI")
                    unidadeBLL.Remove(new UnidadeViewModel() { unidade_id = id });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    public class NullToEmptyStringResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return type.GetProperties()
                    .Select(p => 
                    {
                        var jp = base.CreateProperty(p, memberSerialization);
                        jp.ValueProvider = new NullToEmptyStringValueProvider(p);
                        return jp;
                    }).ToList();
        }
    }
    public class NullToEmptyStringValueProvider : IValueProvider
    {
        PropertyInfo _MemberInfo;
        public NullToEmptyStringValueProvider(PropertyInfo memberInfo)
        {
            _MemberInfo = memberInfo;
        }

        public object GetValue(object target)
        {
            object result = _MemberInfo.GetValue(target);
            if (_MemberInfo.PropertyType == typeof(string) && result == null) result = "";
            return result;

        }

        public void SetValue(object target, object value)
        {
            _MemberInfo.SetValue(target, value);
        }
    }
}