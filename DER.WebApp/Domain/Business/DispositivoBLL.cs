using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.ProjetosMelhorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class DispositivoBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public DispositivoBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<DispositivoViewModel> ObtemDispositivo()
        {
            var retorno = new List<DispositivoViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.Dispositivo, "Dispositivo");

            foreach (var d in dominio)
            {
                retorno.Add(new DispositivoViewModel() { DispositivoId = d.Id, Nome = d.Nome, dis_codigo = d.dis_codigo });
            }

            return retorno;
        }
    }
}