using DataAccessLayer.Validation;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public partial class Tree
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        [MinLength(12, ErrorMessage = "Tree name must be greater than 12 characters")]
        [ValidationAttributeModels(ErrorMessage = "name must have first character capitalize")]
        public string NameTree { get; set; } = null!;

        [Required(ErrorMessage = "This field is Required!")]
        [MinLength(12, ErrorMessage = "Description must be greater than 12 characters")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "This field is Required!")]
        [MaxLength(200, ErrorMessage = "Description cannot be over 200 characters")]
        [MinLength(12, ErrorMessage = "Description must be greater than 12 characters")]
        public string Image { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        [Range(1, 100000000, ErrorMessage = "Price must be between 1 and 100000000")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public int? Status { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public int? TreeTypeId { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public int? GardenPackageId { get; set; }

        public virtual GardenPackage GardenPackage { get; set; }
        public virtual TreeType TreeType { get; set; }
    }
}