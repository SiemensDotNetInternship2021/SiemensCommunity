using Microsoft.AspNetCore.Http;

namespace Service.Models
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int SubCategoryId { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Details { get; set; }

        public string ImageURL { get; set; }

        public int PhotoId { get; set; }

        public IFormFile File { get; set; }
    }
}
