    using Biblioteca_ChanJosue.Context;
    using Biblioteca_ChanJosue.Models.Domain;
    using Biblioteca_ChanJosue.Services.IServices;
    using Microsoft.EntityFrameworkCore;

    namespace Biblioteca_ChanJosue.Services.Services
    {
        public class UsuarioServices : IUsuarioServices
        {
            private readonly ApplicationDbContext _context;
            public UsuarioServices(ApplicationDbContext context) 
            { 
                _context = context;
            }

            // Lo del lado izquierdo es lo que esperamos que se nos devuelva
            //Funcion para obtener la lista de Usuarios
            public List<Usuario> ObtenerUsuario ()
            {
                try
                {
                    List<Usuario> result = _context.Usuarios.Include(x => x.Roles).ToList(); //Aqui se manda a llamar la base de datos para obtener los datos
                    return result;
                }
                catch (Exception ex) 
                {
                    throw new Exception("Sucedio un error: " + ex.Message);
                }
            }

            public Usuario GetUsuarioById(int id)
            {
                try
                {
                    Usuario result = _context.Usuarios.Find(id);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("Sucedio un error : "+ex.Message);
            
                }
            }

        public bool CrearUsuario(Usuario request)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Nombre = request.Nombre,
                    Username = request.Username,
                    Password = request.Password,
                    FkRol = request.FkRol 
                };

                _context.Usuarios.Add(usuario);
                int result = _context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error : " + ex.Message);
            }
        }

        public bool ActualizarUsuario(Usuario request)
        {
            try
            {
                var usuario = _context.Usuarios.Find(request.PkUsuario);
                if (usuario != null)
                {
                    usuario.Nombre = request.Nombre;
                    usuario.Username = request.Username;
                    usuario.Password = request.Password;
                    usuario.FkRol = request.FkRol; 

                    _context.Usuarios.Update(usuario);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar: " + ex.Message);
            }
        }


        public bool EliminarUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return true;
        }


        public List<Rol> ObtenerRoles()
        {
            try
            {
                List<Rol> result = _context.Roles.ToList(); 
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }



    }
}
