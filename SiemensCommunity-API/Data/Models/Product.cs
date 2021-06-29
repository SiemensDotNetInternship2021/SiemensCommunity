using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        //public int CategoryId { get; set; }
        //public int UserId { get; set; }
        public string Name { get; set; }
        //public string Details { get; set; }
        //public User User { get; set; }
    }
}
