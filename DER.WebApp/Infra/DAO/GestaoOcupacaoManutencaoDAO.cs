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
    public class GestaoOcupacaoManutencaoDAO : BaseDAO<GestaoOcupacaoManutencao>
    {
        private Logger _logger;
        public GestaoOcupacaoManutencaoDAO(DerContext context) : base(context)
        {
            _logger = new Logger("Gestão Ocupação Manutencao", context);
        }

        public void ExcluirPorIdOcupacao(int idOcupacao)
        //-- Description:	Deleta um Manutencao da Ocupação.
        {
            var oldValue = GetByOcupacaoId(idOcupacao);

            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            const string sql = @"delete from tab_gestao_ocupacao_Manutencao where ocu_id = @idOcupacao";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sql, new { idOcupacao = idOcupacao }, commandType: CommandType.Text).ToList();

                conexao.Close();
                // _logger.salvarLog(TipoAlteracao.Exclusao,oldValue.Id.ToString(), _logger.serializer.Serialize(oldValue) , "");
            }
        }

        public GestaoOcupacaoManutencaoViewModel GetByOcupacaoId(int idOcupacao)
        //-- Description:	Busca um Manutencao em Ocupações.
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var model = new GestaoOcupacaoManutencao();

        const string sql = @"select
                                [ocu_man_id] as id,
	                            [ocu_id] as GestaoOcupacaoId,
	                            [ocu_man_data_assinatura] as DataAssinatura,
	                            [ocu_man_data_aprovacao_regional] as DataAprovacaoRegional,
	                            [ocu_man_observacao] as Observacao,
	                            [ocu_man_caminho_arquivo] as DocumentoArquivo
                                from tab_gestao_ocupacao_Manutencao
                                where ocu_id = @idOcupacao";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                model = db.Query<GestaoOcupacaoManutencao>(sql, new { idOcupacao = idOcupacao }, commandType: CommandType.Text).FirstOrDefault();
            }
            if (model == null) return null;

            var retorno = new GestaoOcupacaoManutencaoViewModel();
            retorno.id = model.id;
            retorno.DataAssinatura = model.DataAssinatura.ToString("yyyy-MM-dd");
            retorno.DataAprovacaoRegional = model.DataAprovacaoRegional.ToString("yyyy-MM-dd");
            retorno.Observacao = model.Observacao;
            retorno.CaminhoArquivo = model.CaminhoArquivo;
            retorno.Arquivo = model.CaminhoArquivo;
            retorno.NomeArquivo = model.CaminhoArquivo;
            return retorno;
        }

        public void Inserir(GestaoOcupacaoManutencao domain)
        //-- Description:	Insere um novo Manutencao na Gestão de Ocupações
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;



            string sqlUpdate = @"INSERT INTO tab_gestao_ocupacao_Manutencao
                                VALUES( @ocu_id,
                                        @ocu_man_data_assinatura,
                                        @ocu_man_data_aprovacao_regional,
                                        @ocu_man_observacao,
                                        @ocu_man_caminho_arquivo
                                        )";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sqlUpdate, new
                {
                    ocu_id = domain.GestaoOcupacaoId,
                    ocu_man_data_assinatura = domain.DataAssinatura,
                    ocu_man_data_aprovacao_regional = domain.DataAprovacaoRegional,
                    ocu_man_observacao = domain.Observacao,
                    ocu_man_caminho_arquivo = domain.CaminhoArquivo

                }, commandType: CommandType.Text);

                _logger.salvarLog(TipoAlteracao.Criacao, "", "", _logger.serializer.Serialize(domain));
                conexao.Close();
            }
        }
    }
}