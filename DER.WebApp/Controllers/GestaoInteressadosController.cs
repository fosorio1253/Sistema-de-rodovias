using DER.WebApp.Common.Helper;
using DER.WebApp.Domain.Business;
using DER.WebApp.Domain.Models.Constants;
using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Helper;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.GestaoInteressados;
using DER.WebApp.ViewModels.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DER.WebApp.Controllers
{
    [AuthorizeCustomAttribute(Roles = Permissoes.GestaoInteressadoCodigo)]
    public class GestaoInteressadosController : HelperController
    {
        #region Construtor

        private GestaoInteressadoBLL gestaoInteressadoBLL;
        private StatusAprovacaoBLL statusBLL;
        private TipoEmpresaBLL tipoEmpresaBLL;
        private TipoInteressadoBLL tipoInteressadoBLL;
        private NaturezaJuridicaBLL naturezaJuridicaBLL;
        private TipoDeConcessaoBLL tipoDeConcessaoBLL;
        private EmpresaBLL empresaBLL;
        private GrupoBLL grupoBLL;
        private UnidadeBLL unidadeBLL;
        private MunicipioBLL municipioBLL;
        private TipoDeDocumentoBLL tipoDeDocumentoBLL;
        private TipoDeDocumentoInteressadoBLL tipoDeDocumentoInteressadoBLL;
        private PerfilBLL perfilBLL;
        private Logger logger;


        public GestaoInteressadosController()
        {
            gestaoInteressadoBLL = new GestaoInteressadoBLL();
            statusBLL = new StatusAprovacaoBLL();
            tipoEmpresaBLL = new TipoEmpresaBLL();
            tipoInteressadoBLL = new TipoInteressadoBLL();
            naturezaJuridicaBLL = new NaturezaJuridicaBLL();
            tipoDeConcessaoBLL = new TipoDeConcessaoBLL();
            empresaBLL = new EmpresaBLL();
            grupoBLL = new GrupoBLL();
            unidadeBLL = new UnidadeBLL();
            municipioBLL = new MunicipioBLL();
            tipoDeDocumentoBLL = new TipoDeDocumentoBLL();
            tipoDeDocumentoInteressadoBLL = new TipoDeDocumentoInteressadoBLL();
            perfilBLL = new PerfilBLL();
            logger = new Logger("Gestão Interessado");

        }

        #endregion

        #region Metodos Publicos

        [AuthorizeCustomAttribute(Roles = Permissoes.GestaoInteressadoCodigo)]
        public ActionResult List()
        {
            obtemPermissoes(Permissoes.GestaoInteressadoCodigo);
            var UsuarioEmpresaId = PerfilUsuario.UsuarioEmpresaId;
            var UsuarioId = PerfilUsuario.UsuarioId;
            var UsuarioPerfilId = PerfilUsuario.UsuarioPerfilId;
            var gestaoInteressados = gestaoInteressadoBLL.ObtemListaGestaoInteressados(UsuarioPerfilId, UsuarioEmpresaId, UsuarioId);
            return View(gestaoInteressados);
        }
        
        [AuthorizeCustomAttribute(Roles = Permissoes.GestaoInteressadoCodigo)]
        public JsonResult ListInteressados()
        {
            obtemPermissoes(Permissoes.GestaoInteressadoCodigo);
            var UsuarioEmpresaId = PerfilUsuario.UsuarioEmpresaId;
            var UsuarioId = PerfilUsuario.UsuarioId;
            var UsuarioPerfilId = PerfilUsuario.UsuarioPerfilId;
            var gestaoInteressados = gestaoInteressadoBLL.ObtemListaGestaoInteressados(UsuarioPerfilId, UsuarioEmpresaId, UsuarioId);
            return Json(gestaoInteressados, JsonRequestBehavior.AllowGet);
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.GestaoInteressadoCodigo + Permissoes.CadastrarCodigo)]
        public ActionResult Novo()
        {
            ViewData["SomenteVisualizar"] = false;
            return View(this.RetornaViewModelNovo());
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.GestaoInteressadoCodigo + Permissoes.EditarCodigo)]
        public ActionResult Editar(int id)
        {
            ViewData["SomenteVisualizar"] = false;
            return View("Novo", this.RetornaViewModelNovo(id));
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.GestaoInteressadoCodigo + Permissoes.VisualizarCodigo)]
        public ActionResult Visualizar(int id)
        {
            ViewData["SomenteVisualizar"] = true;
            return View("Novo", this.RetornaViewModelNovo(id));
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            logger.salvarLog(TipoAlteracao.Exclusao, id.ToString(), null, gestaoInteressadoBLL.ObtemId(id));
            try
            {
                gestaoInteressadoBLL.Excluir(id);
                return Json(new { status = true });
            }
            catch(Exception ex)
            {
                var message = ex.Message;
                return Json(new { status = false });
            }
        }

        [HttpPost]
        public ActionResult Salvar(GestaoInteressadosViewModel viewModel)
        {
            var valid = new GestaoInteressadoValidatorViewModel()
            {
                valid = true
            };

            viewModel.Documento = (!string.IsNullOrEmpty(viewModel.Documento)) ? viewModel.Documento.Replace("/", string.Empty).Replace(".", string.Empty).Replace("-", string.Empty) : string.Empty;

            if (viewModel.NaturezaJuridicaId == (int)NaturezaEnum.PessoaFisica)
            {
                if (!CPF.Validar(viewModel.Documento))
                {
                    return Json(new GestaoInteressadoValidatorViewModel { validCPF = false, validCNPJ = true, valid = false });
                }
            }
            else if (viewModel.NaturezaJuridicaId == (int)NaturezaEnum.PessoaJuridica)
            {
                if (!CNPJ.Validar(viewModel.Documento))
                {
                    return Json(new GestaoInteressadoValidatorViewModel { validCPF = true, validCNPJ = false, valid = false });
                }
            }
            
            valid = gestaoInteressadoBLL.Inserir(viewModel);
            if (valid.valid)
            {
                if (viewModel.Id == 0)
                {
                    logger.salvarLog(TipoAlteracao.Criacao, valid.id.ToString(), gestaoInteressadoBLL.ObtemId(valid.id));
                }
                else
                {
                    logger.salvarLog(TipoAlteracao.Edicao, valid.id.ToString(), gestaoInteressadoBLL.ObtemId(valid.id));
                }
            }
            

            return Json(new GestaoInteressadoValidatorViewModel { validCPF = true, validCNPJ = true, valid = valid.valid });
        }

        public JsonResult ConsultarUsuario(GestaoContatoViewModel viewModel)
        {
            return Json(gestaoInteressadoBLL.GetByParans(viewModel));
        }

        public JsonResult VisualizarContato(int usuarioId)
        {
            return Json(gestaoInteressadoBLL.GetContatoById(usuarioId));
        }

        [HttpGet()]
        public FileResult DownloadArquivo(string caminhoArquivo)
        {
            var extensao = (caminhoArquivo.Contains(".pdf")) ? ".pdf" : ".jpg";
            string contentType = (caminhoArquivo.Contains(".pdf")) ? "application/pdf" : "image/jpg";
            string nomeArquivo = DateTime.Now.ToString("yyyyMMddHHmmss") + extensao;

            return File("C:/der/arquivos/" + caminhoArquivo, contentType, nomeArquivo);
        }

        public JsonResult SalvarArquivo(GestaoDocumentoViewModel viewModel)
        {
            //gestaoInteressadoBLL.SalvarArquivo(viewModel);
            return null;
        }

        #endregion

        #region Metodos Privados

        private GestaoInteressadosViewModel RetornaViewModelNovo(int? id = null)
        {
            var retorno = new GestaoInteressadosViewModel();

            if (id != null)
            {
                retorno = ObtemGestaoInteressado((int)id);
            }

            if (retorno.StatusId == (int)StatusAprovacaoEnum.Credenciado)
            {
                retorno.Validade = retorno.Validade;
            } 
            else
            {
                string dateValidade = null;
                retorno.Validade = dateValidade;
            }

            retorno.TiposEmpresas = new SelectList(ObtemTipoEmpresa(), "TipoEmpresaId", "Nome");
            retorno.Status = new SelectList(ObtemStatus(), "StatusId", "Nome");
            retorno.TiposInteressados = new SelectList(ObtemTipoInteressado(), "TipoInteressadoId", "Nome");
            retorno.NaturezasJuridicas = new SelectList(ObtemNaturezaJuridica(), "NaturezaJuridicaId", "Nome");
            retorno.TiposDeConcessoes = ObtemTipoConcessao(id);
            retorno.Obs = new GestaoObservacaoViewModel();
            retorno.Endereco = new GestaoEnderecoViewModel();
            retorno.Endereco.Municipios = new SelectList(ObtemMunicipio(), "municipio_id", "municipio");
            retorno.Endereco.Estados = new SelectList(ObtemEstado(), "EstadoId", "Nome");
            retorno.Contato = new GestaoContatoViewModel();
            retorno.Contato.Estados = new SelectList(ObtemEstado(), "EstadoId", "Nome");
            retorno.Contato.Empresas = new SelectList(ObtemEmpresa(), "EmpresaId", "Nome");
            //retorno.Contato.Empresas = new SelectList(ObtemEmpresaUsuario(), "EmpresaId", "Nome");

            retorno.Doc = new GestaoDocumentoViewModel();
            retorno.TipoDeDocumentos = new SelectList(ObtemTipoDeDocumentosInteressado(), "TipoDeDocumentoInteressadoId", "Nome");


            ViewBag.Usuario = User.Identity.Name.ToString();
            ViewBag.DataAtual = DateTime.Now.ToString("dd/MM/yyyy");
            ViewData["PermissaoAprovacao"] = User.IsInRole(Permissoes.GestaoInteressadoCodigo + Permissoes.AprovarCodigo);
            ViewData["Grupos"] = grupoBLL.ObtemTodos().Select(x => new { Text = x.Nome, Value = x.Id });
            ViewData["Empresas"] = empresaBLL.ObtemTodos().Select(x => new { Text = x.Nome, Value = x.Id });            
            return retorno;
        }

        [HttpPost]
        public ActionResult RetornaNaturezaJuridica(int? id)
        {
            var lista = ObtemTipoDeDocumento(id);
            return Json(new { status = true, lista = lista });
        }

        private GestaoInteressadosViewModel ObtemGestaoInteressado(int id)
        {
            return gestaoInteressadoBLL.ObtemInfoId(id);
        }
                
        private List<TipoEmpresaViewModel> ObtemTipoEmpresa()
        {
            return tipoEmpresaBLL.ObtemTipoEmpresa();
        }

        private List<StatusViewModel> ObtemStatus()
        {
            return statusBLL.ObtemStatus();
        }

        private List<ViewModels.GestaoInteressados.TipoInteressadoViewModel> ObtemTipoInteressado()
        {
            return tipoInteressadoBLL.ObtemTipoInteressado();
        }

        private List<NaturezaJuridicaViewModel> ObtemNaturezaJuridica()
        {
            return naturezaJuridicaBLL.ObtemNaturezaJuridica();
        }

        private List<TipoDeConcessaoViewModel> ObtemTipoConcessao(int? idGestao)
        {
            return tipoDeConcessaoBLL.ObtemTipoDeConcessao(idGestao);
        }

        private List<EstadoViewModel> ObtemEstado()
        {
            var retorno = new List<EstadoViewModel>();
            var unidades = unidadeBLL.ObtemUnidades();

            foreach(var unidade in unidades)
                retorno.Add(new EstadoViewModel() { EstadoId = unidade.unidade_id, Nome = unidade.nome });
            return retorno;
        }

        private List<MunicipioViewModel> ObtemMunicipio()
        {
            return municipioBLL.ObtemMunicipio();
        }

        private List<EmpresaViewModel> ObtemEmpresa()
        {
            return empresaBLL.ObtemEmpresas();
        }

        //private List<ListaGestaoInteressadoEmpresaUsuarioDTO> ObtemEmpresaUsuario()
        //{
        //    //return empresaBLL.ObtemEmpresaUsuario();
        //}

        private List<TipoDeDocumentoViewModel> ObtemTipoDeDocumento(int? id = null)        
        {
            return tipoDeDocumentoBLL.ObtemTipoDeDocumento(id);
        }
        private List<TipoDeDocumentoInteressadoViewModel> ObtemTipoDeDocumentosInteressado()
        {
            return tipoDeDocumentoInteressadoBLL.ObtemTipoDeDocumentosInteressado();
        }

        
        #endregion
    }
}