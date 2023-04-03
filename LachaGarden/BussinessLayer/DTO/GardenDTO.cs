using DataAccessLayer.Models;

namespace BussinessLayer.DTO
{
    public class GardenDTO
    {
        public int Id { get; set; }
        public int? Status { get; set; }
        public int? GardenPackageId { get; set; }

        public DateTime? DateTime { get; set; }
        public int? RoomId { get; set; }
        public virtual GardenPackageDTO GardenPackage { get; set; }
        public virtual RoomDTO Room { get; set; }
        public string GardenPackageName { get; set; }

        public GardenDTO(GardenPackageDTO GardenPackage, RoomDTO Room, int Id, int? Status, int? GardenPackageId, DateTime? DateTime, int? RoomId)
        {
            this.Id = Id;
            this.Status = Status;
            this.GardenPackageId = GardenPackageId;
            this.DateTime = DateTime;
            this.RoomId = RoomId;
            this.GardenPackage = GardenPackage;
            this.RoomId = RoomId;
            this.Room = Room;
        }
    }
}