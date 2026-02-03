namespace MSK.AbySalto.OMP.Core.DTO
{
    public class BasketDTO
    {
        public required long Id { get; set; }
        public required string BuyerId { get; set; }
        public required BasketItemDTO[] Items { get; set; }
    }
}
