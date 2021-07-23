using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Models
{
    public class FavoriteProductDTO
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string SubCategoryName { get; set; }

        public string User { get; set; }

        public string Name { get; set; }

        public bool IsAvailable { get; set; }

        public string ImagePath { get; set; }

        public double Rating { get; set; }

        public string Details { get; set; }
    }
}
