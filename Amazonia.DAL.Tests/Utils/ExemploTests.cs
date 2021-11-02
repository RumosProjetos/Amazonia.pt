using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Amazonia.DAL.Utils.Tests
{
    [TestClass]
    public class ExemploTests
    {
        [TestMethod]
        public void ObterValorDoConfigTest()
        {
            var valorObtidoPeloMetodo = Exemplo.ObterValorDoConfig("chaveExemplo");

            Assert.Fail();
        }
    }
}