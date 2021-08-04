using Microsoft.AspNetCore.Http;

namespace Data.Models
{
    public class AddProduct
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int SubCategoryId { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Details { get; set; }

        public IFormFile Image { get; set; }
    }
}
