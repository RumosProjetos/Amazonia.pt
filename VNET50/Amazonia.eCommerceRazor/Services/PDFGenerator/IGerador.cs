namespace Amazonia.eCommerceRazor.Services.PDFGenerator
{
    public interface IGerador
    {
        void GerarPDF(string path, byte[] data);
    }
}
