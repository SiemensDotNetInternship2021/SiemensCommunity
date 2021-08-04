namespace Data.Models
{
    public class ProductFormDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; }

        public string Details { get; set; }

        public Category Category { get; set; }

        public SubCategory SubCategory { get; set; }
    }
}
