namespace DataAccessLayer.Models
{
    public partial class TreeType
    {
        public TreeType()
        {
            Trees = new HashSet<Tree>();
        }

        public int Id { get; set; }
        public string NameTreeType { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Tree> Trees { get; set; }
    }
}