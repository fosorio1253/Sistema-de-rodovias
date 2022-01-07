using DER.WebApp.Domain.Models;
using DER.WebApp.Helper;
using DER.WebApp.Infra.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DER.WebApp.Infra.DAO
{
    public class ParametrosSistemaDAO : BaseDAO<ParametrosSistema>
    {
        Logger logger;

        public ParametrosSistemaDAO(DerContext context) : base(context)
        {
            logger = new Logger("Parametros Sistema", context);
        }

        public List<ParametrosSistema> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<ParametrosSistema>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_PARAMETROS_SISTEMA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new ParametrosSistema();
                            retorno.parametros_sistema_id               = result["parametros_sistema_id"]               is DBNull ? 0               : Convert.ToInt32(result["parametros_sistema_id"]);
                            retorno.area_nome                           = result["area_nome"]                           is DBNull ? string.Empty    : result["area_nome"].ToString();
                            retorno.lado_nome                           = result["lado_nome"]                           is DBNull ? string.Empty    : result["lado_nome"].ToString();
                            retorno.natureza_juridica_descricao         = result["natureza_juridica_descricao"]         is DBNull ? string.Empty    : result["natureza_juridica_descricao"].ToString();
                            retorno.ocorrencia_severidade_nome          = result["ocorrencia_severidade_nome"]          is DBNull ? string.Empty    : result["ocorrencia_severidade_nome"].ToString();
                            retorno.ocorrencia_status_nome              = result["ocorrencia_status_nome"]              is DBNull ? string.Empty    : result["ocorrencia_status_nome"].ToString();
                            retorno.ocorrencia_trecho_nome              = result["ocorrencia_trecho_nome"]              is DBNull ? string.Empty    : result["ocorrencia_trecho_nome"].ToString();
                            retorno.origem_da_solicitacao_nome          = result["origem_da_solicitacao_nome"]          is DBNull ? string.Empty    : result["origem_da_solicitacao_nome"].ToString();
                            retorno.situacao_ocupacao_nome              = result["situacao_ocupacao_nome"]              is DBNull ? string.Empty    : result["situacao_ocupacao_nome"].ToString();
                            retorno.situacao_solicitacao_nome           = result["situacao_solicitacao_nome"]           is DBNull ? string.Empty    : result["situacao_solicitacao_nome"].ToString();
                            retorno.tipo_documento_descricao            = result["tipo_documento_descricao"]            is DBNull ? string.Empty    : result["tipo_documento_descricao"].ToString();
                            retorno.tipo_documento_ocupao_descricao     = result["tipo_documento_ocupao_descricao"]     is DBNull ? string.Empty    : result["tipo_documento_ocupao_descricao"].ToString();
                            retorno.tipo_empresa_descricao              = result["tipo_empresa_descricao"]              is DBNull ? string.Empty    : result["tipo_empresa_descricao"].ToString();
                            retorno.tipo_implantacao_nome               = result["tipo_implantacao_nome"]               is DBNull ? string.Empty    : result["tipo_implantacao_nome"].ToString();
                            retorno.tipo_interferencia_nome             = result["tipo_interferencia_nome"]             is DBNull ? string.Empty    : result["tipo_interferencia_nome"].ToString();
                            retorno.tipo_passagem_nome                  = result["tipo_passagem_nome"]                  is DBNull ? string.Empty    : result["tipo_passagem_nome"].ToString();
                            
                            lretorno.Add(retorno);
                        }
                        conn.Close();
                    }
                }
                return lretorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Inserir(ParametrosSistema domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_PARAMETROS_SISTEMA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@parametros_sistema_id",               domain.parametros_sistema_id));
                        command.Parameters.Add(new SqlParameter("@area_nome",                           domain.area_nome));
                        command.Parameters.Add(new SqlParameter("@lado_nome",                           domain.lado_nome));
                        command.Parameters.Add(new SqlParameter("@natureza_juridica_descricao",         domain.natureza_juridica_descricao));
                        command.Parameters.Add(new SqlParameter("@ocorrencia_severidade_nome",          domain.ocorrencia_severidade_nome));
                        command.Parameters.Add(new SqlParameter("@ocorrencia_status_nome",              domain.ocorrencia_status_nome));
                        command.Parameters.Add(new SqlParameter("@ocorrencia_trecho_nome",              domain.ocorrencia_trecho_nome));
                        command.Parameters.Add(new SqlParameter("@origem_da_solicitacao_nome",          domain.origem_da_solicitacao_nome));
                        command.Parameters.Add(new SqlParameter("@situacao_ocupacao_nome",              domain.situacao_ocupacao_nome));
                        command.Parameters.Add(new SqlParameter("@situacao_solicitacao_nome",           domain.situacao_solicitacao_nome));
                        command.Parameters.Add(new SqlParameter("@tipo_documento_descricao",            domain.tipo_documento_descricao));
                        command.Parameters.Add(new SqlParameter("@tipo_documento_ocupao_descricao",     domain.tipo_documento_ocupao_descricao));
                        command.Parameters.Add(new SqlParameter("@tipo_empresa_descricao",              domain.tipo_empresa_descricao));
                        command.Parameters.Add(new SqlParameter("@tipo_implantacao_nome",               domain.tipo_implantacao_nome));
                        command.Parameters.Add(new SqlParameter("@tipo_interferencia_nome",             domain.tipo_interferencia_nome));
                        command.Parameters.Add(new SqlParameter("@tipo_passagem_nome",                  domain.tipo_passagem_nome));

                        var result = command.ExecuteScalar();

                        command.Parameters.Clear();
                        conn.Close();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(ParametrosSistema domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.parametros_sistema_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_PARAMETROS_SISTEMA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@parametros_sistema_id",               domain.parametros_sistema_id));
                        command.Parameters.Add(new SqlParameter("@area_nome",                           domain.area_nome));
                        command.Parameters.Add(new SqlParameter("@lado_nome",                           domain.lado_nome));
                        command.Parameters.Add(new SqlParameter("@natureza_juridica_descricao",         domain.natureza_juridica_descricao));
                        command.Parameters.Add(new SqlParameter("@ocorrencia_severidade_nome",          domain.ocorrencia_severidade_nome));
                        command.Parameters.Add(new SqlParameter("@ocorrencia_status_nome",              domain.ocorrencia_status_nome));
                        command.Parameters.Add(new SqlParameter("@ocorrencia_trecho_nome",              domain.ocorrencia_trecho_nome));
                        command.Parameters.Add(new SqlParameter("@origem_da_solicitacao_nome",          domain.origem_da_solicitacao_nome));
                        command.Parameters.Add(new SqlParameter("@situacao_ocupacao_nome",              domain.situacao_ocupacao_nome));
                        command.Parameters.Add(new SqlParameter("@situacao_solicitacao_nome",           domain.situacao_solicitacao_nome));
                        command.Parameters.Add(new SqlParameter("@tipo_documento_descricao",            domain.tipo_documento_descricao));
                        command.Parameters.Add(new SqlParameter("@tipo_documento_ocupao_descricao",     domain.tipo_documento_ocupao_descricao));
                        command.Parameters.Add(new SqlParameter("@tipo_empresa_descricao",              domain.tipo_empresa_descricao));
                        command.Parameters.Add(new SqlParameter("@tipo_implantacao_nome",               domain.tipo_implantacao_nome));
                        command.Parameters.Add(new SqlParameter("@tipo_interferencia_nome",             domain.tipo_interferencia_nome));
                        command.Parameters.Add(new SqlParameter("@tipo_passagem_nome",                  domain.tipo_passagem_nome));

                        var result = command.ExecuteNonQuery();

                        conn.Close();
                    }
                }
                var value = GetById(domain.parametros_sistema_id);
                if (!value.Equals(oldValue))
                    logger.salvarLog(TipoAlteracao.Edicao, domain.parametros_sistema_id.ToString(), logger.serializer.Serialize(oldValue), logger.serializer.Serialize(value));

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ParametrosSistema GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new ParametrosSistema();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_PARAMETROS_SISTEMA_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@parametros_sistema_id", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            retorno.parametros_sistema_id           = result["parametros_sistema_id"]               is DBNull ? 0               : Convert.ToInt32(result["parametros_sistema_id"]);
                            retorno.area_nome                       = result["area_nome"]                           is DBNull ? string.Empty    : result["area_nome"].ToString();
                            retorno.lado_nome                       = result["lado_nome"]                           is DBNull ? string.Empty    : result["lado_nome"].ToString();
                            retorno.natureza_juridica_descricao     = result["natureza_juridica_descricao"]         is DBNull ? string.Empty    : result["natureza_juridica_descricao"].ToString();
                            retorno.ocorrencia_severidade_nome      = result["ocorrencia_severidade_nome"]          is DBNull ? string.Empty    : result["ocorrencia_severidade_nome"].ToString();
                            retorno.ocorrencia_status_nome          = result["ocorrencia_status_nome"]              is DBNull ? string.Empty    : result["ocorrencia_status_nome"].ToString();
                            retorno.ocorrencia_trecho_nome          = result["ocorrencia_trecho_nome"]              is DBNull ? string.Empty    : result["ocorrencia_trecho_nome"].ToString();
                            retorno.origem_da_solicitacao_nome      = result["origem_da_solicitacao_nome"]          is DBNull ? string.Empty    : result["origem_da_solicitacao_nome"].ToString();
                            retorno.situacao_ocupacao_nome          = result["situacao_ocupacao_nome"]              is DBNull ? string.Empty    : result["situacao_ocupacao_nome"].ToString();
                            retorno.situacao_solicitacao_nome       = result["situacao_solicitacao_nome"]           is DBNull ? string.Empty    : result["situacao_solicitacao_nome"].ToString();
                            retorno.tipo_documento_descricao        = result["tipo_documento_descricao"]            is DBNull ? string.Empty    : result["tipo_documento_descricao"].ToString();
                            retorno.tipo_documento_ocupao_descricao = result["tipo_documento_ocupao_descricao"]     is DBNull ? string.Empty    : result["tipo_documento_ocupao_descricao"].ToString();
                            retorno.tipo_empresa_descricao          = result["tipo_empresa_descricao"]              is DBNull ? string.Empty    : result["tipo_empresa_descricao"].ToString();
                            retorno.tipo_implantacao_nome           = result["tipo_implantacao_nome"]               is DBNull ? string.Empty    : result["tipo_implantacao_nome"].ToString();
                            retorno.tipo_interferencia_nome         = result["tipo_interferencia_nome"]             is DBNull ? string.Empty    : result["tipo_interferencia_nome"].ToString();
                            retorno.tipo_passagem_nome              = result["tipo_passagem_nome"]                  is DBNull ? string.Empty    : result["tipo_passagem_nome"].ToString();
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

        public bool Delete(ParametrosSistema model)
        {
            var oldValue = GetById(model.parametros_sistema_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_PARAMETROS_SISTEMA", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@parametros_sistema_id", model.parametros_sistema_id));
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    conn.Close();
                    logger.salvarLog(TipoAlteracao.Exclusao, model.parametros_sistema_id.ToString(), logger.serializer.Serialize(oldValue), "");
                }
            }
            return true;
        }
    }
}