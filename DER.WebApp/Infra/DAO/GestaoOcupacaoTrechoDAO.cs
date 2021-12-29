using Dapper;
using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.ViewModels.GestaoInteressados;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DER.WebApp.Helper;

namespace DER.WebApp.Infra.DAO
{
    public class GestaoOcupacaoTrechoDAO : BaseDAO<GestaoOcupacaoTrecho>
    {
        private Logger _logger;
        public GestaoOcupacaoTrechoDAO(DerContext context) : base(context)
        {
            _logger = new Logger("Gestão Ocupação Trecho", context);
        }

        public void ExcluirPorIdOcupacao(int idOcupacao)
        //-- Description:	Deleta um Trecho da Ocupação.
        //PROC: [STP_DEL_GESTAO_OCUPACAO_TRECHO_ID]
        {
            var oldValue = GetByOcupacaoId(idOcupacao);
            
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            const string sql = @"delete from tab_gestao_ocupacao_trecho where ocu_id = @idOcupacao";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sql, new { idOcupacao = idOcupacao }, commandType: CommandType.Text).ToList();

                conexao.Close();
                _logger.salvarLog(TipoAlteracao.Exclusao,idOcupacao.ToString(), _logger.serializer.Serialize(oldValue) , "");
            }
        }

        public List<GestaoOcupacoesTrechoViewModel> GetByOcupacaoId(int idOcupacao)
        //-- Description:	Busca um Trecho da Ocupação.
        //PROC: [STP_SEL_GESTAO_OCUPACAO_TRECHO_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<GestaoOcupacoesTrechoViewModel>();

            const string sql = @"select		trecho.ocu_tre_id as Id,
                                            trecho.ocu_tre_kminicial as KmInicial,
                                            trecho.ocu_tre_kminicial_metragem as KmInicialMetragem,
                                            trecho.ocu_tre_kmfinal as KmFinal,
                                            trecho.ocu_tre_kmfinal_metragem as KmFinalMetragem,
                                            trecho.ocu_tre_extensao as Extensao,
                                            trecho.ocu_tre_lado as LadoId,
                                            lado.dmv_valor as LadoNome,
                                            trecho.ocu_tre_altura as Altura,
                                            trecho.ocu_tre_profundidade as Profundidade,
			                                trecho.ocu_tre_rodovia_id as IdRodovia,
			                                rodovia.dmv_valor as NomeRodovia,
			                                trecho.ocu_tre_tipo_ocupacao_id as IdTipoOcupacao,
                                            trecho.ocu_tre_tipo_ocupacao_id as TipoOcupacaoId,
			                                tipoocupacao.dmv_valor as NomeTipoOcupacao,
			                                trecho.ocu_tre_tipo_implantacao_id as IdTipoImplantacao,
			                                tipoimplantacao.dmv_valor as NomeTipoImplantacao,
			                                trecho.ocu_tre_localizacao as IdLocalizacao,
			                                trecho.ocu_tre_tipo_passagem_id as IdTipoPassagem,
			                                tipopassagem.dmv_valor as NomeTipoPassagem
                                    from tab_gestao_ocupacao_trecho trecho
	                                LEFT JOIN tab_dadosMestres_val rodovia on (rodovia.col_id = 13 and rodovia.dmv_id = trecho.ocu_tre_rodovia_id)
	                                LEFT JOIN tab_dadosMestres_val tipoocupacao on (tipoocupacao.col_id = 30 and tipoocupacao.dmv_id = trecho.ocu_tre_tipo_ocupacao_id)
	                                LEFT JOIN tab_dadosMestres_val tipoimplantacao on (tipoimplantacao.col_id = 39 and tipoimplantacao.dmv_id = trecho.ocu_tre_tipo_implantacao_id)
	                                LEFT JOIN tab_dadosMestres_val tipopassagem on (tipopassagem.col_id = 38 and tipopassagem.dmv_id = trecho.ocu_tre_tipo_passagem_id)
                                    LEFT JOIN tab_dadosMestres_val lado on (lado.col_id = 41 and lado.dmv_id = trecho.ocu_tre_lado)
                                where trecho.ocu_id = @idOcupacao";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                retorno = db.Query<GestaoOcupacoesTrechoViewModel>(sql, new { idOcupacao = idOcupacao }, commandType: CommandType.Text).ToList();
            }

            return retorno;
        }

        public int Inserir(GestaoOcupacaoTrecho domain)
        //-- Description:	Insere um Trecho novo na Ocupação.
        //PROC: [STP_INS_GESTAO_OCUPACAO_TRECHO]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            string sql = @"INSERT INTO tab_gestao_ocupacao_trecho
                                OUTPUT INSERTED.ocu_tre_id
                                VALUES( @gestaoOcupacaoId,
                                        @rodoviaId,
                                        @kmInicial,
                                        @kmFinal,
                                        @extensao,
                                        @localizacao,
                                        @tipoImplantacaoId,
                                        @tipoPassagemId,
                                        @ladoId,
                                        @tipoOcupacaoId,
                                        @altura,
                                        @profundidade,
                                        @kmInicialMetragem,
                                        @kmFinalMetragem)";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                var retorno = conexao.QuerySingle<int>(sql, new
                {
                    gestaoOcupacaoId = domain.GestaoOcupacaoId,
                    rodoviaId = domain.RodoviaId,
                    kmInicial = domain.KmInicial,
                    KmInicialMetragem = domain.KmInicialMetragem,
                    kmFinal = domain.KmFinal,
                    KmFinalMetragem = domain.KmFinalMetragem,
                    extensao = domain.Extensao,
                    localizacao = domain.Localizacao,
                    tipoImplantacaoId = domain.TipoImplantacaoId,
                    tipoPassagemId = domain.TipoPassagemId,
                    ladoId = domain.LadoId,
                    tipoOcupacaoId = domain.TipoOcupacaoId,
                    altura = domain.Altura,
                    profundidade = domain.Profundidade,
                }, commandType: CommandType.Text);

                conexao.Close();
                _logger.salvarLog(TipoAlteracao.Criacao,retorno.ToString(), "" , _logger.serializer.Serialize(domain));
                return retorno;
            }
        }
    }
}