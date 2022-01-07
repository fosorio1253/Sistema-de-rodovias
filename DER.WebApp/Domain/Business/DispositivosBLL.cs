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
    public class DispositivosBLL
    {
        private DerContext context;
        private DispositivoDAO dispositivoDAO;

        public DispositivosBLL()
        {
            context = new DerContext();
            dispositivoDAO = new DispositivoDAO(context);
        }

        public bool Save(DispositivoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.dis_id) ?
                    dispositivoDAO.Update(model) :
                    dispositivoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DispositivoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DispositivoViewModel>();
            }
        }

        public List<Dispositivo> Load()
        {
            try
            {
                return dispositivoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<Dispositivo>();
            }
        }

        public bool Remove(DispositivoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.dis_id) ?
                    dispositivoDAO.Delete(model) : false;
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
                return Load().Any(x => x.dis_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DispositivoViewModel> ToList(DispositivoViewModel model, List<DispositivoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DispositivoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DispositivoViewModel>();
            }
        }

        private Dispositivo ViewModelToModel(DispositivoViewModel model)
        {
            try
            {
                var retorno = new Dispositivo();
                retorno.dis_id = model.dis_id;
                retorno.rod_id = model.rod_id;
                retorno.dis_codigo = model.dis_codigo;
                retorno.dit_id = model.dit_id;
                retorno.dis_km_localizacao = model.dis_km_localizacao;
                retorno.dis_extensao = model.dis_extensao;
                retorno.dis_descricao1 = model.dis_descricao1;
                retorno.dis_descricao2 = model.dis_descricao2;
                retorno.mun_ibge_id = model.mun_ibge_id;
                retorno.jur_id = model.jur_id;
                retorno.adm_id = model.adm_id;
                retorno.con_id = model.con_id;
                retorno.stp_id = model.stp_id;
                retorno.dis_perimetro_urbano = model.dis_perimetro_urbano;
                retorno.dis_denominacao = model.dis_denominacao;
                retorno.dis_legislacao = model.dis_legislacao;
                retorno.dis_TPUso = model.dis_TPUso;
                retorno.dis_transf_mun = model.dis_transf_mun;
                retorno.dis_observacao = model.dis_observacao;
                retorno.dis_subtrecho = model.dis_subtrecho;
                retorno.dis_ano_implantacao = model.dis_ano_implantacao;
                retorno.dis_data_atualizacao = model.dis_data_atualizacao;
                retorno.nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new Dispositivo();
            }
        }

        private DispositivoViewModel ModelToViewModel(Dispositivo model)
        {
            try
            {
                var retorno = new DispositivoViewModel();
                retorno.dis_id = model.dis_id;
                retorno.rod_id = model.rod_id;
                retorno.dis_codigo = model.dis_codigo;
                retorno.dit_id = model.dit_id;
                retorno.dis_km_localizacao = model.dis_km_localizacao;
                retorno.dis_extensao = model.dis_extensao;
                retorno.dis_descricao1 = model.dis_descricao1;
                retorno.dis_descricao2 = model.dis_descricao2;
                retorno.mun_ibge_id = model.mun_ibge_id;
                retorno.jur_id = model.jur_id;
                retorno.adm_id = model.adm_id;
                retorno.con_id = model.con_id;
                retorno.stp_id = model.stp_id;
                retorno.dis_perimetro_urbano = model.dis_perimetro_urbano;
                retorno.dis_denominacao = model.dis_denominacao;
                retorno.dis_legislacao = model.dis_legislacao;
                retorno.dis_TPUso = model.dis_TPUso;
                retorno.dis_transf_mun = model.dis_transf_mun;
                retorno.dis_observacao = model.dis_observacao;
                retorno.dis_subtrecho = model.dis_subtrecho;
                retorno.dis_ano_implantacao = model.dis_ano_implantacao;
                retorno.dis_data_atualizacao = model.dis_data_atualizacao;
                retorno.nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new DispositivoViewModel();
            }
        }
    }

}