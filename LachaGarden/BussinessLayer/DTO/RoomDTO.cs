using DataAccessLayer.Models;

namespace BussinessLayer.DTO
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public int? Status { get; set; }
        public int? BuildingId { get; set; }
        public string CustomerId { get; set; }
    }
}