using DataAccessLayer.Validation;

namespace DataAccessLayer.Models
{
    public partial class PackageType
    {
        public PackageType()
        {
            GardenPackages = new HashSet<GardenPackage>();
        }

        public int Id { get; set; }
        public string NamePackageType { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<GardenPackage> GardenPackages { get; set; }
    }
}