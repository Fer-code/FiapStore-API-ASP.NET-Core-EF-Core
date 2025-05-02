using Core.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FiapStoreAPI.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class ClienteController
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }


        [HttpGet("pedidos-seis-meses/{id:int}")]
        public IActionResult ClienteEPedidosSeisMeses([FromRoute] int id)
        {
            try
            {
                return Ok(_clienteRepository.ObterPedidosSeisMeses(id));
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
