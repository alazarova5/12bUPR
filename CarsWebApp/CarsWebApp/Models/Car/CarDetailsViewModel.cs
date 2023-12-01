namespace CarsWebApp.Models.Car
{
    public class CarDetailsViewModel
    {
        public int Id { get; set; }
        public string RegNumber { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public string Model { get; set; } = null!;
        public string? Picture { get; set; }
        public DateTime YearOfManufacture { get; set; }
        public decimal Price { get; set; }
    }
}
