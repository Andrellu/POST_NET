using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostSession.Extensions;
using PostSession.Models;
using PostSession.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostSession.Controllers
{
    public class PokemonController : Controller
    {
        private RepositoryPokemon repo;

        public PokemonController(RepositoryPokemon repo)
        {
            this.repo = repo;
        }

        public IActionResult ListPokemon()
        {
            List<Pokemon> listPokemon = this.repo.GetPokemon();
            return View(listPokemon);
        }

        public IActionResult AñadirCarrito(int id)
        {
            List<int> pokemon;
            if (HttpContext.Session.GetString("SESSION") == null)
            {
                //No existe nada en la session, creamos la coleccion
                pokemon = new List<int>();
            }
            else
            {
                pokemon = HttpContext.Session.GetObject<List<int>>("SESSION");
            }
            pokemon.Add(id);
            HttpContext.Session.SetObject("SESSION", pokemon);
            return RedirectToAction("ListPokemon","Pokemon");
        }

        public IActionResult MiSession()
        {
            if (HttpContext.Session.GetObject<List<int>>("SESSION") == null)
            {
                ViewData["MENSAJE"] = "LA SESSION ESTA VACIA";
                return View();
            }
            List<int> carrito = HttpContext.Session.GetObject<List<int>>("SESSION");
            List<Pokemon> pokemon = new List<Pokemon>();
            foreach (int id in carrito)
            {
                Pokemon poke = this.repo.FindPokemon(id);
                pokemon.Add(poke);
            }
            return View(pokemon);
        }

        public IActionResult RemoveSession(int id)
        {
            if (HttpContext.Session.GetObject<List<int>>("SESSION") != null)
            {
                List<int> carrito = HttpContext.Session.GetObject<List<int>>("SESSION");
                carrito.Remove(id);
                HttpContext.Session.SetObject("SESSION", carrito);
            }
            return RedirectToAction("MiSession","Pokemon");
        }
    }
}
