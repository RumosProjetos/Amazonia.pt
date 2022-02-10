namespace Amazonia.eCommerceRazor.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
