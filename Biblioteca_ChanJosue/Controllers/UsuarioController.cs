using Biblioteca_ChanJosue.Models.Domain;
using Biblioteca_ChanJosue.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Biblioteca_ChanJosue.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;
        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        public IActionResult Index()
        {
            var result = _usuarioServices.ObtenerUsuario();
            return View(result);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            var roles = _usuarioServices.ObtenerRoles();
            ViewBag.Roles = new SelectList(roles, "PkRol", "Nombre"); 
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Usuario request)
        {
            _usuarioServices.CrearUsuario(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var result = _usuarioServices.GetUsuarioById(id);
            // Obtener la lista de roles y pasarla a la vista
            var roles = _usuarioServices.ObtenerRoles();
            ViewBag.Roles = new SelectList(roles, "PkRol", "Nombre", result.FkRol); 
            return View(result);
        }

        [HttpPost]
        public IActionResult Editar(Usuario request)
        {
            _usuarioServices.ActualizarUsuario(request);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            _usuarioServices.EliminarUsuario(id);
            return RedirectToAction("Index");
        }
    }
}