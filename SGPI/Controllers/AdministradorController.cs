﻿using Microsoft.AspNetCore.Mvc;

namespace SGPI.Controllers
{
    public class AdministradorController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        //Agrego el de olvidar contraseña
        public IActionResult OlvidarContrasena()
        {
            return View();
        }
        //Agrego el de crear usuario
        public IActionResult CrearUsuario()
        {
            return View();
        }
        public IActionResult BuscarUsuario()
        {
            return View();
        }
        public IActionResult EliminarUsuario()
        {
            return View();
        }
        public IActionResult ModificarUsuario()
        {
            return View();
        }
        public IActionResult Reportes()
        {
            return View();
        }
    }
}
