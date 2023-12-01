using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CarsWebApp.Models.Model
{
    public class ModelPairViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Model")]
        public string Name { get; set; } = null!;
    }
}
