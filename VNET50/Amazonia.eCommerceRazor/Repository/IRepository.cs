using System;
using System.Collections.Generic;

namespace Amazonia.eCommerceRazor.Repository
{
    interface IRepository<T>
    {
        IEnumerable<T> Listar();
        T ObterPorId(Guid id);
        void Criar();
        void Atualizar(Guid id);
        void Apagar(Guid id);
    }
}
