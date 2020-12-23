using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Medicina.Models;

namespace Medicina.Controllers
{
    public class HomeController : Controller
    {

        private readonly EasyMedicineContext _context;

        public HomeController(EasyMedicineContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string Usuario, string Clave)
        {
            if (Usuario != null && Clave != null)
            {
                if (LoginValidar(Usuario, Clave))
                {
                    return Redirect("/Pacientes/Index");
                }
                ViewBag.validar = "Usuario o clave no valido";
            }
            return View();
        }


        public bool LoginValidar(string Usuario, string Clave)
        {
            var log = _context.Usuarios.Where(c => c.Nombre == Usuario).FirstOrDefault();

            var ClaveGeneral = "1234";

            if (log != null)
            {
                if (log.Nombre == Usuario && Clave == ClaveGeneral)
                {
                    return true;
                }
                return false;
            }
            else
                return false;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
