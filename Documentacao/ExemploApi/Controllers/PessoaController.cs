using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExemploApi.Models;

namespace ExemploApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly ILogger<PessoaController> _logger;
        private List<Pessoa> pessoas;

        public PessoaController(ILogger<PessoaController> logger)
        {
            _logger = logger;

            pessoas = new List<Pessoa>();

            pessoas.Add(new Pessoa{ Id= 1, Nome = "Maria", DataNascimento = DateTime.Now });
            pessoas.Add(new Pessoa{ Id= 2, Nome = "Joao", DataNascimento = DateTime.Now });
            pessoas.Add(new Pessoa{ Id= 3, Nome = "Pedro", DataNascimento = DateTime.Now });
        }

        [HttpGet]
        public IEnumerable<Pessoa> Get()
        {   
            return  pessoas;
        }


        //HttpPOst - Create
        [HttpPost]
        public Pessoa Post(Pessoa pessoa)
        {
            pessoas.Add(pessoa);
            return  pessoa;
        }


        //HttpPut - Update
        [HttpPut]
        public Pessoa Put(int posicao, Pessoa pessoa)
        {   
            var atualizado = pessoas.FirstOrDefault(x => x.Id == posicao);
            atualizado.DataNascimento = pessoa.DataNascimento;
            atualizado.Nome = pessoa.Nome;
            atualizado.Id = pessoa.Id;

            return  atualizado;
        }


        //HttpDelete - Remove
        [HttpDelete]
        public bool Delete(int posicao)
        {   
            var apagado =  pessoas.FirstOrDefault(x => x.Id == posicao);
            pessoas.Remove(apagado);
            return  true;
        }

    }
}
