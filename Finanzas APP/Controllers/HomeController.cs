using Finanzas_APP.Models;
using Finanzas_APP.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Finanzas_APP.Controllers
{
    public class HomeController : Controller
    {
        public readonly ICuentaRepositorio cuentaRepositorio;

        public HomeController(ICuentaRepositorio cuentaRepositorio)
        {
            this.cuentaRepositorio = cuentaRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CrearCuenta()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearCuenta(Cuenta cuenta) {
            if (ModelState.IsValid)
            {
                cuentaRepositorio.CrearCuenta(cuenta);
                return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}