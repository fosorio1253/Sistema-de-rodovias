using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class DispositivoBLL
    {
        private DispositivosBLL dispositivosBLL;

        public DispositivoBLL()
        {
            dispositivosBLL = new DispositivosBLL();
        }

        public List<DispositivoViewModel> ObtemDispositivo()
        {
            return dispositivosBLL.LoadView();
        }
    }
}