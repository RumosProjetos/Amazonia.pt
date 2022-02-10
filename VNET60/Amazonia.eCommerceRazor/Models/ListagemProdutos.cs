using System;
using System.Collections.Generic;

namespace Amazonia.eCommerceRazor.Models
{
    public class ListagemProdutos
    {
        public List<Product> Products { get; set; }

        public ListagemProdutos()
        {
            Products = new List<Product>
            {
                new Product() { Id = new Random().Next(), Name = "Batata" },
                new Product() { Id = new Random().Next(), Name = "Cenoura" },
                new Product() { Id = new Random().Next(), Name = "Cebola" },
                new Product() { Id = new Random().Next(), Name = "Maçã" }
            };
        }
    }
}
