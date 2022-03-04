using Microsoft.EntityFrameworkCore;
using PostSession.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostSession.Data
{
    public class BaseDatosContext : DbContext
    {
        public BaseDatosContext(DbContextOptions<BaseDatosContext> context) : base(context) { }

        public DbSet<Pokemon> Pokemons { get; set; }
    }
}
