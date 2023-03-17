using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Validation;

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

        [Required(ErrorMessage = "This field is Required!")]
        [MinLength(12, ErrorMessage = "Full name must be greater than 12 characters")]
        [ValidationAttributeModels(ErrorMessage = "name must have first character capitalize")]
        public string NamePack { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        [MinLength(20, ErrorMessage = "Image must to valid")]
        public string Image { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public double? Length { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public double? Width { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        [MinLength(12, ErrorMessage = "Full name must be greater than 12 characters")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public int? Status { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public int? PackageTypeId { get; set; }

        public virtual PackageType PackageType { get; set; }
        public virtual ICollection<Garden> Gardens { get; set; }
        public virtual ICollection<Tree> Trees { get; set; }
    }
}