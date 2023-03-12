namespace DataAccessLayer.Models
{
    public partial class Building
    {
        public Building()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string NameBuilding { get; set; }
        public int? AreaId { get; set; }

        public virtual Area Area { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}