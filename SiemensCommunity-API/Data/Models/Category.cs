using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [StringLength(70)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
        public IEnumerable<Property> Properties { get; set; }
        public ICollection<SubCategory> SubCategory { get; set; }
    }
}
