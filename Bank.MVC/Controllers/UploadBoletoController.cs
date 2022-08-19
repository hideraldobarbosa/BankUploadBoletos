using Bank.Infra.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bank.MVC.Controllers
{
    public class UploadBoletoController : Controller
    {

        public IActionResult Index()
        {
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