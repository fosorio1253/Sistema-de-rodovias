using DER.WebApp.Domain.Business;
using DER.WebApp.ViewModels.Financeiro.FaturamentoPorOcupacao;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace DER.WebApp.Helper
{
    public class PDF
    {
        private TipoOcupacoesBLL tipoOcupacoesBLL;
        private RegionalBLL regionalBLL;
        private ResidenciaConservacoesBLL residenciaConservacoesBLL;
        private FaturamentoBLL faturamentoBLL;
        private FaturamentoOcupacaoBLL faturamentoOcupacaoBLL;
        private RodoviaBLL rodoviaBLL;
        private GestaoInteressadoBLL gestaoInteressadoBLL;

        public PDF()
        {
            tipoOcupacoesBLL = new TipoOcupacoesBLL();
            regionalBLL = new RegionalBLL();
            residenciaConservacoesBLL = new ResidenciaConservacoesBLL();
            faturamentoBLL = new FaturamentoBLL();
            faturamentoOcupacaoBLL = new FaturamentoOcupacaoBLL();
            rodoviaBLL = new RodoviaBLL();
            gestaoInteressadoBLL = new GestaoInteressadoBLL();
        }
        public string retornaData(DateTime? data, bool ddYYYY = false)
        {
            if (data == null)
                return "sempre";
            if (ddYYYY)
                return data.Value.ToString("MM/yyyy");
            return data.Value.ToString("dd/MM/yyyy");


        }
        public string retornaValorFormato(string valor, FormatoNumero formato)
        {
            string retorno = valor;
            if (!string.IsNullOrEmpty(valor))
                switch (formato)
                {
                    case FormatoNumero.moedaSemCifrao:
                        if (double.TryParse(valor, out double valorDouble))
                        {
                            retorno = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:N}", valorDouble);
                        }
                        break;
                    case FormatoNumero.moeda:
                        if (double.TryParse(valor, out double valorDoubleMoeda))
                        {
                            retorno = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valorDoubleMoeda);
                        }
                        break;
                    case FormatoNumero.semFormatacao:
                        break;
                    default:
                        break;
                }
            return retorno;
        }
        public double retornaSomaColunaComAproximacoes(DataTable dt, string coluna, FormatoNumero formato)
        {
            double retorno = 0;
            foreach (DataRow item in dt.Rows)
            {
                var itemValor = item[coluna].ToString();
                if (double.TryParse(itemValor, out double valorDouble))
                {
                    switch (formato)
                    {
                        case FormatoNumero.moedaSemCifrao:
                        case FormatoNumero.moeda:
                            string aux = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:N}", valorDouble);
                            retorno += double.Parse(aux);
                            break;
                        case FormatoNumero.semFormatacao:
                            retorno += valorDouble;
                            break;
                        default:
                            break;
                    }
                }
            }
            return retorno;
        }
        public byte[] MontarPdf(object viewModel
                , relatorio tipoRelatorio
                , HttpContextBase contexto
                )
        {
            string logopath = contexto.Server.MapPath("~/img/logo.png");
            string titulo = "Titulo";
            string textoRef = "ref";
            tamanhoPagina tamanho = tamanhoPagina.a4;
            //List<header> headers = new List<header>();
            List<Cabecalho> listaCabecalho = new List<Cabecalho>();
            List<List<Cabecalho>> listaDeListaCabecalho = new List<List<Cabecalho>>();
            bool bordaDireita = false;
            DataTable dataTable = new DataTable();
            List<Filtros> filtros = new List<Filtros>();

            switch (tipoRelatorio)
            {
                case relatorio.BOLETOS_BANCARIOS_EMITIDOS:
                    throw new NotImplementedException("Não implementado");
                    break;
                case relatorio.CREDITOS_DO_ARQUIVO_DE_RETORNO:
                    throw new NotImplementedException("Não implementado");
                    break;
                case relatorio.PREVISAO_DE_RECEITA:
                    throw new NotImplementedException("Não implementado");
                    break;
                case relatorio.RELACAO_DE_ANUIDADES_RECEBIDAS:
                    throw new NotImplementedException("Não implementado");
                    break;
                case relatorio.RELACAO_DE_COBRANCAS_CREDITADAS_vs_DEBITADAS:
                    throw new NotImplementedException("Não implementado");
                    break;
                case relatorio.RELACAO_DE_CONCESSIONARIO:
                    throw new NotImplementedException("Não implementado");
                    break;
                case relatorio.RELACAO_DE_VALORES_A_RECEBER_COM_DETALHES_SOBRE_A_OCUPACAO:
                    throw new NotImplementedException("Não implementado");
                    break;
                case relatorio.RELACAO_DE_VALORES_A_RECEBER:
                    throw new NotImplementedException("Não implementado");
                    break;
                case relatorio.RELACAO_DE_VALORES_RECEBIDOS_COM_DETALHES_SOBRE_A_OCUPACAO:
                    throw new NotImplementedException("Não implementado");
                    break;
                case relatorio.RELACAO_SINTETICA_DE_PREVISAO_DE_RECEITA:
                    #region[RELACAO_SINTETICA_DE_PREVISAO_DE_RERECEITA]
                    var localviewModel = (FaturamentoPorOcupacaoViewModelParam)viewModel;
                    var faturamento = faturamentoOcupacaoBLL.ObterFaturamento(localviewModel);
                    faturamento.ForEach(item =>
                    {
                        var per = item.Periodo.Split('/');
                        if (per.Length > 0)
                        {
                            var periodo = per[0].PadLeft(2, '0') + "/" + per[1].PadLeft(2, '0') + "/" + per[2].PadLeft(4, '0');
                            item.Periodo = periodo;
                        }
                    });

                    List<FaturamentoSintetico> listFaturamentoSintetico = new List<FaturamentoSintetico>();
                    listFaturamentoSintetico.AddRange(faturamento.GroupBy(x => x.Periodo.Remove(0, 3))
                                                        .Select(p => new FaturamentoSintetico { Periodo = p.Key, ValorTotal = p.Sum(item => item.ValorTotal), ValorPrevisto = p.Sum(item => item.ValorPrevisto) })); ;

                    listFaturamentoSintetico = listFaturamentoSintetico.OrderBy(x => x.Periodo).ToList();

                    dataTable = listFaturamentoSintetico.ToDataTable();

                    tamanho = tamanhoPagina.a4;

                    titulo = "Relação Sintética de previsão de receita";

                    textoRef = "";

                    listaCabecalho = new List<Cabecalho>();
                    listaCabecalho.Add(new Cabecalho { TextoCabecalho = "Período", NomeDaPropriedade = "Periodo", formatoNumero = FormatoNumero.semFormatacao, largura = 100, posicao = PosicaoHorizontal.centro, bordaDireita = false, formatoTexto = FormatoTexto.negrito, totalizador = Totalizador.palavraTotal });
                    listaCabecalho.Add(new Cabecalho { TextoCabecalho = "Valor Previsto", NomeDaPropriedade = "ValorPrevisto", formatoNumero = FormatoNumero.moedaSemCifrao, largura = 100, posicao = PosicaoHorizontal.centro, bordaDireita = false, formatoTexto = FormatoTexto.normal, totalizador = Totalizador.soma });
                    listaDeListaCabecalho = new List<List<Cabecalho>>();
                    listaDeListaCabecalho.Add(listaCabecalho);
                    bordaDireita = false;


                    Filtros f1 = new Filtros();
                    f1.Chave = "Interessados";
                    f1.Valor = localviewModel.Interessados == null ? "Todos:" : localviewModel.Interessados.ToString();
                    filtros.Add(f1);
                    Filtros f2 = new Filtros();
                    f2.Chave = "Divisão Regional";
                    f2.Valor = localviewModel.Regionais == null ? "Todos:" : localviewModel.Regionais.ToString();
                    filtros.Add(f2);
                    Filtros f3 = new Filtros();
                    f3.Chave = "Período";
                    f3.Valor = retornaData(localviewModel.DataInicial, true) + " até " + retornaData(localviewModel.DataFinal, true);
                    filtros.Add(f3);

                    #endregion
                    break;
                case relatorio.RELACAO_SINTETICA_DE_VALORES_A_RECEBER:
                    throw new NotImplementedException("Não implementado");
                    break;
                case relatorio.RELACAO_SINTETICA_DE_VALORES_RECEBIDOS:
                    throw new NotImplementedException("Não implementado");
                    break;
                default:
                    throw new ArgumentException("Tipo de relatório não reconhecido");
                    break;
            }


            #region [ cabeçalho ]
            var pxPorMm = 72 / 25.2F;
            int offsetMargem = 28;
            foreach (var item in listaDeListaCabecalho)
            {
                offsetMargem += 4;
            }
            Rectangle rectangle;
            switch (tamanho)
            {
                case tamanhoPagina.a4:
                    rectangle = PageSize.A4;
                    break;
                case tamanhoPagina.a4_landScape:
                    rectangle = PageSize.A4_LANDSCAPE;
                    break;
                default:
                    rectangle = PageSize.A4;
                    break;
            }

            var document = new Document(rectangle, 15 * pxPorMm, 15 * pxPorMm, offsetMargem * pxPorMm, 20 * pxPorMm);
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            writer.PageEvent = new ITextEvents(logopath, titulo, textoRef, listaDeListaCabecalho, bordaDireita);
            #endregion

            document.Open();

            //fonte para o restante
            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);
            iTextSharp.text.Font font5Negrito = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 5, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
            iTextSharp.text.Font font6 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 6);
            iTextSharp.text.Font font7 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);


            switch (tipoRelatorio)
            {
                case relatorio.BOLETOS_BANCARIOS_EMITIDOS:
                    break;
                case relatorio.CREDITOS_DO_ARQUIVO_DE_RETORNO:
                    break;
                case relatorio.PREVISAO_DE_RECEITA:
                    break;
                case relatorio.RELACAO_DE_ANUIDADES_RECEBIDAS:
                    break;
                case relatorio.RELACAO_DE_COBRANCAS_CREDITADAS_vs_DEBITADAS:
                    break;
                case relatorio.RELACAO_DE_CONCESSIONARIO:
                    break;
                case relatorio.RELACAO_DE_VALORES_A_RECEBER_COM_DETALHES_SOBRE_A_OCUPACAO:
                    break;
                case relatorio.RELACAO_DE_VALORES_A_RECEBER:
                    break;
                case relatorio.RELACAO_DE_VALORES_RECEBIDOS_COM_DETALHES_SOBRE_A_OCUPACAO:
                    break;
                case relatorio.RELACAO_SINTETICA_DE_PREVISAO_DE_RECEITA:
                    #region [RELACAO_SINTETICA_DE_PREVISAO_DE_RERECEITA]

                    PdfPTable mainTable = new PdfPTable(1);
                    mainTable.DefaultCell.Border = PdfPCell.BOX;

                    PdfPTable tabelaFiltro = new PdfPTable(2);
                    foreach (var item in filtros)
                    {
                        PdfPCell pdfcellFiltro1 = new PdfPCell(new Phrase(item.Chave == null ? "" : item.Chave.ToString(), font5));
                        PdfPCell pdfcellFiltro2 = new PdfPCell(new Phrase(item.Valor == null ? "" : item.Valor.ToString(), font5));
                        pdfcellFiltro1.Border = PdfPCell.NO_BORDER;
                        pdfcellFiltro2.Border = PdfPCell.NO_BORDER;
                        pdfcellFiltro1.HorizontalAlignment = Element.ALIGN_RIGHT;
                        pdfcellFiltro2.HorizontalAlignment = Element.ALIGN_LEFT;
                        tabelaFiltro.AddCell(pdfcellFiltro1);
                        tabelaFiltro.AddCell(pdfcellFiltro2);
                    }
                    mainTable.AddCell(tabelaFiltro);

                    //for (int i = 0; i < 10; i++)
                    //{
                    PdfPTable mainTableLine = new PdfPTable(2);
                    mainTableLine.DefaultCell.Border = 0;

                    //montaLinha totalizador

                    foreach (DataRow r in dataTable.Rows)
                    {


                        foreach (var localCabecalho in listaCabecalho)
                        {
                            Font f = font5;
                            switch (localCabecalho.formatoTexto)
                            {
                                case FormatoTexto.negrito:
                                    f = font5Negrito;
                                    break;
                                case FormatoTexto.normal:
                                    f = font5;
                                    break;
                                default:
                                    break;
                            }
                            var valor = r[localCabecalho.NomeDaPropriedade].ToString();// r.GetType().GetProperty(NomeObjeto).GetValue(r);
                            valor = retornaValorFormato(valor, localCabecalho.formatoNumero);
                            PdfPCell pdfcellInLine = new PdfPCell(new Phrase(valor, f));
                            pdfcellInLine.Border = PdfPCell.NO_BORDER;
                            switch (localCabecalho.posicao)
                            {
                                case PosicaoHorizontal.centro:
                                    pdfcellInLine.HorizontalAlignment = Element.ALIGN_CENTER;
                                    break;
                                case PosicaoHorizontal.esquerda:
                                    pdfcellInLine.HorizontalAlignment = Element.ALIGN_LEFT;
                                    break;
                                case PosicaoHorizontal.direita:
                                    pdfcellInLine.HorizontalAlignment = Element.ALIGN_RIGHT;
                                    break;
                                default:
                                    break;
                            }
                            mainTableLine.AddCell(pdfcellInLine);
                        }
                    }
                    PdfPCell pdfcellTotal = new PdfPCell(new Phrase("TOTAL", font5Negrito));
                    pdfcellTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfcellTotal.Border = PdfPCell.NO_BORDER;
                    mainTableLine.AddCell(pdfcellTotal);

                    double Total = retornaSomaColunaComAproximacoes(dataTable, "ValorPrevisto", FormatoNumero.moedaSemCifrao);//dataTable.AsEnumerable().Sum(row => row.Field<double>("ValorPrevisto"));
                    PdfPCell pdfcellTotalValor = new PdfPCell(new Phrase(retornaValorFormato(Total.ToString(), FormatoNumero.moedaSemCifrao), font5Negrito));
                    pdfcellTotalValor.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfcellTotalValor.Border = PdfPCell.NO_BORDER;
                    mainTableLine.AddCell(pdfcellTotalValor);

                    mainTable.AddCell(mainTableLine);
                    //}
                    //table.AddCell(new Phrase("", font5));
                    //table.AddCell(new Phrase("", font5));
                    //table.AddCell(new Phrase("", font5));
                    //table.AddCell(new Phrase("", font5));
                    //table.AddCell(new Phrase("TOTAL", font5));
                    //table.AddCell(new Phrase("R$ " + faturamento.Sum(n => n.ValorPrevisto).ToString("N2"), font7));
                    //table.AddCell(new Phrase("R$ " + faturamento.Sum(n => n.ValorTotal).ToString("N2"), font7));
                    //table.AddCell(new Phrase("", font5));

                    mainTable.TotalWidth = document.PageSize.Width - 80f;
                    mainTable.WidthPercentage = 100;

                    document.Add(mainTable);
                    document.Close();
                    #endregion
                    break;
                case relatorio.RELACAO_SINTETICA_DE_VALORES_A_RECEBER:
                    break;
                case relatorio.RELACAO_SINTETICA_DE_VALORES_RECEBIDOS:
                    break;
                default:
                    break;
            }




            return memoryStream.ToArray();
        }
    }
    public enum tamanhoPagina
    {
        a4,
        a4_landScape
    }
    public enum relatorio
    {
        BOLETOS_BANCARIOS_EMITIDOS
        , CREDITOS_DO_ARQUIVO_DE_RETORNO
        , PREVISAO_DE_RECEITA
        , RELACAO_DE_ANUIDADES_RECEBIDAS
        , RELACAO_DE_COBRANCAS_CREDITADAS_vs_DEBITADAS
        , RELACAO_DE_CONCESSIONARIO
        , RELACAO_DE_VALORES_A_RECEBER_COM_DETALHES_SOBRE_A_OCUPACAO
        , RELACAO_DE_VALORES_A_RECEBER
        , RELACAO_DE_VALORES_RECEBIDOS_COM_DETALHES_SOBRE_A_OCUPACAO
        , RELACAO_SINTETICA_DE_PREVISAO_DE_RECEITA
        , RELACAO_SINTETICA_DE_VALORES_A_RECEBER
        , RELACAO_SINTETICA_DE_VALORES_RECEBIDOS
    }

    public class Cabecalho
    {
        public string TextoCabecalho { get; set; }
        public string NomeDaPropriedade { get; set; }
        public FormatoNumero formatoNumero { get; set; }
        public FormatoTexto formatoTexto { get; set; }
        public PosicaoHorizontal posicao { get; set; }
        public Totalizador totalizador { get; set; }
        public float largura { get; set; }
        public bool bordaDireita { get; set; }
        public bool ColocarSomaFinal { get; set; }
    }
    public enum PosicaoHorizontal
    {
        centro
            , esquerda
            , direita
    }
    public enum Totalizador
    {
        palavraTotal
            , soma
            , media
    }
    public enum FormatoNumero
    {
        moedaSemCifrao
        , moeda
        , semFormatacao
    }
    public enum FormatoTexto
    {
        negrito
        , normal
    }
    public class Filtros
    {
        public string Chave { get; set; }
        public string Valor { get; set; }
    }
    public class ITextEvents : PdfPageEventHelper
    {
        public ITextEvents(string logoPath, string titulo, string linhaReferencia, List<List<Cabecalho>> headers, bool bordaDireita)
        {
            _logoPath = logoPath;
            _titulo = titulo;
            _headers = headers;
            _linhaReferencia = linhaReferencia;
            _bordaDireita = bordaDireita;
        }
        string _logoPath { get; set; }
        string _titulo { get; set; }
        string _linhaReferencia { get; set; }
        bool _bordaDireita { get; set; }
        List<List<Cabecalho>> _headers { get; set; }

        // This is the contentbyte object of the writer
        PdfContentByte cb;

        // we will put the final number of pages in a template
        PdfTemplate headerTemplate, footerTemplate;

        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;

        // This keeps track of the creation time
        DateTime PrintTime = DateTime.Now;

        #region Fields
        private string _header;
        #endregion

        #region Properties
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }
        #endregion

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                headerTemplate = cb.CreateTemplate(100, 100);
                footerTemplate = cb.CreateTemplate(50, 50);
            }
            catch (DocumentException de)
            {
            }
            catch (System.IO.IOException ioe)
            {
            }
        }

        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            base.OnEndPage(writer, document);
            iTextSharp.text.Font font6 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 6);
            iTextSharp.text.Font baseFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
            iTextSharp.text.Font baseFontSmall = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 6f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            Phrase p1Header = new Phrase(_titulo, baseFontBig);//tilulo pode ter quebras de linhas com \n

            //Create PdfTable object
            PdfPTable pdfTab = new PdfPTable(3);

            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(_logoPath);

            //logo
            float razaoAlturaLargura = logo.Width / logo.Height;
            float alturaLogo = 32;
            float larguraLogo = alturaLogo * razaoAlturaLargura;
            logo.ScaleToFit(larguraLogo, alturaLogo);

            //We will have to create separate cells to include image logo and 2 separate strings
            //Row 1
            PdfPCell pdfCell1 = new PdfPCell(logo);
            PdfPCell pdfCell2 = new PdfPCell(p1Header);
            PdfPCell pdfCell3 = new PdfPCell(new Phrase("Data: " + PrintTime.ToShortDateString() + "\nHora: " + string.Format("{0:t}", DateTime.Now), baseFontSmall));
            String text = "Pag. " + writer.PageNumber + " de ";

            ////Add paging to header
            //{
            //    cb.BeginText();
            //    cb.SetFontAndSize(bf, 6);

            //    cb.SetTextMatrix(document.PageSize.GetRight(200), document.PageSize.GetTop(45));
            //    cb.ShowText(text);
            //    cb.EndText();
            //    float len = bf.GetWidthPoint(text, 6);
            //    //Adds "12" in Page 1 of 12
            //    cb.AddTemplate(headerTemplate, document.PageSize.GetRight(200) + len, document.PageSize.GetTop(45));
            //}
            ////Add paging to footer
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 6);
                cb.SetTextMatrix(document.PageSize.GetRight(60), document.PageSize.GetBottom(30));
                cb.ShowText(text);
                cb.EndText();
                float len = bf.GetWidthPoint(text, 6);
                cb.AddTemplate(footerTemplate, document.PageSize.GetRight(60) + len, document.PageSize.GetBottom(30));
            }

            //Row 2 --> linha em branco
            PdfPCell pdfCell4 = new PdfPCell(new Phrase("", font6));
            pdfCell4.MinimumHeight = 4;
            pdfCell4.Colspan = 3;

            //Row 3 --> linha de referencia ( sempre com o fundo cinza )
            PdfPCell pdfCell5 = new PdfPCell(new Phrase(_linhaReferencia, font6));
            pdfCell5.BackgroundColor = new BaseColor(System.Drawing.Color.LightGray);
            pdfCell5.MinimumHeight = 12;
            pdfCell5.Colspan = 3;


            //set the alignment of all three cells and set border to 0
            pdfCell1.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell2.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT;
            pdfCell4.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell5.HorizontalAlignment = Element.ALIGN_CENTER;

            pdfCell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell2.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell3.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell4.VerticalAlignment = Element.ALIGN_TOP;
            pdfCell5.VerticalAlignment = Element.ALIGN_MIDDLE;

            pdfCell1.Border = 0;
            pdfCell2.Border = 0;
            pdfCell3.Border = 0;
            pdfCell4.Border = 0;
            pdfCell5.Border = 1;

            //add all three cells into PdfTable
            pdfTab.AddCell(pdfCell1);
            pdfTab.AddCell(pdfCell2);
            pdfTab.AddCell(pdfCell3);
            pdfTab.AddCell(pdfCell4);
            pdfTab.AddCell(pdfCell5);

            //Row 4 --> linhas de cabeçalho da tabela (serão tabelas com as larguras específcadas)
            //linhas de cabeçalho da tabela
            foreach (var item in _headers)
            {
                PdfPTable tabelaLinha = new PdfPTable(item.Count());
                float[] widths = item.Select(x => x.largura).ToArray();
                tabelaLinha.SetWidths(widths);
                foreach (var localHeader in item)
                {
                    PdfPCell localpdfCell = new PdfPCell(new Phrase(localHeader.TextoCabecalho, font6));
                    localpdfCell.Border = 0;
                    if (_bordaDireita && localHeader.bordaDireita)
                    {
                        localpdfCell.Border = PdfPCell.RIGHT_BORDER;
                    }
                    else
                    {
                        localpdfCell.Border = PdfPCell.NO_BORDER;
                    }
                    switch (localHeader.posicao)
                    {
                        case PosicaoHorizontal.centro:
                            localpdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            break;
                        case PosicaoHorizontal.esquerda:
                            localpdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                            break;
                        case PosicaoHorizontal.direita:
                            localpdfCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                            break;
                        default:
                            localpdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            break;
                    }
                    localpdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    tabelaLinha.AddCell(localpdfCell);
                }

                PdfPCell pdfcell = new PdfPCell(tabelaLinha);
                pdfcell.Border = 0;
                pdfcell.Colspan = 3;
                pdfTab.AddCell(pdfcell);
            }

            pdfTab.TotalWidth = document.PageSize.Width - 80f;
            pdfTab.WidthPercentage = 100;
            //pdfTab.HorizontalAlignment = Element.ALIGN_CENTER;    

            //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
            //first param is start row. -1 indicates there is no end row and all the rows to be included to write
            //Third and fourth param is x and y position to start writing
            pdfTab.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 30, writer.DirectContent);
            //set pdfContent value

            //Move the pointer and draw line to separate header section from rest of page
            int offsetPosicaoLinha = 80;
            foreach (var item in _headers)
            {
                offsetPosicaoLinha += 10;
            }
            cb.MoveTo(40, document.PageSize.Height - offsetPosicaoLinha);
            cb.LineTo(document.PageSize.Width - 40, document.PageSize.Height - offsetPosicaoLinha);
            cb.Stroke();

            //Move the pointer and draw line to separate footer section from rest of page
            cb.MoveTo(40, document.PageSize.GetBottom(50));
            cb.LineTo(document.PageSize.Width - 40, document.PageSize.GetBottom(50));
            cb.Stroke();
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            headerTemplate.BeginText();
            headerTemplate.SetFontAndSize(bf, 6);
            headerTemplate.SetTextMatrix(0, 0);
            headerTemplate.ShowText((writer.PageNumber).ToString());
            headerTemplate.EndText();

            footerTemplate.BeginText();
            footerTemplate.SetFontAndSize(bf, 6);
            footerTemplate.SetTextMatrix(0, 0);
            footerTemplate.ShowText((writer.PageNumber).ToString());
            footerTemplate.EndText();
        }
    }

}