using System.Collections.Generic;
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
        
        [ForeignKey("SubCategory")]
        public int SubCategoryId { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        
        [ForeignKey("Photo")]
        public int PhotoId { get; set; }
        
        public string Name { get; set; }

        public bool IsAvailable { get; set; }

        public double RatingAverage { get; set; }

        public string Details { get; set; }

        public ICollection<FavoriteProduct> FavoriteProduct { get; set; }

        public ICollection<ProductRating> ProductRating { get; set; }

        public User User { get; set; }

        public virtual SubCategory SubCategory { get; set; }

        public virtual Category Category { get; set; } 

        public Photo Photo { get; set; }

        public BorrowedProduct BorrowedProduct { get; set; }

    }
}
