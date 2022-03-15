using APICurso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace APICurso.Controllers
{
    [Route("api/LimiteCliente")]
    [ApiController]
    public class LimiteClienteController : ControllerBase
    {
        private readonly BDServicoContext bd;

        public LimiteClienteController()
        {
            bd = new BDServicoContext();
        }

        [HttpGet]
        public IEnumerable<LimiteCliente> Get() //Método lista todos os clientes
        {
            var clientes = bd.LimiteClientes.ToList();

            return clientes;
        }

        [HttpGet("{id}")]
        public double LimiteCredito(int id) //Método recebe o código do cliente e retorna seu limite de crédito
        {
            var cliente = bd.LimiteClientes.Find(id);
            var limiteCliente = cliente.ValorLimite;
            return limiteCliente;
        }

        [HttpPatch("{id}/decrementa/{valor}")]
        public void Decrementar(int id, double valor) //Método recebe o código do cliente e um valor e decrementa este valor do limite de crédito do cliente
        {
            var cliente = bd.LimiteClientes.Find(id);
            cliente.ValorLimite -= valor;

            bd.Entry(cliente).State = EntityState.Modified;
            bd.SaveChanges();
        }
    }
}
