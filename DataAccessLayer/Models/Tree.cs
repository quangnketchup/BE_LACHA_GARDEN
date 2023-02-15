using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Tree
    {
        public int Id { get; set; }
        public string NameTree { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int? Price { get; set; }
        public int? Status { get; set; }
        public int? TreeTypeId { get; set; }
        public int? GardenPackageId { get; set; }

        public virtual GardenPackage GardenPackage { get; set; }
        public virtual TreeType TreeType { get; set; }
    }
}
