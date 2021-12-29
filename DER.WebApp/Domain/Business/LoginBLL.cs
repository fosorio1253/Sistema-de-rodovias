using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;

namespace DER.WebApp.Domain.Business
{
    public class LoginBLL
    {
        private UsuarioDAO usuarioDAO;

        public LoginBLL()
        {
            DerContext derContext = new DerContext();
            usuarioDAO = new UsuarioDAO(derContext);
        }

        public UsuarioViewModel ValidarLogin(UsuarioViewModel usuario)
        {
            return usuarioDAO.ValidarLogin(usuario);

        }
    }
}