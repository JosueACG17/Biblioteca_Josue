using Biblioteca_ChanJosue.Models.Domain;

namespace Biblioteca_ChanJosue.Services.IServices
{
    public interface IUsuarioServices
    {
        public List<Usuario> ObtenerUsuario();
        public bool CrearUsuario(Usuario request);
        public Usuario GetUsuarioById(int id);
        public bool ActualizarUsuario(Usuario request);
        public bool EliminarUsuario(int id);
        public List<Rol> ObtenerRoles();


    }
}
