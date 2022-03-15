using APICliente.Models;
using APICliente.WebAPI;
using Microsoft.AspNetCore.Mvc;

namespace APICliente.Controllers
{
    public class VendasClienteController : Controller
    {
        private readonly BDClienteContext bd;

        public VendasClienteController()
        {
            bd = new BDClienteContext();
        }

        public ActionResult Venda()
        {
            return View();
        }

        //Método realiza uma venda
        [HttpPost]
        public ActionResult Venda(VendasCliente venda) 
        {
            int codigoCliente = venda.CodigoCliente; 
            var valorVenda = venda.ValorVenda;

            double valorLimite = double.Parse(API.RequestGET(codigoCliente)); //Chama o método RequestGET para consultar o código do cliente, buscando o valor do limite de crédito na WebAPI

            if (valorVenda > valorLimite) //Se o valor da venda for maior que o valor limite
            {
                return RedirectToAction("ErroVenda"); //É redirecionado para uma tela de erro
            }
            else //Se o valor da venda for menor ou igual ao valor limite
            {
                bd.VendasClientes.Add(venda); //É cadastrado uma nova venda
                bd.SaveChanges();

                API.RequestPATCH(codigoCliente, valorVenda); //Chama o método RequestPATCH para avisar a WebAPI o valor da venda e decrementar do limite de crédito

                return RedirectToAction("VendaRealizada"); //É redirecionado para a tela de venda realizada
            }
        }

        public ActionResult ErroVenda()
        {
            return View();
        }

        public ActionResult VendaRealizada()
        {
            return View();
        }
    }
}
