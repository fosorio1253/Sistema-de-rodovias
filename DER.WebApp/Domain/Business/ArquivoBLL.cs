using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.Domain.Models;
using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DER.WebApp.DAO;
using DER.WebApp.Models;
using DER.WebApp.Domain.Models.DTO;

namespace DER.WebApp.Domain.Business
{
    public class ArquivoBLL
    {
        private DerContext _context;
        private ArquivoDAO arquivoDAO;

        public ArquivoBLL()
        {
            _context = new DerContext();
            arquivoDAO = new ArquivoDAO(_context);
        }

        public List<Arquivo> obtemTodasTabelas()
        {
            return arquivoDAO.GetAll().ToList();
        }
        public Arquivo ObtemArquivo(int id)
        {
            var Arquivo = arquivoDAO.Get(id);
            
            return Arquivo;
        }

        public List<Arquivo> ObtemArquivoPorUsuarioId(int idUsuario)
        {
            return arquivoDAO.GetByUsuarioId(idUsuario);
        }

        public bool Salvar(DadosMestresRetornoViewModel dadosMestres)
        {
            var dadosMestresValores = new DadosMestresValores();
            if (dadosMestres.Valores[0].id == 0)
            {
                var idColuna = dadosMestres.Valores[0].colunaId;
                var coluna = _context.DadosMestresValores.Where(x => x.ColunaId == idColuna);
                var linha = 0;
                if (coluna.Count() > 0)
                    linha = coluna.Max(x => x.Linha);
                foreach (var dados in dadosMestres.Valores)
                {
                    dadosMestresValores = new DadosMestresValores();
                    dadosMestresValores.ColunaId = dados.colunaId;
                    dadosMestresValores.Linha = linha+1;
                    dadosMestresValores.Valor = dados.valor;
                    _context.DadosMestresValores.Add(dadosMestresValores);
                }
            }
            else
            {
                foreach(var dado in dadosMestres.Valores)
                {
                    dadosMestresValores = _context.DadosMestresValores.Find(dado.id);
                    dadosMestresValores.Valor = dado.valor;
                }
            }

            _context.SaveChanges();
            return true;
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
    }
}