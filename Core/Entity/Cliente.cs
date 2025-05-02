using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Cliente : EntityBase
    {
        public required string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }

        public required string CPF { get; set; }
        //cliente vai ter varios pedidos
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
