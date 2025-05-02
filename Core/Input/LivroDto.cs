using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Input
{
    public class LivroDto
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public required string Nome { get; set; }
        public required string Editora { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
    }
}
