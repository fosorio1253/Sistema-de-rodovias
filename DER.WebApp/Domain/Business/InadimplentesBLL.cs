using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class InadimplentesBLL
    {
        private DerContext              context;
        private InadimplentesDAO        inadimplentesDAO;
        private GestaoInteressadoBLL    gestaoInteressadoBLL;
        private TipoOcupacaoBLL tipoOcupacaoBLL;

        public InadimplentesBLL()
        {
            context                 = new DerContext();
            inadimplentesDAO        = new InadimplentesDAO(context);
            gestaoInteressadoBLL    = new GestaoInteressadoBLL();
            tipoOcupacaoBLL = new TipoOcupacaoBLL();
        }

        public bool Save(InadimplentesTabelaViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.ina_interessadoid) ?
                    inadimplentesDAO.Update(model) :
                    inadimplentesDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<InadimplentesTabelaViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<InadimplentesTabelaViewModel>();
            }
        }

        public List<Inadimplentes> Load()
        {
            try
            {
                return inadimplentesDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<Inadimplentes>();
            }
        }

        public bool Remove(InadimplentesTabelaViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.ina_interessadoid) ?
                    inadimplentesDAO.Delete(model) : false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExistsById(int id)
        {
            try
            {
                return Load().Any(x => x.ina_interessadoid.Equals(id));
            }
            catch (Exception e)

            {
                return false;
            }
        }
        
        public List<InadimplentesTabelaViewModel> ToList(InadimplentesTabelaViewModel model, List<InadimplentesTabelaViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<InadimplentesTabelaViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<InadimplentesTabelaViewModel>();
            }
        }

        private Inadimplentes ViewModelToModel(InadimplentesTabelaViewModel model)
        {
            try
            {
                var retorno = new Inadimplentes();
                retorno.ina_id              = model.Id;
                retorno.ina_interessadoid   = gestaoInteressadoBLL.ObtemListaGestaoInteressados(0,0,0).Where(x => x.Interessado.Equals(model.NomeInteressado)).Select(x => x.Id).FirstOrDefault();
                retorno.ina_periodo         = model.Periodo;
                retorno.ina_protocolo       = Convert.ToInt32(String.Concat(model.Protocolo.Where(c => "0123456789".Contains(c))));
                retorno.ina_statusboleto    = model.StatusBoleto;
                retorno.ina_tipofaturamento = model.TipoFaturamento;
                retorno.ina_tipoocupacaoid = tipoOcupacaoBLL.LoadView().Where(x => x.nome.Equals(model.TipoOcupacao)).Select(x => x.tipo_ocupacao_id).FirstOrDefault();
                retorno.ina_valorprevisto   = model.ValorPrevisto;
                retorno.ina_valortotal      = model.ValorTotal;
                retorno.ina_cpfcnpj         = Convert.ToInt32(String.Concat(model.CpfCnjp.Where(c => "0123456789".Contains(c))));
                retorno.ina_dias            = Convert.ToInt32(String.Concat(model.Dias.Where(c => "0123456789".Contains(c))));
                retorno.ina_processo        = Convert.ToInt32(model.Processo);
                retorno.ina_datavenciemntoprimeiro  = model.DataVenciemntoPrimeiro;
                retorno.ina_datavenciemntosegundo   = model.DataVenciemntoSegundo;

                return retorno;
            }
            catch (Exception e)
            {
                return new Inadimplentes();
            }
        }

        private InadimplentesTabelaViewModel ModelToViewModel(Inadimplentes model)
        {
            try
            {
                var retorno = new InadimplentesTabelaViewModel();
                retorno.Id              = model.ina_id;
                retorno.NomeInteressado = gestaoInteressadoBLL.ObtemListaGestaoInteressados(0, 0, 0).Where(x => x.Id.Equals(model.ina_interessadoid)).Select(x => x.Interessado).FirstOrDefault();
                retorno.Periodo         = model.ina_periodo;
                retorno.Protocolo       = model.ina_protocolo.ToString();
                retorno.StatusBoleto    = model.ina_statusboleto;
                retorno.TipoFaturamento = model.ina_tipofaturamento;
                retorno.TipoOcupacao = tipoOcupacaoBLL.LoadView().Where(x => x.tipo_ocupacao_id.Equals(model.ina_tipoocupacaoid)).Select(x => x.nome).FirstOrDefault();
                retorno.ValorTotal      = model.ina_valortotal;
                retorno.CpfCnjp         = model.ina_cpfcnpj.ToString();
                retorno.Dias            = model.ina_dias.ToString();
                retorno.Processo        = model.ina_processo.ToString();
                retorno.DataVenciemntoPrimeiro  = model.ina_datavenciemntoprimeiro;
                retorno.DataVenciemntoSegundo   = model.ina_datavenciemntosegundo;

                return retorno;
            }
            catch (Exception e)
            {
                return new InadimplentesTabelaViewModel();
            }
        }
    }
}