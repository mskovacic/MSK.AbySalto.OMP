namespace MSK.AbySalto.OMP.Core.DTO
{
    public class BasketItemDTO
    {
        public required long Id { get; set; }
        public required int Quantity { get; set; }
        public required int UnitDiscount { get; set; }
        public required int TotalPrice { get; set; }
        public required ProductDTO Product { get; set; }
    }
}
