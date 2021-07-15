using System;
using System.Collections.Generic;
<<<<<<< Updated upstream
=======
using System.ComponentModel.DataAnnotations;
>>>>>>> Stashed changes
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class BorrowedProduct
    {
<<<<<<< Updated upstream
=======
        [Key]
>>>>>>> Stashed changes
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
<<<<<<< Updated upstream

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
=======
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
>>>>>>> Stashed changes
    }
}
