namespace MSK.AbySalto.OMP.Core.Entities
{
    public class BasketItem : BaseEntity
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
        public long ProductId { get; set; }

        public long BasketId { get; set; }
        public Basket Basket { get; set; } = null!;
        public int UnitDiscount { get; set; }
        public Product Product { get; set; } = null!;
    }
}