using PostSession.Data;
using PostSession.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostSession.Repositories
{
    public class RepositoryPokemon
    {
        private BaseDatosContext context;

        public RepositoryPokemon(BaseDatosContext context)
        {
            this.context = context;
        }

        public List<Pokemon> GetPokemon()
        {
            var consulta = from datos in this.context.Pokemons.AsEnumerable()
                           select datos;
            return consulta.ToList();
        }

        public Pokemon FindPokemon(int id)
        {
            return this.context.Pokemons.Where(x => x.NumeroPokedex == id).FirstOrDefault();
        }
    }
}
