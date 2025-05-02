using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface ILivroRepository : IRepository<Livro>
    {
        //IENumerable pode deixar programa mais rapido
        void CadastrarEmMassa(IEnumerable<Livro> livros);
    }
}
