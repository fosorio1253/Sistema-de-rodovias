using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class DominioSubestacoesReservatoriosTiposBLL
    {
        private DerContext context;
        private DominioSubestacoesReservatoriosTiposDAO dominiosubestacoesreservatoriostiposDAO;

        public DominioSubestacoesReservatoriosTiposBLL()
        {
            context = new DerContext();
            dominiosubestacoesreservatoriostiposDAO = new DominioSubestacoesReservatoriosTiposDAO(context);
        }

        public bool Save(DominioSubestacoesReservatoriosTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.srt_id) ?
                    dominiosubestacoesreservatoriostiposDAO.Update(model) :
                    dominiosubestacoesreservatoriostiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(DominioSubestacoesReservatoriosTipos model)
        {
            try
            {
                return ExistsById(model.srt_id) ?
                    dominiosubestacoesreservatoriostiposDAO.Update(model) :
                    dominiosubestacoesreservatoriostiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioSubestacoesReservatoriosTiposViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioSubestacoesReservatoriosTiposViewModel>();
            }
        }

        public List<DominioSubestacoesReservatoriosTipos> Load()
        {
            try
            {
                return dominiosubestacoesreservatoriostiposDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioSubestacoesReservatoriosTipos>();
            }
        }

        public bool Remove(DominioSubestacoesReservatoriosTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.srt_id) ?
                    dominiosubestacoesreservatoriostiposDAO.Delete(model) : false;
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
                return Load().Any(x => x.srt_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioSubestacoesReservatoriosTiposViewModel> ToList(DominioSubestacoesReservatoriosTiposViewModel model, List<DominioSubestacoesReservatoriosTiposViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioSubestacoesReservatoriosTiposViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioSubestacoesReservatoriosTiposViewModel>();
            }
        }

        private DominioSubestacoesReservatoriosTipos ViewModelToModel(DominioSubestacoesReservatoriosTiposViewModel model)
        {
            try
            {
                var retorno = new DominioSubestacoesReservatoriosTipos();
                retorno.srt_id = model.srt_id;
                retorno.srt_descricao = model.srt_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioSubestacoesReservatoriosTipos();
            }
        }

        private DominioSubestacoesReservatoriosTiposViewModel ModelToViewModel(DominioSubestacoesReservatoriosTipos model)
        {
            try
            {
                var retorno = new DominioSubestacoesReservatoriosTiposViewModel();
                retorno.srt_id = model.srt_id;
                retorno.srt_descricao = model.srt_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioSubestacoesReservatoriosTiposViewModel();
            }
        }
    }

}