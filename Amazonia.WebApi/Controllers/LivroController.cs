using Amazonia.DAL.Modelo;
using Amazonia.WebApi.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazonia.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        AmazoniaContexto ctx;
        public LivroController()
        {
            ctx = new AmazoniaContexto();
        }

        [HttpGet]
        public List<Livro> GetLivros()
        {
            return ctx.Livros.ToList();
        }

        [HttpGet("{id}")]
        public Livro GetLivro(Guid id)
        {
            return ctx.Livros.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public Guid PostLivroNovo(LivroDto livro)
        {
            Livro livroNovo = new LivroImpresso();
            switch (livro.TipoLivro)
            {
                case EnumTipoLivro.LivroImpresso:
                    livroNovo = new LivroImpresso();
                    break;
                case EnumTipoLivro.LivroDigital:
                    livroNovo = new LivroDigital();
                    break;
                case EnumTipoLivro.AudioLivro:
                    livroNovo = new AudioLivro();
                    break;
            }

            livroNovo.Nome = livro.Nome;
            livroNovo.Autor = livro.Autor;
            livroNovo.Descricao = livro.Descricao;

            ctx.Livros.Add(livroNovo);
            return livroNovo.Id;
        }
    }


}
