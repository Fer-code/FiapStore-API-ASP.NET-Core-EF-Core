using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Pedido : EntityBase
    {
       public int ClienteId { get; set; }
       public int LivroId { get; set; }

        //Propriedades de navegação para FK
        public Cliente Cliente { get; set; }
        public Livro Livro { get; set; }
    }
}
