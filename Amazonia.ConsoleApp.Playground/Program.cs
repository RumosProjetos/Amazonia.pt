using Amazonia.eCommerceRazor.Services.Logging;
using SimpleInjector;

namespace Amazonia.ConsoleApp.Playground
{
    public static class Program
    {
        static readonly Container container;
        static Program()
        {
            // 1. Create a new Simple Injector container
            container = new Container();
            // 2. Configure the container (register)
            container.Register<IHistorico, HistoricoCustomizado>(Lifestyle.Singleton);
            // 3. Verify your configuration
            container.Verify();
        }


        static void Main(string[] args)
        {
            var logger = container.GetInstance<HistoricoCustomizado>();
            logger.Guardar("Mensagem");
        }
    }
}
