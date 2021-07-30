namespace Service.Models
{
    public class Product
    {
        public int Id { get; set; }
        //public int CategoryId { get; set; }
        //public int UserId { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public double RatingAverage { get; set; }
        public string Details { get; set; }
        //public User User { get; set; }
    }
}
