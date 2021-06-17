namespace SiemensCommunity.Services.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public User User { get; set; }
    }
}
