namespace BussinessLayer.DTO
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public int? RoomNumber { get; set; }
        public int? Square { get; set; }
        public int? Status { get; set; }
        public int? BuildingId { get; set; }
        public int? CustomerId { get; set; }
    }
}