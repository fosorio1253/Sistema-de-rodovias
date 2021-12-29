using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using System;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class ConfiguracaoSistemaBLL
    {
        private DerContext context;
        private ConfiguracoesSistemaDAO configuracoesSistemaDAO;

        public ConfiguracaoSistemaBLL()
        {
            context = new DerContext();
            configuracoesSistemaDAO = new ConfiguracoesSistemaDAO(context);
        }

        public bool GetProducao()
        {
            try
            {
                return configuracoesSistemaDAO.ObtemTodos().Any(x => x.Producao == true);
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}