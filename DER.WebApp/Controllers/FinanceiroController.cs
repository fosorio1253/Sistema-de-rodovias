using DER.WebApp.Domain.Business;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.Financeiro.Faturamento;
using DER.WebApp.ViewModels.Financeiro.FaturamentoPorOcupacao;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using DER.WebApp.ViewModels.ProjetosMelhorias;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using DER.WebApp.Common.Helper;
using DER.WebApp.Domain.Models.DTO;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.io;
using System.Drawing;
using Font = iTextSharp.text.Font;
using DER.WebApp.Helper;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace DER.WebApp.Controllers
{
    public class FinanceiroController : Controller
    {
        private TipoOcupacoesBLL tipoOcupacoesBLL;
        private RegionalBLL regionalBLL;
        private ResidenciaConservacoesBLL residenciaConservacoesBLL;
        private FaturamentoBLL faturamentoBLL;
        private FaturamentoOcupacaoBLL faturamentoOcupacaoBLL;
        private RodoviaBLL rodoviaBLL;
        private GestaoInteressadoBLL gestaoInteressadoBLL;

        public FinanceiroController()
        {
            tipoOcupacoesBLL = new TipoOcupacoesBLL();
            regionalBLL = new RegionalBLL();
            residenciaConservacoesBLL = new ResidenciaConservacoesBLL();
            faturamentoBLL = new FaturamentoBLL();
            faturamentoOcupacaoBLL = new FaturamentoOcupacaoBLL();
            rodoviaBLL = new RodoviaBLL();
            gestaoInteressadoBLL = new GestaoInteressadoBLL();
        }

        public ActionResult Faturamento()
        {
            try
            {
                return View(RetornaFaturamentoViewModelNovo());
            }
            catch (Exception e)
            {
                throw new System.Exception("Ocorreu um erro ao encriptografar. Entre em contato com o suporte.");
            }
        }

        public ActionResult FaturamentoOcupacao()
        {
            try
            {
                return View(RetornaFaturamentoOcupacaoViewModelNovo());
            }
            catch (Exception e)
            {
                throw new System.Exception("Ocorreu um erro ao encriptografar. Entre em contato com o suporte.");
            }
        }

        [HttpPost]
        public ActionResult BuscarFaturamento(FaturamentoViewModelParams viewModel)
        {
            try
            {
                return Json(new { data = faturamentoBLL.ObterFaturamento(viewModel) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw new System.Exception("Ocorreu um erro. Entre em contato com o suporte.");
            }
        }


        [HttpPost]
        public FileResult RelatorioPdf(FaturamentoPorOcupacaoViewModelParam viewModel)
        {
            try
            {
                PDF pdf = new PDF();
                var bytes = pdf.MontarPdf(viewModel, viewModel.Relatorio, HttpContext);
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=Receipt-test.pdf");
                Response.BinaryWrite(bytes.ToArray());
                return File(bytes, "application/pdf");
            }
            catch (Exception e)
            {
                throw new System.Exception("Ocorreu um erro. Entre em contato com o suporte.");
            }
        }

        //[HttpPost]
        //public FileResult RelatorioSinteticoPDF(FaturamentoPorOcupacaoViewModelParam viewModel)
        //{
        //    try
        //    {
        //        var faturamento = faturamentoOcupacaoBLL.ObterFaturamento(viewModel);
        //        //Document document = new Document(new Rectangle(288f, 144f), 10, 10, 10, 10);d
        //        //document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());

        //        var pxPorMm = 72 / 25.2F;
        //        var document = new Document(PageSize.A4, 15 * pxPorMm, 15 * pxPorMm, 40 * pxPorMm, 20 * pxPorMm);
        //        string logopath = HttpContext.Server.MapPath("~/img/logo.png");
        //        MemoryStream memoryStream = new MemoryStream();
        //        PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
        //        string titulo = "Relatório Sintetico";

        //        List<header> headers = new List<header>();
        //        header header1 = new header();
        //        header1.headers = ("Período,Valor Total,Valor Previsto").Split(',').ToArray();
        //        header1.headersNamesOfProperties = ("Periodo,ValorTotal,ValorPrevisto").Split(',').ToArray();
        //        header1.headerwidths = new float[] { 100, 100, 20 };
        //        headers.Add(header1);


        //        faturamento.ForEach(item =>
        //        {
        //            var per = item.Periodo.Split('/');
        //            if (per.Length > 0)
        //            {
        //                var periodo = per[0].PadLeft(2, '0') + "/" + per[1].PadLeft(2, '0') + "/" + per[2].PadLeft(4, '0');
        //                item.Periodo = periodo;
        //            }
        //        });

        //        List<FaturamentoSintetico> listFaturamentoSintetico = new List<FaturamentoSintetico>();
        //        listFaturamentoSintetico.AddRange(faturamento.GroupBy(x => x.Periodo.Remove(0, 3))
        //                                            .Select(p => new FaturamentoSintetico { Periodo = p.Key, ValorTotal = p.Sum(item => item.ValorTotal), ValorPrevisto = p.Sum(item => item.ValorPrevisto) })); ;

        //        PDF pdf = new PDF();
        //        var bytes = pdf.MontarPdf(listFaturamentoSintetico.ToDataTable()
        //            , headers
        //            , logopath
        //            , "ref"
        //            , titulo
        //            , tamanhoPagina.a4
        //            , null
        //            , null
        //            , true);

        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("Content-Disposition", "attachment;filename=Receipt-test.pdf");
        //        Response.BinaryWrite(memoryStream.ToArray());
        //        return File(bytes, "application/pdf");
        //    }
        //    catch (Exception e)
        //    {
        //        throw new System.Exception("Ocorreu um erro. Entre em contato com o suporte.");
        //    }
        //}

        //[HttpPost]
        //public FileResult RelatorioAnaliticoPDF(FaturamentoPorOcupacaoViewModelParam viewModel)
        //{
        //    try
        //    {
        //        var faturamento = faturamentoOcupacaoBLL.ObterFaturamento(viewModel);

        //        //List<header> headers = new List<header>();

        //        //header header1 = new header();
        //        //string[] h1 = ("Protocolo,Período,Interessado,Tipo Faturamento,Tipo Ocupação,Valor Total,Valor Previsto,Status").Split(',').ToArray();
        //        //string[] n1 = ("Protocolo,Periodo,Interessado,TipoFaturamento,TipoOcupacao,ValorTotal,ValorPrevisto,Status").Split(',').ToArray();
        //        //float[] f1 = { 30, 30, 40, 25, 25, 25, 25, 25 }; //soma=260 //min +- 25
        //        //header1.headers = h1;
        //        //header1.headersNamesOfProperties = n1;
        //        //header1.headerwidths = f1;
        //        //headers.Add(header1);

        //        //string logopath = HttpContext.Server.MapPath("~/img/logo.png");

        //        //string textoFiltro = "";
        //        //foreach (var prop in viewModel.GetType().GetProperties())
        //        //{
        //        //    var valorFiltro = viewModel.GetType().GetProperty(prop.Name).GetValue(viewModel);
        //        //    if (valorFiltro != null && !string.IsNullOrEmpty(valorFiltro.ToString()))
        //        //    {
        //        //        textoFiltro += prop.Name + "=";
        //        //        textoFiltro += valorFiltro;
        //        //        textoFiltro += " | ";
        //        //    }

        //        //}

        //        //string titulo = "Relatório Analítico";
        //        //PDF pdf = new PDF();
        //        //var bytes = pdf.MontarPdf(faturamento.ToDataTable()
        //        //    , headers
        //        //    , logopath
        //        //    , "oi"
        //        //    , titulo
        //        //    , tamanhoPagina.a4
        //        //    , null
        //        //    , new string[] { "ValorPrevisto", "ValorTotal" }
        //        //    , false);

        //        //header header1 = new header();
        //        //string[] h1 = { "Protocolo", "Período", "Interessado" };
        //        //string[] n1 = { "Protocolo", "Periodo", "Interessado" };
        //        //float[] f1 = { 35, 35, 50 }; //soma=260 //min +- 25
        //        //header1.headers = h1;
        //        //header1.headersNamesOfProperties = n1;
        //        //header1.headerwidths = f1;
        //        //headers.Add(header1);

        //        //header header2 = new header();
        //        //string[] h2 = ("Tipo Faturamento,Tipo Ocupação,Valor Total,Valor Previsto,Status").Split(',').ToArray();
        //        //string[] n2 = ("TipoFaturamento,TipoOcupacao,ValorTotal,ValorPrevisto,Status").Split(',').ToArray();
        //        //float[] f2 = { 25, 25, 25, 25, 25 }; //soma=260 //min +- 25
        //        //header2.headers = h2;
        //        //header2.headersNamesOfProperties = n2;
        //        //header2.headerwidths = f2;
        //        //headers.Add(header2);
                
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("Content-Disposition", "attachment;filename=Receipt-test.pdf");
        //        Response.BinaryWrite(bytes.ToArray());
        //        return File(bytes, "application/pdf");
        //    }
        //    catch (Exception e)
        //    {
        //        throw new System.Exception("Ocorreu um erro. Entre em contato com o suporte.");
        //    }
        //}

        [HttpPost]
        public ActionResult BuscarFaturamentoOcupacao(FaturamentoPorOcupacaoViewModelParam viewModel)
        {
            try
            {
                var faturamento = faturamentoOcupacaoBLL.ObterFaturamento(viewModel);
                return Json(new { calculado = faturamento.Sum(x => x.ValorTotal), data = faturamento }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw new System.Exception("Ocorreu um erro. Entre em contato com o suporte.");
            }
        }

        private FaturamentoViewModelParams RetornaFaturamentoViewModelNovo()
        {
            var retorno = new FaturamentoViewModelParams();
            retorno.Ocupacoes = new SelectList(ObtemOcupacoes(), "TipoOcupacaoId", "Nome");
            return retorno;
        }

        private FaturamentoPorOcupacaoViewModelParam RetornaFaturamentoOcupacaoViewModelNovo()
        {
            var retorno = new FaturamentoPorOcupacaoViewModelParam();
            retorno.Ocupacoes = new SelectList(ObtemOcupacoes(), "TipoOcupacaoId", "Nome");
            retorno.Regionais = new SelectList(ObtemRegionais(), "RegionalId", "Nome");
            retorno.ResidenciaConservacoes = new SelectList(ObtemResidenciaConservacoes(), "ResidenciaConservacaoId", "Nome");
            retorno.Rodovias = new SelectList(ObtemRodovia(), "rod_id", "rod_codigo");
            retorno.Interessados = new SelectList(ObtemInteressados(), "Id", "Interessado");

            retorno.TipoFaturamentoAnuidade = true;
            retorno.TipoFaturamentoPEP = true;
            retorno.TipoFaturamentoRegularizacao = true;
            retorno.TipoFaturamentoJuridica = true;

            retorno.StatusPago = true;
            retorno.StatusPendente = true;
            retorno.StatusVencido = true;
            return retorno;
        }

        // Export Faturamento XLSX
        [HttpPost]
        public FileResult ExportDataToXlsxFaturamento(FaturamentoPorOcupacaoViewModelParam viewModel)
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelPackage Ep = new ExcelPackage();

            //TODO: Adicionar viewModel como parametro para filtrar
            var listaParaExportar = faturamentoOcupacaoBLL.ObterFaturamento(viewModel);

            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Faturamento");
            Sheet.Cells["A1"].Value = "Tipo Faturamento";
            Sheet.Cells["B1"].Value = "Tipo Ocupação";
            Sheet.Cells["C1"].Value = "Valor Total";
            Sheet.Cells["D1"].Value = "Estado";


            Sheet.Row(1).Height = 20;
            Sheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            Sheet.Row(1).Style.Font.Bold = true;

            int row = 2;
            foreach (var item in listaParaExportar)
            {

                Sheet.Cells[string.Format("A{0}", row)].Value = item.TipoFaturamento;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.TipoOcupacao;
                Sheet.Cells[string.Format("C{0}", row)].Value = item.ValorTotal;
                Sheet.Cells[string.Format("D{0}", row)].Value = item.Status;
                row++;
            }


            Sheet.Cells["A:AZ"].AutoFitColumns();
            //Response.Clear();
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.AddHeader("content-disposition", "attachment: filename=" + "Faturamento.xlsx");

            //Response.BinaryWrite(Ep.GetAsByteArray());
            //Response.End();

            byte[] bytes = Ep.GetAsByteArray();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("Content-Disposition", "attachment;filename=Faturamento.xlsx");
            Response.BinaryWrite(bytes);
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        // Export Faturamento Por Ocupacao XLSX
        public void ExportDataToXlsxFaturamentoOcupacao(FaturamentoPorOcupacaoViewModelParam viewModel)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelPackage Ep = new ExcelPackage();

            //TODO: Adicionar viewModel como parametro para filtrar
            var listaParaExportar = faturamentoOcupacaoBLL.ObterFaturamento();

            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Faturamento");
            Sheet.Cells["A1"].Value = "Tipo Faturamento";
            Sheet.Cells["B1"].Value = "Tipo Ocupação";
            Sheet.Cells["C1"].Value = "Valor Total";
            Sheet.Cells["D1"].Value = "Estado";


            Sheet.Row(1).Height = 20;
            Sheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            Sheet.Row(1).Style.Font.Bold = true;

            int row = 2;
            foreach (var item in listaParaExportar)
            {

                Sheet.Cells[string.Format("A{0}", row)].Value = item.TipoFaturamento;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.TipoOcupacao;
                Sheet.Cells[string.Format("C{0}", row)].Value = item.ValorTotal;
                Sheet.Cells[string.Format("D{0}", row)].Value = item.Status;
                row++;
            }


            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "Faturamento.xlsx");

            Response.BinaryWrite(Ep.GetAsByteArray());
            Response.End();
        }

        private List<ViewModels.ProjetosMelhorias.RodoviaViewModel> ObtemRodovia()
        {
            return rodoviaBLL.ObterRodovias();
        }

        private List<TipoOcupacaoViewModel> ObtemOcupacoes()
        {
            return tipoOcupacoesBLL.ObtemTipoOcupacoes();
        }

        private List<RegionalViewModel> ObtemRegionais()
        {
            return regionalBLL.ObtemRegionais();
        }

        private List<GestaoOcupacoesResidenciaConservacaoViewModel> ObtemResidenciaConservacoes()
        {
            return residenciaConservacoesBLL.ObtemResidenciaConservacoes();
        }

        private List<ListaGestaoInteressadoDTO> ObtemInteressados()
        {
            return gestaoInteressadoBLL.ObtemListaGestaoInteressados(PerfilUsuario.UsuarioPerfilId, PerfilUsuario.UsuarioEmpresaId, PerfilUsuario.UsuarioId);
        }
    }
}
