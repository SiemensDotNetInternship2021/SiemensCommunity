using Microsoft.AspNetCore.Http;

namespace Service.Models
{
    public class ProductFormDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }

        public SubCategory Subcategory { get; set; }

        public string Photo { get; set; }

        public IFormCollection Image { get; set; }

        public string Details { get; set; }
    }
}
