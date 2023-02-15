using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class GardenPackage
    {
        public GardenPackage()
        {
            Gardens = new HashSet<Garden>();
            Trees = new HashSet<Tree>();
        }

        public int Id { get; set; }
        public string NamePack { get; set; }
        public string Image { get; set; }
        public int? Length { get; set; }
        public int? Width { get; set; }
        public int? Status { get; set; }
        public int? PackageTypeId { get; set; }

        public virtual PackageType PackageType { get; set; }
        public virtual ICollection<Garden> Gardens { get; set; }
        public virtual ICollection<Tree> Trees { get; set; }
    }
}
