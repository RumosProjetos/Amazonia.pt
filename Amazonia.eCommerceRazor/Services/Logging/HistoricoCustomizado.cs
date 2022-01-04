using System;
using System.IO;

namespace Amazonia.eCommerceRazor.Services.Logging
{
    public class HistoricoCustomizado : IHistorico
    {
        public void Guardar(string logData)
        {
            var _fileName = @"c:\temp\log.txt";
            File.AppendAllText(_fileName, $"{Environment.NewLine}{DateTime.UtcNow}: {logData}");
        }
    }
}
