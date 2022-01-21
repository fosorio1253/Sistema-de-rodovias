using AutoMapper;
using DER.WebApp.Common.Helper;
using DER.WebApp.Domain.Business;
using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.Constants;
using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Helper;
using DER.WebApp.Models;
using DER.WebApp.Models.Enum;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.Validadores;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    [AuthorizeCustomAttribute(Roles = Permissoes.UsuarioExternoCodigo)]
    public class UsuarioExternoController : HelperController
    {

        private UsuarioBLL usuarioBLL;
        private GrupoBLL grupoBLL;
        private EmpresaBLL empresaBLL;
        private ArquivoBLL arquivoBLL;
        private Logger logger;

        public UsuarioExternoController()
        {
            usuarioBLL = new UsuarioBLL();
            grupoBLL = new GrupoBLL();
            empresaBLL = new EmpresaBLL();
            arquivoBLL = new ArquivoBLL();
            logger = new Logger("Usuario Externo");
        }

        // GET: UsuarioExterno
        [AuthorizeCustomAttribute(Roles = Permissoes.UsuarioExternoCodigo)]
        public ActionResult List()
        {
            obtemPermissoes(Permissoes.UsuarioExternoCodigo);
            var Usuarios = usuarioBLL.ObtemTodos(true).ToList();
            return View(Usuarios);
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.UsuarioExternoCodigo + Permissoes.CadastrarCodigo)]
        public ActionResult Novo()
        {
            ObtemSelects();
            var usuario = new UsuarioExternoViewModel();

            ViewData["SomenteVisualizar"] = false;
            ViewData["BloquearEnvioArquivos"] = false;
            return View(usuario);
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.UsuarioExternoCodigo + Permissoes.EditarCodigo)]
        public ActionResult Editar(int id)
        {
            ObtemSelects();
            var usuario = ObtemUsuario(id);

            ViewData["SomenteVisualizar"] = true;
            ViewData["BloquearEnvioArquivos"] = false;
            return View("Novo", usuario);
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.UsuarioExternoCodigo + Permissoes.VisualizarCodigo)]
        public ActionResult Visualizar(int id)
        {
            ObtemSelects();
            var usuario = ObtemUsuario(id);

            ViewData["SomenteVisualizar"] = true;
            ViewData["BloquearEnvioArquivos"] = true;
            return View("Novo", usuario);
        }

        [HttpPost]
        public async Task<ActionResult> Salvar(UsuarioExternoViewModel Usuario)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Usuario.CNPJEmpresa))
                {
                    var exists = empresaBLL.VerificaCNPJExiste(Usuario.CNPJEmpresa);

                    if (exists)
                    {
                        return Json(new UsuarioValidatorViewModel() { validCNPJ = true, validCPF = true, valid = false, CNPJExists = true });
                    }

                    if (!CNPJ.Validar(Usuario.CNPJEmpresa))
                    {
                        return Json(new UsuarioValidatorViewModel() { validCNPJ = false, validCPF = false, valid = false, CNPJExists = false });
                    }
                }

                if (!CPF.Validar(Usuario.CPF))
                {
                    return Json(new UsuarioValidatorViewModel() { validCNPJ = true, validCPF = false, valid = false, CNPJExists = false });
                }

                var usuario = Mapper.Map<UsuarioExternoViewModel, Usuario>(Usuario);

                if (Usuario.Id != 0)
                    logger.salvarLog(TipoAlteracao.Edicao, Usuario.Id.ToString());//, Usuario, usuarioBLL.ObtemId(Usuario.Id));

                var valid = usuarioBLL.Salvar(usuario);

                if(Usuario.Id == 0)
                     logger.salvarLog(TipoAlteracao.Edicao, valid.id.ToString(), Usuario, usuarioBLL.ObtemId(valid.id));

                valid.validCNPJ = true;
                valid.validCPF = true;
                return Json(valid);
            }

            return Json(new UsuarioValidatorViewModel() { validCNPJ = true, validCPF = true, valid = false, CNPJExists = false });
        }

        [HttpGet()]
        public FileResult DownloadArquivo(string caminhoArquivo)
        {
            var extensao = (caminhoArquivo.Contains(".pdf")) ? ".pdf" : ".jpg";
            string contentType = (caminhoArquivo.Contains(".pdf")) ? "application/pdf" : "image/jpg";
            string nomeArquivo = DateTime.Now.ToString("yyyyMMddHHmmss") + extensao;
            return File(caminhoArquivo, contentType, nomeArquivo);
        }

        [HttpPost]
        [AuthorizeCustomAttribute(Roles = Permissoes.UsuarioExternoCodigo + Permissoes.AprovarCodigo)]
        public ActionResult Aprovar(bool aprovar, int idUsuario, string justificativa = "")
        {
            var aprovacao = aprovar ? (int)StatusAprovacaoEnum.Aprovado : (int)StatusAprovacaoEnum.Reprovado;
            var valid = usuarioBLL.AprovacaoUsuario(idUsuario, aprovacao);

            return Json(new { status = valid });
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            var valid = usuarioBLL.Excluir(id);
            return Json(new { status = valid });
        }

        private void ObtemSelects()
        {
            ViewData["Grupos"] = grupoBLL.ObtemTodos().Select(x => new { Text = x.Nome, Value = x.Id });
            ViewData["Empresas"] = empresaBLL.ObtemTodos().Select(x => new { Text = x.Nome, Value = x.Id });
            ViewData["PermissaoAprovacao"] = User.IsInRole(Permissoes.UsuarioExternoCodigo + Permissoes.AprovarCodigo);
        }

        private UsuarioExternoViewModel ObtemUsuario(int id)
        {
            var usuario = usuarioBLL.ObtemId(id);
            var arquivos = arquivoBLL.ObtemArquivoPorUsuarioId(id);

            var usuarioViewModel = Mapper.Map<Usuario, UsuarioExternoViewModel>(usuario);

            if (arquivos != null && arquivos.Count > 0)
            {
                usuarioViewModel.Arquivos = new List<ArquivoViewModel>();

                foreach(var arquivo in arquivos)
                {
                    usuarioViewModel.Arquivos.Add(new ArquivoViewModel()
                    {
                        Id = arquivo.Id,
                        TipoDeArquivo = (arquivo.TipoArquivo == TipoArquivoEnum.Foto) ? "Documento com Foto" : "Procuração",
                        CaminhoArquivo = arquivo.ArquivoNome
                    });
                }
            }

            return usuarioViewModel;
        }

        private UsuarioExternoViewModel ObtemArquivo(int id)
        {
            //var usuario = usuarioBLL.ObtemId(id);
            var arquivo = arquivoBLL.ObtemArquivo(id);
            //return Mapper.Map<Usuario, UsuarioExternoViewModel>(usuario);
            return Mapper.Map<Arquivo, UsuarioExternoViewModel>(arquivo);
        }
    }
}