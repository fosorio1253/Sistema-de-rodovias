
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Web.UI;
using AutoMapper;
using DER.WebApp.Common.Helper;
using DER.WebApp.Domain.Business;
using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.Constants;
using DER.WebApp.ViewModels.Log;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace DER.WebApp.Controllers
{
    public class LogController : HelperController
    {
        LogBLL logAlteracaoBLL;

        public LogController()
        {
            logAlteracaoBLL = new LogBLL();
        }

        public ActionResult Index()
        {
            try
            {
                return View(new LogViewModelParam());
            }
            catch (Exception e)
            {
                throw new System.Exception("Ocorreu um erro ao encriptografar. Entre em contato com o suporte.");
            }
        }

        [HttpPost]
        public ActionResult Buscar(LogViewModelParam logViewModel)
        {
            try
            {
                var model = logAlteracaoBLL.ObtemLista(logViewModel);
                var lista = Mapper.Map<List<LogAlteracao>, List<LogViewModel>>(model);
                return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                throw new System.Exception("Ocorreu um erro. Entre em contato com o suporte.");
            }
        }

        public void ExportDataToXls(LogViewModelParam logViewModel)
        {
            var grid = new System.Web.UI.WebControls.GridView();

            grid.DataSource = logAlteracaoBLL.ObtemLista(logViewModel);

            grid.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Logs.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Write(sw.ToString());

            Response.End();
        }

        public void ExportDataToXlsx(LogViewModelParam logViewModel)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelPackage Ep = new ExcelPackage();

            var listaParaExportar = logAlteracaoBLL.ObtemLista(logViewModel);

            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Log");
            Sheet.Cells["A1"].Value = "ID";
            Sheet.Cells["B1"].Value = "Nome Entidade";
            Sheet.Cells["C1"].Value = "ID PK";
            Sheet.Cells["D1"].Value = "Valor Antigo";
            Sheet.Cells["E1"].Value = "Novo Valor";
            Sheet.Cells["F1"].Value = "ID Responsável Alteração";
            Sheet.Cells["G1"].Value = "Nome Usuário Responsável";
            Sheet.Cells["H1"].Value = "Data Alteração";
            Sheet.Cells["I1"].Value = "Tipo Alteração";

            Sheet.Row(1).Height = 20;
            Sheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            Sheet.Row(1).Style.Font.Bold = true;

            int row = 2;
            foreach (var item in listaParaExportar)
            {

                Sheet.Cells[string.Format("A{0}", row)].Value = item.Id;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.NomeEntidade;
                Sheet.Cells[string.Format("C{0}", row)].Value = item.IdPrimaryKey;
                Sheet.Cells[string.Format("D{0}", row)].Value = item.ValorAntigo;
                Sheet.Cells[string.Format("E{0}", row)].Value = item.NovoValor;
                Sheet.Cells[string.Format("F{0}", row)].Value = item.ReponsavelAlteracao;
                Sheet.Cells[string.Format("G{0}", row)].Value = item.NomeUsuarioResponsavel;
                Sheet.Cells[string.Format("H{0}", row)].Value = item.DataAlteracao.ToString();
                Sheet.Cells[string.Format("I{0}", row)].Value = item.TipoAlteracao;
                row++;
            }


            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "LogReport.xlsx");

            Response.BinaryWrite(Ep.GetAsByteArray());
            Response.End();
        }

    }
}