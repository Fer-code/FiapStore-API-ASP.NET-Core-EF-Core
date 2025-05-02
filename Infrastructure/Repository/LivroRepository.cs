using Core.Entity;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class LivroRepository : EFRepository<Livro>, ILivroRepository
    {
        public LivroRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void CadastrarEmMassa(IEnumerable<Livro> livros)
        {
            //_context.AddRange(livros);
            //_context.SaveChanges();

            //mais rapido:
            _context.BulkInsert(livros);
        }
    }
}
