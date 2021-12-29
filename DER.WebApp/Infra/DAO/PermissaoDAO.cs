using DER.WebApp.Infra.DAL;
using DER.WebApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Infra.DAO
{
    public class PermissaoDAO : BaseDAO<Permissao>
    {
        public PermissaoDAO(DerContext context): base(context)
        {

        }
    }
}