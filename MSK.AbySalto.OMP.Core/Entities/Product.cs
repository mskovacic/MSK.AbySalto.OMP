namespace MSK.AbySalto.OMP.Core.Entities
{
    public class Product : BaseEntity
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Image { get; set; }
        public required string Description { get; set; }
        public int Price { get; set; }
    }
}