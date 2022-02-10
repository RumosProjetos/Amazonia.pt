using Amazonia.DAL.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Amazonia.eCommerceRazor.Controllers
{
    public class LivroController : Controller
    {
        readonly List<Livro> livros;

        public LivroController()
        {
            livros = new List<Livro>();
            for (int i = 0; i < 10; i++)
            {
                livros.Add(new Livro { Id = i, Autor = $"Autor {i}", Descricao = $"Descricao {i}", Preco = new Random().Next(), UrlCapaDoLivro = $"https://static.fnac-static.com/multimedia/Images/PT/NR/35/e5/40/4252981/150{i}-0.jpg" });
            }
        }


        // GET: LivroController
        public ActionResult Index()
        {
            ViewBag.ClienteLogado = HttpContext.Request.Cookies["NomeUtilizador"];
            return View(livros);
        }

        // GET: LivroController/Details/5
        public ActionResult Details(int id)
        {
            var livro = livros.FirstOrDefault(x => x.Id == id);
            return View(livro);
        }







        // GET: LivroController/Create
        public ActionResult Create()
        {
            var livro = new Livro();
            return View(livro);
        }

        // POST: LivroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var livroNovo = new Livro
                {
                    Id = Convert.ToInt32(collection["id"]),
                    Autor = collection["autor"],
                    Descricao = collection["descricao"],
                    Preco = Convert.ToDecimal(collection["preco"]),
                    UrlCapaDoLivro = collection["urlCapaDoLivro"]
                };

                livros.Add(livroNovo);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LivroController/Edit/5
        public ActionResult Edit(int id)
        {
            var livro = livros.FirstOrDefault(x => x.Id == id);
            return View(livro);
        }

        // POST: LivroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var livro = livros.FirstOrDefault(x => x.Id == id);
                
                var dadosNovos = new Livro
                {
                    Id = livro.Id,
                    Autor = collection["autor"],
                    Descricao = collection["descricao"],
                    Preco = Convert.ToDecimal(collection["preco"]),
                    UrlCapaDoLivro = collection["urlCapaDoLivro"]
                };



                livro = dadosNovos;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LivroController/Delete/5
        //Tem precedência !!! Cuidado
        [Route("Apagar")]
        [Route("Deletar")]
        [Route("Excluir")]
        [Authorize(Roles = "Administradores")]
        public ActionResult Delete(int id)
        {
            var livro = livros.FirstOrDefault(x => x.Id == id);
            return View(livro);
        }

        // POST: LivroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var livro = livros.FirstOrDefault(x => x.Id == id);
                livros.Remove(livro);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
