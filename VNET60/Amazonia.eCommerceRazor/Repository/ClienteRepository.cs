using Amazonia.eCommerceRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Amazonia.eCommerceRazor.Repository
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private readonly ECommerceDbContext _context;

        public ClienteRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public void Apagar(Guid id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        public void Atualizar(Guid id)
        {
            var cliente = _context.Clientes.FirstOrDefault(m => m.Id == id);
            cliente.Nome = "Brandon";

            _context.Update(cliente);
            _context.SaveChanges();
        }

        public void Criar()
        {
            _context.Add(new Cliente()
            {
                Nome = "Exemplo",
                DataNascimento = DateTime.Now,
                NumeroIdentificacaoFiscal = "123456789",
                Password = "12345678",
                UserName = "teste@email.com"
            });
            _context.SaveChanges();
        }

        public IEnumerable<Cliente> Listar()
        {
            return _context.Clientes.ToList();
        }

        public Cliente ObterPorId(Guid id)
        {
            return _context.Clientes.FirstOrDefault(c => c.Id == id);
        }
    }
}
