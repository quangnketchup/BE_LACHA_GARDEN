using DataAccessLayer.Models;

namespace BussinessLayer.DTO
{
    public class UserDTO : Role
    {
        public int Id { get; set; }
        public string NameTech { get; set; }
        public string Gmail { get; set; }
        public decimal? Phone { get; set; }
        public string Image { get; set; }
        public int? Gender { get; set; }
        public int? Status { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
    }
}