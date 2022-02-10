using System;

namespace Amazonia.eCommerceRazor.Models
{
    public class Person
    {
        public Guid Id => Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
