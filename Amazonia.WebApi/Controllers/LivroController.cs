using Amazonia.DAL.Modelo;
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
        [HttpGet]
        public List<Livro> GetLivros()
        {
            var ctx = new AmazoniaContexto();
            return ctx.Livros.ToList();
        } 
    }
}
