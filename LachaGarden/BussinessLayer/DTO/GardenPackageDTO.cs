namespace BussinessLayer.DTO
{
    public partial class GardenPackageDTO
    {
        public int Id { get; set; }
        public string NamePack { get; set; }
        public string Image { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int? Status { get; set; }
        public int? PackageTypeId { get; set; }
    }
}