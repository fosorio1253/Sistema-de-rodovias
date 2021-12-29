using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class ResidenciaConservacoesBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public ResidenciaConservacoesBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<GestaoOcupacoesResidenciaConservacaoViewModel> ObtemResidenciaConservacoes()
        {
            var retorno = new List<GestaoOcupacoesResidenciaConservacaoViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.ResidenciaConservacao);

            foreach (var d in dominio)
            {
                retorno.Add(new GestaoOcupacoesResidenciaConservacaoViewModel() { ResidenciaConservacaoId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}