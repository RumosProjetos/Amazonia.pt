namespace Amazonia.WebApi.Dto
{
    public class ClienteMoradaDto
    {
        //Dados de Cliente
        public string Nome { get; set; }
        public string NumeroIdentificacaoFiscal { get; set; }


        //Dados da Morada
        public string Distrito { get; set; }
        public string Localidade { get; set; }
        public string Endereco { get; set; }
        public string CodigoPostal { get; set; }
    }
}
