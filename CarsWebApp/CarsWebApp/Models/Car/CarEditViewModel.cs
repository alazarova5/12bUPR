using System.ComponentModel.DataAnnotations;

using CarsWebApp.Models.Model;

namespace CarsWebApp.Models.Car
{
    public class CarEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(8)]
        [MinLength(8)]
        [Display(Name = "RegNumber")]
        public string RegNumber { get; set; } = null!;

        [Required]
        [MaxLength(30)]
        [Display(Name = "Manufacturer")]
        public string Manufacturer { get; set; } = null!;


        [Display(Name = "Model")]
        public int ModelId { get; set; }

        [Display(Name = "Car Picture")]
        public string? Picture { get; set; }

        [Display(Name = "Year Of Manufacture")]
        public DateTime YearOfManufacture { get; set; }

        [Required]
        [Range(1000, 30000)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        public virtual List<ModelPairViewModel> Models { get; set; } = new List<ModelPairViewModel>();
    }
}
