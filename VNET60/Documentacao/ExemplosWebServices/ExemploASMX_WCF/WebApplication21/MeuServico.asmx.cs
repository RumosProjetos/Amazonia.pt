using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebApplication21.Dto;

namespace WebApplication21
{
    /// <summary>
    /// Summary description for MeuServico
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MeuServico : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// Meu Servico de Soma
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [WebMethod]        
        public int Somar(int a, int b)
        {
            return a + b;
        }


        [WebMethod]
        public bool CreatePessoa(Pessoa pessoa)
        {
            return pessoa.Nome.Length >= 10;
        }
    }
}
