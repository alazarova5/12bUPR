using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace CarsWebApp.Infrastructure.Data.Domain
{
    public class Model
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public virtual IEnumerable<Car> Cars { get; set; } = null!;
    }
}
