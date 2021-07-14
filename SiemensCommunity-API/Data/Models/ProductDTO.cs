using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string SubCategoryName { get; set; }

        public string User { get; set; }

        public string Name { get; set; }

        public bool IsAvailable { get; set; }

        public string ImagePath { get; set; }

        public int Rating { get; set; }

        public string Details { get; set; }
    }
}
