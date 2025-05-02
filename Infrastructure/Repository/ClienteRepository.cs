using Core.Entity;
using Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Cliente ObterPedidosSeisMeses(int id)
        {
            var cliente = _context.Cliente
                .Include(c => c.Pedidos)
                .ThenInclude(p => p.Livro)
                .FirstOrDefault(c => c.Id == id)
                ?? throw new Exception("Esse cliente nao existe");

            //colocou o select por causa da dependencia ciclica entre models cliente e pedido
            cliente.Pedidos = cliente.Pedidos
                .Where(c => c.DataCriacao >= DateTime.Now.AddMonths(-6))
                .Select(p =>
                {
                    p.Cliente = null;
                    p.Livro.Pedidos = null;
                    return p;
                })
                .ToList();

            return cliente;
        }
    }
}
