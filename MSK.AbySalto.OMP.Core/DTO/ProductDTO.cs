namespace MSK.AbySalto.OMP.Core.DTO
{
    public class ProductDTO
    {
        public required long Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
        public required int Price { get; set; }
    }
}
