using DER.WebApp.Domain.Business;
using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.DTO;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.Models;
using DER.WebApp.Models.Enum;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DER.WebApp.DAO
{
    public class ArquivoDAO : BaseDAO<Arquivo>
    {
        PermissaoBLL permissaoBLL;

        public ArquivoDAO(DerContext derContext) : base(derContext)
        {
            permissaoBLL = new PermissaoBLL();
        }

        //Salvar no Banco de Dados
        public void SalvarArquivo(Usuario usuario)
        {
            db.SaveChanges();
        }
        
        public List<Arquivo> GetByUsuarioId(int idUsuario)
        {
            //-- Description: Busca os Arquivos de um Usuário pelo ID.
            //PROC: [STP_SEL_ARQUIVO_USUARIO_ID]
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<Arquivo>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_ARQUIVO_USUARIO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            DateTime? VariavelDateNula = null;

                            var arquivosUsuario = new Arquivo();
                            arquivosUsuario.Id = result["Id"] is DBNull ? 0 : Convert.ToInt32(result["Id"]);
                            arquivosUsuario.ArquivoNome = (result["ArquivoNome"] == null ? string.Empty : result["ArquivoNome"].ToString());
                            arquivosUsuario.ArquivoExtensao = (result["Extensao"] == null ? string.Empty : result["Extensao"].ToString());
                            arquivosUsuario.TipoArquivo = result["TipoArquivo"] is 1 ? TipoArquivoEnum.Foto : TipoArquivoEnum.Procuracao;
                            arquivosUsuario.Documento = result["Documento"] is DBNull ? string.Empty : result["Documento"].ToString();
                            arquivosUsuario.TipoInteressado = result["TipoInteressado"] is TipoInteressado ? 0 : Convert.ToInt32(result["TipoInteressado"]);
                            arquivosUsuario.DataCadastro = result["DataCadastro"] != DBNull.Value ? Convert.ToDateTime(result["DataCadastro"]) : VariavelDateNula;
                            arquivosUsuario.DataAtualizacao = result["DataAtualizacao"] != DBNull.Value ? Convert.ToDateTime(result["DataAtualizacao"]) : VariavelDateNula;
                            arquivosUsuario.usu_id = result["UsuarioId"] is DBNull ? 0 : Convert.ToInt32(result["UsuarioId"]);

                            retorno.Add(arquivosUsuario);
                        }
                        conn.Close();
                    }
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(Arquivo arquivo)
        {
            db.Arquivo.Remove(arquivo);
            db.SaveChanges();
        }
    }
}