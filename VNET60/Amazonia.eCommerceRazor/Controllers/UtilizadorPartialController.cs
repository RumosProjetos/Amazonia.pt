using Amazonia.eCommerceRazor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using System.Linq;
using System.Text;

namespace Amazonia.eCommerceRazor.Controllers
{
    public partial class UtilizadorController : Controller
    {
        private static string ObterHashMD5(string palavraPasse)
        {
            var md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(palavraPasse));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }


  

        private Utilizador ValidarLoginSenha(string login, string palavraPasse)
        {
            var hashCalculado = ObterHashMD5(palavraPasse);
            var utilizador = utilizadores.FirstOrDefault(x => x.Login == login && x.PalavraPasse == hashCalculado);

            if (utilizador != null)
            {
                var cookieOptions = new CookieOptions
                {
                    Expires = new DateTimeOffset(DateTime.Now.AddMinutes(30))
                };
                HttpContext.Response.Cookies.Append("NomeUtilizador", utilizador.Nome, cookieOptions);
            }

            return utilizador;
        }

        [HttpGet]
        [Route("EfetuarLogin")]
        public IActionResult EfetuarLogin(string login, string palavraPasse)
        {
            var resultado = ValidarLoginSenha(login, palavraPasse);
            return View(resultado);
        }


        [HttpGet]
        [Route("EditarDados")]
        public IActionResult EditarDados()
        {
            var utilizador = utilizadores.FirstOrDefault();
            return View(utilizador);
        }




        [HttpGet]
        [Route("VisualizarDados")]
        public IActionResult VisualizarComModel()
        {
            var utilizador = utilizadores.FirstOrDefault();
            return View(utilizador);
        }


        public IActionResult Logout()
        {
            ViewBag.MinhaVar = "";
            return View("home");
        }
    }
}

