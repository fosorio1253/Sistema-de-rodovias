using Dapper;
using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DER.WebApp.Helper;

namespace DER.WebApp.Infra.DAO 
{
    public class GestaoOcupacaoParecerDAO : BaseDAO<GestaoOcupacaoParecer>
    {
        private Logger _logger;
        public GestaoOcupacaoParecerDAO(DerContext context) : base(context)
        {
            _logger = new Logger("Gestão Ocupação Parecer", context);
        }

        public void ExcluirPorIdOcupacao(int idOcupacao)
        //-- Description:	Deleta um Parecer da Ocupação.
        //[STP_DEL_GESTAO_OCUPACAO_PARECER]
        {
            var oldValue = GetByOcupacaoId(idOcupacao);
            
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            const string sql = @"delete from tab_gestao_ocupacao_parecer where ocu_id = @idOcupacao";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sql, new { idOcupacao = idOcupacao }, commandType: CommandType.Text).ToList();

                conexao.Close();
               // _logger.salvarLog(TipoAlteracao.Exclusao,oldValue.Id.ToString(), _logger.serializer.Serialize(oldValue) , "");
            }
        }

        public GestaoOcupacaoParecerViewModel GetByOcupacaoId(int idOcupacao)
        //-- Description:	Busca um Parecer em Ocupações.
        //PROC: [STP_SEL_GESTAO_OCUPACAO_PARECER_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new GestaoOcupacaoParecerViewModel();

            const string sql = @"select 
                                    ocu_par_id as Id,
                                    ocu_par_regional_obeservacao as ParecerRegionalObservacao,
                                    ocu_par_regional_data as ParecerRegionalData,
                                    ocu_par_regional_id as ParecerRegionalId,
                                    ocu_par_engenharia_obeservacao as ParecerDiretoriaEngenhariaObservacao,
                                    ocu_par_engenharia_data as ParecerDiretoriaEngenhariaData,
                                    ocu_par_engenharia_id as ParecerDiretoriaEngenhariaId,
                                    ocu_par_coordenadoria_obeservacao as ParecerCoordenadoriaOperacoesObservacao,
                                    ocu_par_coordenadoria_data as ParecerCoordenadoriaOperacoesData,
                                    ocu_par_coordenadoria_id as ParecerCoordenadoriaOperacoesId,
                                    ocu_par_faixa_obeservacao as ParecerFaixaDominioObservacao,
                                    ocu_par_faixa_data as ParecerFaixaDominioData,
                                    ocu_par_faixa_id as ParecerFaixaDominioId,
                                    ocu_par_data as Data,
                                    ocu_par_caminho_arq_coordenadoria as CaminhoArquivoCoordenadoria,
                                    ocu_par_caminho_arq_diretoria as CaminhoArquivoDiretoria,
                                    ocu_par_caminho_arq_faixa_dominio as CaminhoArquivoFaixaDominio,
                                    ocu_par_caminho_arq_regional as CaminhoArquivoRegional
                                from tab_gestao_ocupacao_parecer
                                where ocu_id = @idOcupacao";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                retorno = db.Query<GestaoOcupacaoParecerViewModel>(sql, new { idOcupacao = idOcupacao }, commandType: CommandType.Text).FirstOrDefault();
            }

            return retorno;
        }

        public void Inserir(GestaoOcupacaoParecer domain)
        //-- Description:	Insere um novo PARECER na Gestão de Ocupações
        //PROC: [STP_INS_GESTAO_OCUPACAO_PARECER]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            string sqlUpdate = @"INSERT INTO tab_gestao_ocupacao_parecer
                                VALUES( @gestaoOcupacaoId,
                                        @parecerRegionalObservacao,
                                        @parecerRegionalData,
                                        @parecerRegionalId,
                                        @parecerDiretoriaEngenhariaObservacao,
                                        @parecerDiretoriaEngenhariaData,
                                        @parecerDiretoriaEngenhariaId,
                                        @parecerCoordenadoriaOperacoesObservacao,
                                        @parecerCoordenadoriaOperacoesData,
                                        @parecerCoordenadoriaOperacoesId,
                                        @parecerFaixaDominioObservacao,
                                        @parecerFaixaDominioData,
                                        @parecerFaixaDominioId,
                                        @data,
                                        @parecerCoordenadoriaDocumentoArquivo,
                                        @parecerDiretoriaDocumentoArquivo,
                                        @parecerFaixaDominioDocumentoArquivo,
                                        @parecerRegionalDocumentoArquivo)";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sqlUpdate, new
                {
                    gestaoOcupacaoId = domain.GestaoOcupacaoId,
                    parecerRegionalId = domain.ParecerRegionalId,
                    parecerRegionalObservacao = domain.ParecerRegionalObservacao,
                    parecerRegionalData = domain.ParecerRegionalData,
                    parecerDiretoriaEngenhariaId = domain.ParecerDiretoriaEngenhariaId,
                    parecerDiretoriaEngenhariaObservacao = domain.ParecerDiretoriaEngenhariaObservacao,
                    parecerDiretoriaEngenhariaData = domain.ParecerDiretoriaEngenhariaData,
                    parecerCoordenadoriaOperacoesId = domain.ParecerCoordenadoriaOperacoesId,
                    parecerCoordenadoriaOperacoesObservacao = domain.ParecerCoordenadoriaOperacoesObservacao,
                    parecerCoordenadoriaOperacoesData = domain.ParecerCoordenadoriaOperacoesData,
                    parecerFaixaDominioId = domain.ParecerFaixaDominioId,
                    parecerFaixaDominioObservacao = domain.ParecerFaixaDominioObservacao,
                    parecerFaixaDominioData = domain.ParecerFaixaDominioData,
                    data = domain.Data,
                    parecerCoordenadoriaDocumentoArquivo = domain.ParecerCoordenadoriaDocumentoArquivo,
                    parecerDiretoriaDocumentoArquivo = domain.ParecerDiretoriaDocumentoArquivo,
                    parecerFaixaDominioDocumentoArquivo = domain.ParecerFaixaDominioDocumentoArquivo,
                    parecerRegionalDocumentoArquivo = domain.ParecerRegionalDocumentoArquivo
                }, commandType: CommandType.Text);

                _logger.salvarLog(TipoAlteracao.Criacao,"", "" , _logger.serializer.Serialize(domain));
                conexao.Close();
            }
        }
    }
}