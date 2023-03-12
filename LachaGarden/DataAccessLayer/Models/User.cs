namespace DataAccessLayer.Models
{
    public partial class User
    {
        public User()
        {
            TreeCares = new HashSet<TreeCare>();
        }

        public string Id { get; set; }
        public string NameTech { get; set; }
        public string Gmail { get; set; }
        public decimal? Phone { get; set; }
        public string Image { get; set; }
        public int? Gender { get; set; }
        public int? Status { get; set; }
        public int? RoleId { get; set; }
        public string Password { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<TreeCare> TreeCares { get; set; }
    }
}