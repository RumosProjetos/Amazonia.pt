namespace Amazonia.DAL.Repositorios
{
    interface ICarrinhoCompras
    {
        decimal CalcularPreco();
        decimal AplicarDesconto(decimal valorDesconto); 
    }
}
