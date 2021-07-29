﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class FavoriteProduct
    {  
       [Key]
       public int Id { get; set; }

       [ForeignKey("Product")]
       public int ProductId { get; set; }

       [ForeignKey("User")]
       public int UserId { get; set; }

       public User User { get; set; }

       public Product Product { get; set; }
    }
}