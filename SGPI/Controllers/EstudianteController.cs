using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGPI.Models;

namespace SGPI.Controllers
{
    public class EstudianteController : Controller
    {
        SGPIBDContext context = new SGPIBDContext();
        public IActionResult EstudianteAct(int? IdUsuario)
        {
            Usuario usuario = context.Usuarios.Find(IdUsuario);

            if (usuario != null)
            {
                ViewBag.documento = context.Documentos.ToList();
                ViewBag.genero = context.Generos.ToList();
                ViewBag.programa = context.Programas.ToList();
               // 
                return View(usuario);
            }
            else
            {
                return Redirect("/Estudiante/EstudianteAct/?Idusuario=");
            }
        }
        
        [HttpPost]
        public IActionResult EstudianteAct(Usuario usuario)
        {
            var usuarioActualizar = context.Usuarios.Where(consulta => consulta.Idusuario == usuario.Idusuario).FirstOrDefault();

            //Usuario usuarioActualizar = context.Usuarios.Find(usuario);
            usuarioActualizar.NumeroDocumento = usuario.NumeroDocumento;
            usuarioActualizar.PrimerNombre = usuario.PrimerNombre;
            usuarioActualizar.SegundoNombre = usuario.SegundoNombre;
            usuarioActualizar.PrimerApellido = usuario.PrimerApellido;
            usuarioActualizar.SegundoApellido = usuario.SegundoApellido;
            usuarioActualizar.Idprograma = usuario.Idprograma;
            usuarioActualizar.Idgenero = usuario.Idgenero;
            usuarioActualizar.Password = usuario.Password;
            //usuario.Idrol = 3;
            ViewBag.mensaje = "Estudiante Actualizado";
            context.Update(usuarioActualizar);
            context.SaveChanges();
            ViewBag.documento = context.Documentos.ToList();
            ViewBag.genero = context.Generos.ToList();
            ViewBag.programa = context.Programas.ToList();
            return View(usuarioActualizar);
        }

        public IActionResult EstudiantePagos(int? Idusuario)
        {
            Usuario usuario = new Usuario();
            var usr = context.Usuarios.Where(consulta => consulta.Idusuario == Idusuario).FirstOrDefault();
            ViewBag.Idusuario = usr.Idusuario;
            return View();
        }

        [HttpPost]
        public IActionResult EstudiantePagos(int? Idusuario, Pago usuario)
        {
            Usuario usr = context.Usuarios.Find(Idusuario);

            usuario.Estado = true;
            context.Pagos.Add(usuario);
            context.SaveChanges();
            ViewBag.mensaje = "Pago Ingresado";

            Estudiante est = new Estudiante();
            est.Archivo = "";
            est.Idusuario = usr.Idusuario;
            est.Idpago = usuario.Idpago;
            est.Egresado = true;
            //est.Archivo = null;
            //est.Idusuario = (int)user.Idusuario;
            //est.Idpago = usr.Idpago;


            //usr.Estado = true;
            //ViewBag.mensaje = "Pago Ingresado";
            context.Estudiantes.Add(est);
            context.SaveChanges();
            return View();
        }

        
       
    }
}
