using Amazonia.DAL.Modelo;
using System;

namespace Amazonia.eCommerceRazor.Models
{
    public class ClienteXMorada
    {
        public Guid Id { get; set; }
        public Cliente ClienteId { get; set; }
        public Morada MoradaId { get; set; }

        public bool Ativo { get; set; }


    }
}
