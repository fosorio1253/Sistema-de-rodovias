using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using System.Linq;

namespace DER.WebApp.Infra.DAO
{
    public class GrupoDAO : BaseDAO<Grupo>
    {
        public GrupoDAO(DerContext derContext) : base(derContext)
        {

        }

        public Grupo ObtemPorNome(string nome, int idGrupo)
        {
            return (idGrupo == 0) ? db.Grupo.FirstOrDefault(x => x.Nome == nome) : db.Grupo.FirstOrDefault(x => x.Nome == nome && x.Id != idGrupo);
        }
    }
}