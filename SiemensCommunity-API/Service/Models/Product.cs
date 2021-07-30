namespace Service.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int PhotoId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public bool IsAvailable { get; set; }
        public Photo Photo { get; set; }
        public double RatingAverage { get; set; }
    }
}
