namespace Service.Models
{
    public class ProductRating
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int Rate { get; set; }

    }
}
