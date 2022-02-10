namespace Amazonia.eCommerceRazor.Services.AplicacaoExterna
{
    public interface IComponenteAdapter
    {
        void GeradorDocumento(string path, byte[] dados);
    }
}
