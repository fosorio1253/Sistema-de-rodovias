using Dapper;
using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.ViewModels.GestaoInteressados;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DER.WebApp.Helper;

namespace DER.WebApp.Infra.DAO
{
    public class GestaoInteressadoEnderecoDAO : BaseDAO<GestaoInteressadoEndereco>
    {
        
        public GestaoInteressadoEnderecoDAO(DerContext context) : base(context)
        {
            
        }

        public void Inserir(GestaoInteressadoEndereco domain)
        //-- Description:	Insere um novo endereço em Gestão de Interessados.
        //PROC: [STP_INS_GESTAO_INTERESSADO_ENDERECO]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            string sqlUpdate = @"INSERT INTO tab_gestao_interessado_endereco
                                VALUES( @gestaoInteressadoId,
                                        @municipioId,
                                        @unidadeId,
                                        @logradouro,
                                        @cep,
                                        @numero,
                                        @complemento,
                                        @bairro,
                                        @nomeDoContato,
                                        @principal)";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sqlUpdate, new
                {
                    gestaoInteressadoId = domain.GestaoInteressadoId,
                    unidadeId = domain.UnidadeId,
                    logradouro = domain.Logradouro,
                    cep = domain.CEP,
                    numero = domain.Numero,
                    complemento = domain.Complemento,
                    bairro = domain.Bairro,
                    municipioId = domain.MunicipioId,
                    nomeDoContato = domain.NomeDoContato,
                    principal = domain.Principal,
                }, commandType: CommandType.Text);

                conexao.Close();
            }
            
        }

        public void ExcluirPorIdGestao(int idGestao)
        //-- Description:	Deleta um ENDERECO em Gestão de Interessado.
        //PROC: [STP_DEL_GESTAO_INTERESSADO_ENDERECO]
        {
            var oldValue = GetByGestaoId(idGestao);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            const string sql = @"delete from tab_gestao_interessado_endereco where int_id = @idGestao";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sql, new { idGestao = idGestao }, commandType: CommandType.Text).ToList();

                conexao.Close();
                
            }
        }

        public List<GestaoEnderecoViewModel> GetByGestaoId(int idGestao)
        //-- Description:	Busca um endereço em Gestão de Interessados.
        //PROC: [STP_SEL_GESTAO_INTERESSADO_ENDERECO_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<GestaoEnderecoViewModel>();

            const string sql = @"select 
                                    dmv_id_municipio as MunicipioId,
                                    dmv_id_unidade as EstadoId,
                                    int_end_logradouro as Logradouro,
                                    int_end_cep as CEP,
                                    int_end_numero as Numero,
                                    int_end_complemento as Complemento,
                                    int_end_bairro as Bairro,
                                    int_end_nome_contato as NomeContato
                                from tab_gestao_interessado_endereco
                                where int_id = @idGestao";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                retorno = conexao.Query<GestaoEnderecoViewModel>(sql, new { idGestao = idGestao }, commandType: CommandType.Text).ToList();
            }

            return retorno;
        }
    }
}



          