using DataAccessLayer.Models;

namespace BusinessLayer.Models
{
    public class CustomerDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public decimal? Phone { get; set; }
        public string Gmail { get; set; }
        public int? Gender { get; set; }
        public int? Status { get; set; }
        public string Password { get; set; }
    }
}