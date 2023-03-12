namespace DataAccessLayer.Models
{
    public partial class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public int? Status { get; set; }
        public int? BuildingId { get; set; }
        public string CustomerId { get; set; }

        public virtual Building Building { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Garden Garden { get; set; }
    }
}