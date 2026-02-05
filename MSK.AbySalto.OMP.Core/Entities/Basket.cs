namespace MSK.AbySalto.OMP.Core.Entities
{
    public class Basket : BaseEntity
    {
        public long Id { get; set; }
        public required string BuyerId { get; set; }
        public List<BasketItem>? Items { get; set; }
    }
}
