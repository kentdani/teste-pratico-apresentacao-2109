using Microsoft.EntityFrameworkCore;
using Models;

namespace API.DataContexto
{
    public class Contexto_SQL : DbContext
    {
        public Contexto_SQL(DbContextOptions<Contexto_SQL> parametros) :base (parametros)
        {

        }

        public DbSet<Conteiner> Conteiner { get; set; }
        public DbSet<MovimentacaoCarga> MovimentacaoCarga { get; set; }
    }
}
