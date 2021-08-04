using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SiemensCommunity.Models
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int SubCategoryId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Details { get; set; }

        public string ImageURL { get; set; }

        public IFormFileCollection Files { get; set; }
    }
}
