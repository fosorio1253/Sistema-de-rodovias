using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.DTO;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using DER.WebApp.ViewModels.ProjetosMelhorias;
using DER.WebApp.ViewModels.Validadores;
using System;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class ProjetosMelhoriasBLL
    {
        private ProjetosMelhoriasDAO projetosMelhoriasDAO;
        private ProjetosMelhoriasInformacoesRelevantesDAO projetosMelhoriasInformacoesRelevantesDAO;


        private DerContext _context;

        public ProjetosMelhoriasBLL()
        {
            _context = new DerContext();           
            projetosMelhoriasDAO = new ProjetosMelhoriasDAO(_context);
            projetosMelhoriasInformacoesRelevantesDAO = new ProjetosMelhoriasInformacoesRelevantesDAO(_context);
        }

        public List<ListaProjetosMelhoriasDTO> ObtemListaProjetosMelhorias()
        {
            return projetosMelhoriasDAO.GetListProjetosMelhorias();
        }

        public ProjetosMelhoriasViewModel ObtemInfoId(int id)
        {
            var retorno = projetosMelhoriasDAO.GetById(id);
            
            retorno.Informacoes = new List<ProjetosMelhoriasInformacoesRelevantesViewModel>();
           
            retorno.Informacoes.AddRange(projetosMelhoriasInformacoesRelevantesDAO.GetByInformacoesRelevantesId(id));

            return retorno;
        }

        public ProjetosMelhorias ObtemId(int id)
        {
            return projetosMelhoriasDAO.Get(id);
        }

        public ProjetosMelhoriasValidatorViewModel Inserir(ProjetosMelhoriasViewModel viewModel)
        {
            try
            {
                var domain = new ProjetosMelhorias()
                {
                    Id = viewModel.Id,
                    RegionalId = viewModel.RegionalId,
                    MunicipioId = viewModel.MunicipioId,
                    RodoviaId = viewModel.RodoviaId,
                    Nome = viewModel.Nome,
                    KmInicial = viewModel.KmInicial,
                    KmFinal = viewModel.KmFinal,
                    Extensao = viewModel.Extensao,
                    Sentido = viewModel.Sentido,
                    LadoId = viewModel.LadoId,
                    Lote = viewModel.Lote,
                    Status = viewModel.Status,
                    NumeroContrato = viewModel.NumeroContrato,
                    Prazo = viewModel.Prazo,
                    PrevisaoInicio = viewModel.PrevisaoInicio,
                    Descricao = viewModel.Descricao,
                    UnidadeConservacao = viewModel.UnidadeConservacao
                };

                var idProjetos = 0;
                if (viewModel.Id != 0)
                {
                    idProjetos = projetosMelhoriasDAO.Atualizar(domain);
                    projetosMelhoriasInformacoesRelevantesDAO.ExcluirPorIdProjetos(idProjetos);
                }
                else
                {
                    idProjetos = projetosMelhoriasDAO.Inserir(domain);
                } 
                this.AddInformacoesRelevantes(viewModel.Informacoes, idProjetos);                

                return new ProjetosMelhoriasValidatorViewModel() { valid = true };
            }
            catch (Exception ex)
            {
                return new ProjetosMelhoriasValidatorViewModel() { valid = false };
            }
        }
        public void Excluir(int id)
        {
            projetosMelhoriasDAO.Excluir(id);          
        }

        public List<RetornoValidacaoTrechoProjetoViewModel> ValidacaoTrechoProjetoMelhoria(ValidacaoTrechoProjetoViewModel viewModel)
        {
            return projetosMelhoriasDAO.ValidacaoTrechoProjetoMelhoria(viewModel);
        }

        private void AddInformacoesRelevantes(List<ProjetosMelhoriasInformacoesRelevantesViewModel> informacoes, int idProjetos)
        {
            if (informacoes != null && informacoes.Count > 0)
            {
                foreach (var obs in informacoes)
                {
                    var informacao = new ProjetosMelhoriasInformacoesRelevantes()
                    {
                        ProjetosMelhoriasId = idProjetos,
                        DataAtualizacao = DateTime.Now,
                        Descricao = obs.Descricao,
                        AdicionadoPor = obs.AdicionadoPor
                    };

                    projetosMelhoriasInformacoesRelevantesDAO.Inserir(informacao);
                }
            }
        }     
    }
}