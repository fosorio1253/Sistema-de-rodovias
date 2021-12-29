using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.ProjetosMelhorias;
using System;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class RodoviaBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public RodoviaBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<RodoviaViewModel> ObtemRodovia()
        {
            var retorno = new List<RodoviaViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.Rodovia, "Rodovia");

            foreach (var d in dominio)
            {
                retorno.Add(new RodoviaViewModel() { RodoviaId = d.Id, Nome = d.Nome, rod_codigo = d.rod_codigo });
            }

            return retorno;
        }

        public List<RodoviaViewModel> ObterRodovias()
        {
            try
            {
                var retorno = new List<RodoviaViewModel>();

                foreach (var rodovia in dadosMestresDAO.ObterDominio<Rodovia>())
                {
                    var rodoviavm = new RodoviaViewModel();
                    foreach (var props in rodovia.GetType().GetProperties())
                        if (rodoviavm.GetType().GetProperty(props.Name).PropertyType.ToString().ToLower().Contains("datetime"))
                            rodoviavm.GetType().GetProperty(props.Name).SetValue(rodoviavm, (DateTime)Convert.ChangeType(props.GetValue(rodovia), typeof(DateTime)));
                        else if (rodoviavm.GetType().GetProperty(props.Name).PropertyType.ToString().ToLower().Contains("bool"))
                            rodoviavm.GetType().GetProperty(props.Name).SetValue(rodoviavm, (bool)Convert.ChangeType(props.GetValue(rodovia), typeof(bool)));
                        else if (rodoviavm.GetType().GetProperty(props.Name).PropertyType.ToString().ToLower().Contains("string"))
                            rodoviavm.GetType().GetProperty(props.Name).SetValue(rodoviavm, (string)Convert.ChangeType(props.GetValue(rodovia), typeof(string)));
                        else if (rodoviavm.GetType().GetProperty(props.Name).PropertyType.ToString().ToLower().Contains("double"))
                            rodoviavm.GetType().GetProperty(props.Name).SetValue(rodoviavm, (double)Convert.ChangeType(props.GetValue(rodovia), typeof(double)));
                        else
                            rodoviavm.GetType().GetProperty(props.Name).SetValue(rodoviavm, (int)Convert.ChangeType(props.GetValue(rodovia), typeof(int)));

                    retorno.Add(rodoviavm);
                }

                return retorno;
            }
            catch
            {
                return new List<RodoviaViewModel>();
            }
            
        }
    }
}