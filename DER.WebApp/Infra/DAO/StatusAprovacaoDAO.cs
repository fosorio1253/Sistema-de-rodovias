using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;

namespace DER.WebApp.Infra.DAO
{
    public class StatusAprovacaoDAO : BaseDAO<StatusAprovacao>
    {
        public StatusAprovacaoDAO(DerContext derContext) : base(derContext)
        {
        }
    }
}