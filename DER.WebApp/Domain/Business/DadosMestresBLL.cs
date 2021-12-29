using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.Domain.Models;
using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace DER.WebApp.Domain.Business
{
    public class DadosMestresBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public DadosMestresBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public DadosMestresRetornoViewModel EntToDadosMestres<T>(string retorno, string colId)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<List<T>>(retorno, new JsonSerializerSettings { ContractResolver = new NullToEmptyStringResolver()});
                var modelDadosMestres = new DadosMestresRetornoViewModel();
                modelDadosMestres.TabelaId = dadosMestresDAO.ObtemIdTabela(Activator.CreateInstance(typeof(T)).GetType().Name).ToString();
                modelDadosMestres.Valores = new List<DMValores>();

                foreach (var item in obj)
                {
                    var lValoresDadosMestres = new List<DMValores>();
                    foreach (var props in item.GetType().GetProperties())
                    {
                        try
                        {
                            var valoresDadosMestres = new DMValores();
                            var propid = dadosMestresDAO.ObtemIdColuna(props.Name, int.Parse(modelDadosMestres.TabelaId));
                            if (!propid.Equals(0))
                            {
                                var id = item.GetType().GetProperty(colId).GetValue(item).ToString();
                                var nid = dadosMestresDAO.ObtemIdValor(id, colId, int.Parse(modelDadosMestres.TabelaId));
                                valoresDadosMestres.id = nid;
                                valoresDadosMestres.colunaId = propid;
                                valoresDadosMestres.valor = props.GetValue(item) == null ? "" : props.GetValue(item).ToString();
                                lValoresDadosMestres.Add(valoresDadosMestres);
                            }
                        }
                        catch
                        {
                            //ignore
                        }
                    }
                    foreach(var vdm in lValoresDadosMestres)
                        modelDadosMestres.Valores.Add(vdm);
                }
                return modelDadosMestres;
            }
            catch
            {
                return new DadosMestresRetornoViewModel();
            }
        }

        public List<DadosMestresTabela> obtemTodasTabelas()
        {
            return dadosMestresDAO.GetAll().ToList();
        }

        public DadosMestresViewModels obtemTabela(string tabelaId)
        {
            var colunas = _context.DadosMestresColuna.Where(x => x.TabelaId == tabelaId).ToList();
            var valores = _context.DadosMestresValores.Where(x => x.Coluna.TabelaId == tabelaId).ToList();
            var tabela = _context.DadosMestresTabela.Find(tabelaId);
            var DadosMestres= new DadosMestresViewModels();
            DadosMestres.Tabela = new Dictionary<int, List<DMValores>>();
            DadosMestres.Colunas = new List<DMColunas>();
            DadosMestres.CodigoTabela = tabelaId;
            DadosMestres.NomeTabela = tabela.Nome;

            foreach (var coluna in colunas)
            {
                DadosMestres.Colunas.Add(new DMColunas() { idColuna = coluna.Id, NomeColuna = coluna.Nome, TipoDadoColuna = coluna.TipoDado});
            }

            foreach (var valor in valores)
            {
                if (DadosMestres.Tabela.ContainsKey(valor.Linha))
                {
                    DadosMestres.Tabela[valor.Linha].Add(new DMValores() { id = valor.Id, valor = valor.Valor, linha = valor.Linha, colunaId = valor.ColunaId });
                }
                else
                {
                    DadosMestres.Tabela.Add(valor.Linha, new List<DMValores>() { new DMValores() {id = valor.Id, valor = valor.Valor, linha = valor.Linha, colunaId = valor.ColunaId } });
                }
            }

            return DadosMestres;
        }

        public bool Salvar(DadosMestresRetornoViewModel dadosMestres)
        {
            try
            {
                var lDadosMestresValores = new List<DadosMestresValores>();

                var coluna = dadosMestres.Valores[0].colunaId;
                var linha = _context.DadosMestresValores.Where(x => x.ColunaId == coluna).Count();

                coluna = 0;
                foreach (var dados in dadosMestres.Valores)
                {
                    var dadosMestresValores = new DadosMestresValores();
                    if (dados.id == 0)
                    {
                        if (coluna.Equals(0))
                            coluna = dados.colunaId;
                        if (coluna.Equals(dados.colunaId))
                            linha++;
                        dadosMestresValores.ColunaId = dados.colunaId;
                        dadosMestresValores.Linha = linha;
                        dadosMestresValores.Valor = dados.valor == null ? ' '.ToString() : dados.valor;
                        lDadosMestresValores.Add(dadosMestresValores);
                    }
                    else
                    {
                        dadosMestresValores = _context.DadosMestresValores.Find(dados.id);
                        dadosMestresValores.Valor = dados.valor == null ? ' '.ToString() : dados.valor;
                        lDadosMestresValores.Add(dadosMestresValores);
                    }
                }

                foreach(var dmv in lDadosMestresValores)
                    _context.DadosMestresValores.Add(dmv);

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Excluir(string tabelaId, int id)
        {
            try
            {
                var dado = _context.DadosMestresValores.Find(id);
                var idColunas = _context.DadosMestresColuna.Where(x => x.TabelaId == tabelaId).Select(x => x.Id).ToList();
                
                var linhas =  _context.DadosMestresValores.Where(x => x.Linha == dado.Linha && idColunas.Contains(x.ColunaId));
                foreach(var linha in linhas)
                {
                    _context.Entry<DadosMestresValores>(linha).State = System.Data.Entity.EntityState.Deleted;
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string ObtemTipoOcupacao(int id)
        {
            var dm = dadosMestresDAO.ObtemTipoOcupacao(id);
            return dm == null ? "" : dm.Valor;
        }
    }

    public class NullToEmptyStringResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return type.GetProperties()
                    .Select(p => 
                    {
                        var jp = base.CreateProperty(p, memberSerialization);
                        jp.ValueProvider = new NullToEmptyStringValueProvider(p);
                        return jp;
                    }).ToList();
        }
    }
    public class NullToEmptyStringValueProvider : IValueProvider
    {
        PropertyInfo _MemberInfo;
        public NullToEmptyStringValueProvider(PropertyInfo memberInfo)
        {
            _MemberInfo = memberInfo;
        }

        public object GetValue(object target)
        {
            object result = _MemberInfo.GetValue(target);
            if (_MemberInfo.PropertyType == typeof(string) && result == null) result = "";
            return result;

        }

        public void SetValue(object target, object value)
        {
            _MemberInfo.SetValue(target, value);
        }
    }
}