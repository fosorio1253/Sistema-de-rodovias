using Dapper;
using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.DTO;
using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DER.WebApp.Infra.DAO
{
    public class DadosMestresDAO : BaseDAO<DadosMestresTabela>
    {
        public DadosMestresDAO(DerContext context) : base(context)
        {

        }

        public List<ListaDominioGenericaDTO> ObtemDominio(int enumInt, string colunaRetorno = null)
        {
            var retorno = new List<ListaDominioGenericaDTO>();

            var tabela = db.Set<DadosMestresTabela>().FirstOrDefault(c => c.NumeroCodigo == enumInt);

            if (tabela == null)
            {
                return retorno;
            }

            var coluna = db.Set<DadosMestresColuna>().FirstOrDefault(x => x.TabelaId.Equals(tabela.Codigo) 
            && (x.Nome.Equals("Descrição") 
            || x.Nome.Equals("Nome") 
            || x.Nome.Equals("Sigla")
            || x.Nome.Equals("Fator Regional")
            || x.Nome.Equals("AlturaMinima")
            || x.Nome.Equals("ProfundidadeMinima")
            || x.Nome.Equals("rod_codigo")
            || x.Nome.Equals("Documentos")
            || x.Nome.Equals(colunaRetorno)));

            if (coluna == null)
            {
                return retorno;
            }

            var valores = db.Set<DadosMestresValores>().Where(x => x.ColunaId == coluna.Id).ToList();

            foreach (var valor in valores)
            {
                retorno.Add(new ListaDominioGenericaDTO()
                {
                    Id = valor.Id,
                    Nome = valor.Valor
                });
            }

            return retorno;
        }

        public List<ListaDominioGenericaDTO> ObtemDominioTipoConcessao(int enumInt, string colunaRetorno = null)
        {
            //REFATORAR essa situação para o metodo ObtemDominio, deixando a consultado de multiplacas 
            //colunas dinamica dinâmicamente
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<ListaDominioGenericaDTO>();

            const string sql = @"SELECT valor.dmv_id as Id, valor.dmv_linha, valor.dmv_valor as Nome, 
		                                documentos.dmv_valor as Documentos, 
		                                profundidadeMinima.dmv_valor as ProfundidadeMinima,
		                                alturaMinima.dmv_valor as AlturaMinima
                                FROM tab_dadosMestres_val as valor
                                LEFT JOIN tab_dadosMestres_val as documentos ON valor.dmv_linha=documentos.dmv_linha AND documentos.col_id=489
                                LEFT JOIN tab_dadosMestres_val as profundidadeMinima ON valor.dmv_linha=profundidadeMinima.dmv_linha AND profundidadeMinima.col_id=490
                                LEFT JOIN tab_dadosMestres_val as alturaMinima ON valor.dmv_linha=alturaMinima.dmv_linha AND alturaMinima.col_id=491
                                WHERE valor.col_id=30";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                retorno = conexao.Query<ListaDominioGenericaDTO>(sql, new { }, commandType: CommandType.Text).ToList();
            }

            return retorno;
        }

        public List<ListaDominioGenericaDTO> ObtemDominioTipoOcupacao(int enumInt, string colunaRetorno = null)
        {
            //REFATORAR essa situação para o metodo ObtemDominio, deixando a consultado de multiplacas 
            //colunas dinamica dinâmicamente
            var retorno = new List<ListaDominioGenericaDTO>();
            var tabela = db.Set<DadosMestresTabela>().FirstOrDefault(c => c.NumeroCodigo == enumInt);

            if (tabela == null)
            {
                return retorno;
            }

            var colunas = db.Set<DadosMestresColuna>().Where(x => x.TabelaId.Equals(tabela.Codigo)
            && x.Nome.Equals("Nome")
            || x.Nome.Equals("AlturaMinima")
            || x.Nome.Equals("ProfundidadeMinima")).ToList();

            if (colunas == null) {
                return retorno;
            }

            foreach (var coluna in colunas) {
                int i = 0;
                var valores = db.Set<DadosMestresValores>().Where(x => x.ColunaId == coluna.Id).ToList();

                foreach (var valor in valores) {
                    var listaDominioGenericaDTO = retorno.Count==valores.Count ? retorno[i] : new ListaDominioGenericaDTO();
                    if (coluna.Nome == "Nome") {
                        listaDominioGenericaDTO.Id = valor.Id;
                        listaDominioGenericaDTO.Nome = valor.Valor;
                    } else if (coluna.Nome == "AlturaMinima") {
                        listaDominioGenericaDTO.AlturaMinima = Double.Parse(valor.Valor);
                    } else if (coluna.Nome == "ProfundidadeMinima") {
                        listaDominioGenericaDTO.ProfundidadeMinima = Double.Parse(valor.Valor);
                    }

                    if (retorno.Count == valores.Count) { 
                        retorno[i] = listaDominioGenericaDTO;
                    } else {
                        retorno.Add(listaDominioGenericaDTO);
                    }
                    i++;
                }
            }
            return retorno;
        }


        public List<T> ObterDominio<T>()
        {
            var retorno = new List<T>();
            try
            {
                var nomeTipo = Activator.CreateInstance(typeof(T)).GetType().Name.ToString();
                var tabela = db.Set<DadosMestresTabela>().Where(x => x.Nome.Equals(nomeTipo)).FirstOrDefault();

                if (tabela != null)
                {
                    var colunas = db.Set<DadosMestresColuna>().Where(x => x.TabelaId.Equals(tabela.Codigo)).ToList();

                    if (colunas != null)
                    {
                        var lval = new List<DadosMestresValores>();

                        foreach (var col in colunas)
                            foreach (var val in db.Set<DadosMestresValores>().Where(x => x.ColunaId == col.Id).ToList())
                                lval.Add(val);
                        
                        if (lval.Count > 0)
                        {
                            int aLin = 0;
                            var obj = Activator.CreateInstance(typeof(T));
                            var colnom = string.Empty;
                            var colval = string.Empty;
                            lval = lval.OrderBy(x => x.Linha).ToList();
                            for (int i = 0; i <= lval.Count-1; i++)
                            {
                                if (aLin.Equals(0))
                                    aLin = lval[i].Linha;

                                colnom = lval[i].Coluna.Nome;
                                colval = lval[i].Valor;
                                var teste = obj.GetType().GetProperty(colnom).PropertyType.ToString().ToLower();
                                if (obj.GetType().GetProperty(colnom).PropertyType.ToString().ToLower().Contains("datetime"))
                                    obj.GetType().GetProperty(colnom).SetValue(obj, (DateTime)Convert.ChangeType(colval, typeof(DateTime)));
                                else if (obj.GetType().GetProperty(colnom).PropertyType.ToString().ToLower().Contains("bool"))
                                    obj.GetType().GetProperty(colnom).SetValue(obj, (bool)Convert.ChangeType(colval, typeof(bool)));
                                else if (obj.GetType().GetProperty(colnom).PropertyType.ToString().ToLower().Contains("string"))
                                    obj.GetType().GetProperty(colnom).SetValue(obj, (string)Convert.ChangeType(colval, typeof(string)));
                                else if (obj.GetType().GetProperty(colnom).PropertyType.ToString().ToLower().Contains("double"))
                                    obj.GetType().GetProperty(colnom).SetValue(obj, (double)Convert.ChangeType(colval, typeof(double)));
                                else
                                    obj.GetType().GetProperty(colnom).SetValue(obj, (int)Convert.ChangeType(colval, typeof(int)));

                                if (!i.Equals(lval.Count-1))
                                {
                                    if (!aLin.Equals(lval[i + 1].Linha))
                                    {
                                        retorno.Add((T)obj);
                                        obj = Activator.CreateInstance(typeof(T));
                                        aLin = lval[i + 1].Linha;
                                    }
                                }
                                else
                                    retorno.Add((T)obj);
                            }
                        }
                    }
                }
                return retorno;
            }
            catch(Exception e)
            {
                var a = e;
                return retorno;
            }
        }


        public int ObtemIdTabela(string tabNome)
        {
            var tab = db.Set<DadosMestresTabela>().Where(x => x.Nome.Equals(tabNome)).FirstOrDefault();
            if (tab != null)
                return tab.NumeroCodigo;
            return 0;
        }

        public int ObtemIdColuna(string colNome, int tabId)
        {
            var col = db.Set<DadosMestresColuna>().Where(x => x.Nome.Equals(colNome) && x.Tabela.NumeroCodigo.Equals(tabId)).FirstOrDefault();
            if (col != null)
                return col.Id;
            return 0;
        }

        public int ObtemIdValor(string id, string colNome, int tabId)
        {
            var a = ObtemIdColuna(colNome, tabId);
            var valLin = db.Set<DadosMestresValores>().Where(x => x.ColunaId.Equals(a) && x.Valor.Equals(id)).FirstOrDefault();
            if(valLin != null)
            {
                var colid = ObtemIdColuna(colNome, tabId);
                var val = db.Set<DadosMestresValores>().Where(x => x.ColunaId.Equals(colid) && x.Linha.Equals(valLin.Linha)).FirstOrDefault();
                if (val != null)
                    return val.Id;
            }
            return 0;
        }

        public DadosMestresValores ObtemValorById(int id)
        {
            var dmv = db.Set<DadosMestresValores>().Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (dmv != null)
                return dmv;
            return null;
        }

        public decimal ObterUFESP(bool FatorRem = false)
        {
            decimal ufesp = 0;
            if(FatorRem)
                decimal.TryParse(db.Set<DadosMestresValores>().Where(x => x.ColunaId.Equals(22)).Select(x => x.Valor).FirstOrDefault(), out ufesp);
            else
                decimal.TryParse(db.Set<DadosMestresValores>().Where(x => x.ColunaId.Equals(23)).Select(x => x.Valor).FirstOrDefault(), out ufesp);

            return ufesp;
        }

        public string ObterUF(int id)
        {
            return db.Set<DadosMestresValores>().Where(x => x.ColunaId.Equals(24) && x.Id.Equals(id)).Select(x => x.Valor).FirstOrDefault() ?? string.Empty;
        }

        public string ObterMunicipio(int id)
        {
            return db.Set<DadosMestresValores>().Where(x => x.ColunaId.Equals(9) && x.Id.Equals(id)).Select(x => x.Valor).FirstOrDefault() ?? string.Empty;
        }

        public decimal ObterIGP()
        {
            DateTime data;
            DateTime ndata = DateTime.MinValue;
            int lin = 0;
            db.Set<DadosMestresValores>().Where(x => x.ColunaId.Equals(6)).ToList().ForEach(x =>
            {
                if (DateTime.TryParse(x.Valor, out data))
                    if (data > ndata)
                    {
                        ndata = data;
                        lin = x.Linha;
                    }
            });

            if (lin > 0)
                return Convert.ToDecimal(db.Set<DadosMestresValores>().Where(x => x.ColunaId.Equals(7) && x.Linha.Equals(lin)).Select(x => x.Valor).FirstOrDefault());
            
            return 0;
        }

        public DadosMestresValores ObtemTipoOcupacao(int id)
        {
            var dmv = db.Set<DadosMestresValores>().Where(x => x.ColunaId.Equals(16) && x.Id.Equals(id)).FirstOrDefault();
            if (dmv != null)
                return dmv;
            var dmvn = new DadosMestresValores();
            dmvn.Valor = "Valor não registrado";
            return dmvn;
        }

        public DadosMestresValores ObtemTipoOcupacaoByName(string name)
        {
            var dmv = db.Set<DadosMestresValores>().Where(x => x.ColunaId.Equals(16) && x.Valor.Equals(name)).FirstOrDefault();
            if (dmv != null)
                return dmv;
            var dmvn = new DadosMestresValores();
            dmvn.Id = 0;
            return dmvn;
        }
    }
}
