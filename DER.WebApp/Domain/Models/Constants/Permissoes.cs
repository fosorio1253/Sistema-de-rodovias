namespace DER.WebApp.Domain.Models.Constants
{
    public static class Permissoes
    {
        public static readonly StaticPermissao UsuarioInterno = new StaticPermissao("USI", "Usuario Interno");
        public const string UsuarioInternoCodigo = "USI";

        public static readonly StaticPermissao UsuarioExterno = new StaticPermissao("USE", "Usuario Externo");
        public const string UsuarioExternoCodigo = "USE";

        public static readonly StaticPermissao Grupo = new StaticPermissao("GRP", "Grupo");
        public const string GrupoCodigo = "GRP";

        public static readonly StaticPermissao Perfil = new StaticPermissao("PER", "Perfil");
        public const string PerfilCodigo = "PER";

        public static readonly StaticPermissao DadosMestres =  new StaticPermissao("DDM", "Dados Mestres");
        public const string DadosMestresCodigo =  "DDM";

        public static readonly StaticPermissao GestaoInteressado = new StaticPermissao("GES", "Gestão de Interessado");
        public const string GestaoInteressadoCodigo = "GES";

        public static readonly StaticPermissao ProjetosMelhorias = new StaticPermissao("PRO", "Projetos de Melhorias");
        public const string ProjetosMelhoriasCodigo = "PRO";

        public static readonly StaticPermissao GestaoOcupacoes = new StaticPermissao("GOC", "Gestão de Ocupações");
        public const string GestaoOcupacoesCodigo = "GOC";

        public static readonly StaticPermissao GestaoOcorrencias = new StaticPermissao("GEO", "Gestão de Ocorrências");
        public const string GestaoOcorrenciasCodigo = "GEO";

        public static readonly StaticPermissao Apis = new StaticPermissao("API", "Apis");
        public const string ApisCodigo = "API";

        public static readonly StaticPermissao Logs = new StaticPermissao("LOG", "Logs");
        public const string LogsCodigo = "LOG";

        public static readonly StaticPermissao Emails = new StaticPermissao("EML", "Emails");
        public const string EmailsCodigo = "EML";

        public static readonly StaticPermissao Template = new StaticPermissao("TMP", "Templates");
        public const string TemplatesCodigo = "TMP";

        public static readonly StaticPermissao Financeiro = new StaticPermissao("FIN", "Financeiro");
        public const string FinanceiroCodigo = "FIN";

        public static readonly StaticPermissao ConsultarRodovias = new StaticPermissao("CRO", "Consultar Rodovias");
        public const string ConsultarRodoviasCodigo = "CRO";

        public static readonly StaticPermissao Inadimplentes = new StaticPermissao("INA", "Lista de inadimplentes");
        public const string InadimplentesCodigo = "INA";

        public static readonly StaticPermissao Cadastrar = new StaticPermissao("CAD", "Cadastrar");
        public const string CadastrarCodigo = "CAD";

        public static readonly StaticPermissao Editar = new StaticPermissao("EDI", "Editar");
        public const string EditarCodigo = "EDI";

        public static readonly StaticPermissao Visualizar = new StaticPermissao("VIS", "Visualizar");
        public const string VisualizarCodigo = "VIS";

        public static readonly StaticPermissao Excluir =new StaticPermissao("EXC", "Excluir");
        public const string ExcluirCodigo = "EXC";

        public static readonly StaticPermissao Listar = new StaticPermissao("LIS", "Listar");
        public const string ListarCodigo = "LIS";

        public static readonly StaticPermissao Aprovar = new StaticPermissao("APR", "Aprovar");
        public const string AprovarCodigo = "APR";
    }

    public class StaticPermissao
    {
        public StaticPermissao(string codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }
        public string Nome { get; private set; }
        public string Codigo { get; private set; }
    }
}