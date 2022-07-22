namespace MinimalAPI_Net6_Playground.Data.Models
{
    public class Product
    {
        public Product(string description, int quantity)
        {
            Description = description;
            Quantity = quantity;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
