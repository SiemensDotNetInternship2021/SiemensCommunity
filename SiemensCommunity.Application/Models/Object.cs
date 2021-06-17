using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiemensCommunity.Application.Models
{
    public class Object
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
    }
}
