using DER.WebApp.Domain.Business;
using DER.WebApp.Helper;
using DER.WebApp.ViewModels;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Linq;
using System.Web.Mvc;

namespace DER.WebApp.Controllers
{
    public class InadimplentesController : Controller
    {
        private InadimplentesViewBLL inadimplentesViewBLL;

        public InadimplentesController()
        {
            inadimplentesViewBLL = new InadimplentesViewBLL();
        }

        public ActionResult Index()
        {
            return View(RetornaViewModelNovo());
        }


        private InadimplentesViewModel RetornaViewModelNovo()
        {
            var retorno = new InadimplentesViewModel();
            retorno.lInadimplentes = inadimplentesViewBLL.Read(new InadimplentesViewModel());

            return retorno;
        }

        [HttpPost]
        public ActionResult Buscar(InadimplentesViewModel viewModel)
        {
            try
            {
                return Json(new { data = inadimplentesViewBLL.Read(viewModel) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw new System.Exception("Ocorreu um erro. Entre em contato com o suporte.");
            }
        }

        [HttpPost]
        public FileResult RelatorioPdf(InadimplentesViewModel viewModel)
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

        [HttpPost]
        public FileResult ExportDataToXlsx(InadimplentesViewModel viewModel)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage Ep = new ExcelPackage();

            //TODO: Adicionar viewModel como parametro para filtrar
            var listaParaExportar = inadimplentesViewBLL.Read(viewModel);

            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Inadimplentes");
            Sheet.Cells["A1"].Value = "Protocolo";
            Sheet.Cells["B1"].Value = "Interessado";
            Sheet.Cells["C1"].Value = "Tipo Faturamento";
            Sheet.Cells["D1"].Value = "Tipo Ocupacao";
            Sheet.Cells["E1"].Value = "Estado";
            Sheet.Cells["F1"].Value = "Valor Total";
            Sheet.Cells["G1"].Value = "Valor Previsto";
            Sheet.Cells["H1"].Value = "Periodo";

            Sheet.Row(1).Height = 20;
            Sheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            Sheet.Row(1).Style.Font.Bold = true;

            int row = 2;
            foreach (var item in listaParaExportar)
            {
                Sheet.Cells[string.Format("A{0}", row)].Value = item.Protocolo;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.NomeInteressado;
                Sheet.Cells[string.Format("C{0}", row)].Value = item.TipoFaturamento;
                Sheet.Cells[string.Format("D{0}", row)].Value = item.TipoOcupacao;
                Sheet.Cells[string.Format("E{0}", row)].Value = item.StatusBoleto;
                Sheet.Cells[string.Format("F{0}", row)].Value = item.ValorTotal;
                Sheet.Cells[string.Format("G{0}", row)].Value = item.ValorPrevisto;
                Sheet.Cells[string.Format("H{0}", row)].Value = item.Periodo;
                row++;
            }

            Sheet.Cells["A:AZ"].AutoFitColumns();
            
            byte[] bytes = Ep.GetAsByteArray();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("Content-Disposition", "attachment;filename=Inadimplentes.xlsx");
            Response.BinaryWrite(bytes);
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
}