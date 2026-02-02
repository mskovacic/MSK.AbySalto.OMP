namespace MSK.AbySalto.OMP.Core.Entities
{
    public class BasketItem
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
        public long ProductId { get; set; }
        public Basket Basket { get; set; } = null!;
    }

    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}