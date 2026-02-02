namespace MSK.AbySalto.OMP.Core.Entities
{
    public class Basket
    {
        public long Id { get; set; }
        public string BuyerId { get; set; } = string.Empty;
        public List<BasketItem> Items { get; set; } = new();
    }
}
