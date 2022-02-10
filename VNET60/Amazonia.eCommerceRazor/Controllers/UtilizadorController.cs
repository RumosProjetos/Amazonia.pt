using Amazonia.eCommerceRazor.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Amazonia.eCommerceRazor.Controllers
{
    public partial class UtilizadorController : Controller
    {
        private readonly List<Utilizador> utilizadores;
        public UtilizadorController()
        {
            utilizadores = new List<Utilizador>
            {
                //xxcvxcvd
                new Utilizador{ Id = Guid.NewGuid(), Login = "joao.silva", Nome = "João da Silva", PalavraPasse = "e7c66e055c714df32c6a3f60e1aa7eba", Ativo = true, Sexo = SexoEnum.Masculino, ContagemDeLoginNoUltimoAno = 10},
                //palavra
                new Utilizador{ Id = Guid.NewGuid(), Login = "maria.sousa", Nome = "Maria de Sousa", PalavraPasse = "3900cf077ad01720b5f7ab5674d392fb", Ativo = false, Sexo = SexoEnum.Feminino, ContagemDeLoginNoUltimoAno = 100},
            };
        }

        public IActionResult CriarUtilizador()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CriarUtilizador(Utilizador utilizador)
        {
            utilizadores.Add(utilizador);
            return View(utilizador);
        }


        //CRUD

        [HttpGet]
        public IActionResult ListagemDeUtilizadores()
        {
            return View(utilizadores);
        }

        [HttpGet]
        public IActionResult EdicaoDeUtilizador(Guid id)
        {
            var utilizador = utilizadores.FirstOrDefault(x => x.Id == id);
            return View(utilizador);
        }


        [HttpPost]
        public IActionResult EdicaoDeUtilizador(Guid id, Utilizador utilizador)
        {
            var userTemp = utilizadores.FirstOrDefault(x => x.Id == id);
            userTemp = utilizador;


            return View(userTemp);
        }




    }
}

