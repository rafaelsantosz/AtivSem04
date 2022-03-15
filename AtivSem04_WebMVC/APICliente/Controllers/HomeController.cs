using APICliente.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace APICliente.Controllers
{
    public class HomeController : Controller
    {
        private readonly BDClienteContext bd;

        public HomeController()
        {
            bd = new BDClienteContext();
        }

        public IActionResult Index()
        {
            var vendas = bd.VendasClientes.ToList();
            return View(vendas);
        }
    }
}
