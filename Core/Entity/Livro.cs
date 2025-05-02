using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Livro : EntityBase
    {
        public required string Nome { get; set; }
        public required string Editora { get; set; }

        //livro vai ter varios pedidos
        public ICollection<Pedido> Pedidos { get; set; }

        public Livro()
        {
            DataCriacao = DateTime.Now;
        }

    }
}
