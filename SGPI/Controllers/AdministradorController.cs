using Microsoft.AspNetCore.Mvc;
using SGPI.Models;
using SGPI.Controllers;
using System.Security.Cryptography.X509Certificates;

namespace SGPI.Controllers
{
    public class AdministradorController : Controller
    {
        SGPIBDContext context = new SGPIBDContext();
        public IActionResult Login()
        {
            //create
            /* Usuario user=new Usuario();
             user.PrimerNombre = "Sara";
             user.SegundoNombre = String.Empty;
             user.PrimerApellido = "Jaramillo";
             user.SegundoApellido = "Florez";
             user.Email = "Sarajaramillo_@hotmail.com";
             user.Iddoc = 1;
             user.Idgenero = 1;
             user.Idrol = 1;
             user.Idprograma= 1;
             user.NumeroDocumento = "1017238";
             user.Password = "12345678";

             context.Add(user);   
             context.SaveChanges();


             //Query
             Usuario usuario = new Usuario();

             usuario = context.Usuarios
                 .Single(b => b.NumeroDocumento == "1017238");

             List<Usuario> usuarios = new List<Usuario>();
             usuarios=context.Usuarios.ToList();

             //Update

             var usr = context.Usuarios
                     .Where(cursor => cursor.Idusuario == 1).FirstOrDefault();
             //Aca es donde hacemos las modificaciones
             if (usr != null)
             {
                 usr.SegundoNombre = "Sara";
                 usr.SegundoApellido = "Jaramillo";
                 //El context es el mensajero
                 context.Usuarios.Update(usr);
                 //Luego de que actualice, debe guardar los datos
                 context.SaveChanges();
             }

             //Delete
             //Primero seleccionamos el usuario, donde es == 1, es el ID
             var usuarioEliminar = context.Usuarios
                 .Where(cursor => cursor.Idusuario == 1).FirstOrDefault();
             //Aca llamo el context para eliminar}
             if (usuarioEliminar != null)
             {
                 context.Usuarios.Remove(usuarioEliminar);
             }*/

            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario user)
        {
            string numeroDoc = user.NumeroDocumento;
            string pass = user.Password;

            var usuarioLogin = context.Usuarios
                .Where(consulta => consulta.NumeroDocumento == numeroDoc &&
                consulta.Password == pass).FirstOrDefault();

            //Si usuario es diferente a null haga lo siguiente
            if (usuarioLogin != null)
            {
                //Dependiendo del rol del usuario, se le muestra la vista
                //Vista de administrador
                if (usuarioLogin.Idrol == 1)
                {
                    CrearUsuario();
                    //Si es rol 1, que muestre formulario crear usuario
                    return Redirect("/Administrador/CrearUsuario");
                }

                //Vista de coordinador
                else if (usuarioLogin.Idrol == 2)
                {
                    CoordinadorController Coor = new CoordinadorController();
                    Coor.BuscarCoordinador();
                    //Aca se hace con redirect, ya que no esta en este controller
                    return Redirect("/Coordinador/BuscarCoordinador");
                }
                //Vista de estudiante
                else if (usuarioLogin.Idrol == 3)
                {
                    EstudianteController Est = new EstudianteController();
                    return Redirect("/Estudiante/EstudianteAct/?Idusuario="+usuarioLogin.Idusuario);
                }
            }
            else
            {
                //Aca le decimos que retorne ese mensaje en la vista
                ViewBag.mensaje = "Usuario no existe " +
                     "o usuario y/o contraseña invalida";

            }
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
            ViewBag.genero = context.Generos.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.documento = context.Documentos.ToList();
            ViewBag.Programa = context.Programas.ToList();


            return View();
        }
        [HttpPost]
        public IActionResult CrearUsuario(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
            context.SaveChanges();

            ViewBag.mensaje = "Usuario creado exitosamente";

            ViewBag.genero = context.Generos.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.documento = context.Documentos.ToList();
            ViewBag.Programa = context.Programas.ToList();

            return View();
        }
        public IActionResult BuscarUsuario()
        {

            Usuario us = new Usuario();
            return View(us);
        }
        [HttpPost]
        public IActionResult BuscarUsuario(Usuario usuario)
        {
            String numeroDoc = usuario.NumeroDocumento;
            var user = context.Usuarios.Where(consulta => consulta.NumeroDocumento == numeroDoc).FirstOrDefault();
            if (user != null)
            {
                return View(user);
            }
            else

            return View();

        }
      
        public IActionResult ModificarUsuario(int? Idusuario)
        {
            Usuario usuario = context.Usuarios.Find(Idusuario);

            if (usuario != null)
            {
                ViewBag.genero = context.Generos.ToList();
                ViewBag.rol = context.Rols.ToList();
                ViewBag.documento = context.Documentos.ToList();
                ViewBag.Programa = context.Programas.ToList();

                return View(usuario);
            }
            else
            {
                return Redirect("/Administador/BuscarUsuario");
            }
        }        

        [HttpPost]
        public IActionResult ModificarUsuario(Usuario usuario)
        {
            context.Update(usuario);
            context.SaveChanges();

            ViewBag.mensaje = "Usuario modificado exitosamente";

            ViewBag.genero = context.Generos.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.documento = context.Documentos.ToList();
            ViewBag.Programa = context.Programas.ToList();


            return View(usuario);

        }
        public IActionResult EliminarUsuario()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EliminarUsuario(Usuario usuario)
        {
            
         
               context.Remove(usuario);
                context.SaveChanges();
            
            return Redirect("/Administrador/BuscarUsuario");
        }

        public IActionResult Reportes()
        {
            
            ViewBag.documento = context.Documentos.ToList();
            
            return View();
        }
        [HttpPost]
        public IActionResult Reportes(Usuario usuario)
        {
            String numeroDoc = usuario.NumeroDocumento;
            var user = context.Usuarios.Where(consulta => consulta.NumeroDocumento == numeroDoc).FirstOrDefault();
            if (user != null)
            {
                return View(user);
            }
            else

                return View();

        }
    }
}

