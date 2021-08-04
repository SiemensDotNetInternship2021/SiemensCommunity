using Data.Models;

namespace Service.Models
{
    public class Photo
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public bool IsMain { get; set; }

        public string PublicId { get; set; }

        public User AppUser { get; set; }

        public int AppUserId { get; set; }
    }
}
