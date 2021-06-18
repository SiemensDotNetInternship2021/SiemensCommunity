using System.ComponentModel.DataAnnotations;

namespace SiemensCommunity.Persistence.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public string Details { get; set; }
        public User User { get; set; }
    }
}
