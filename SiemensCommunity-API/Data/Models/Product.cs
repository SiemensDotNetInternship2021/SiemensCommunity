using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category{ get; set; }
        [ForeignKey("SubCategory")]
        public int SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Photo")]
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public int Rating { get; set; }
        public string Details { get; set; }
    }
}
