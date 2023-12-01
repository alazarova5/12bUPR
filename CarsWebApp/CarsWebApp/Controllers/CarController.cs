using System.Reflection.Metadata.Ecma335;

using CarsWebApp.Core.Contracts;
using CarsWebApp.Core.Services;
using CarsWebApp.Infrastructure.Data;
using CarsWebApp.Infrastructure.Data.Domain;
using CarsWebApp.Models.Car;
using CarsWebApp.Models.Model;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarsWebApp.Controllers
{
    public class CarController : Controller
    {

        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        // GET: CarController
        public ActionResult Index(string searchStringModel, string searchStringPrice)
        {
            List<CarAllViewModel> cars = _carService.GetCars(searchStringModel, searchStringPrice).Select(carFromDb => new CarAllViewModel
            {
                Id = carFromDb.Id,
                RegNumber = carFromDb.RegNumber,
                Manufacturer = carFromDb.Manufacturer,
                Model = carFromDb.Model,
                Picture = carFromDb.Picture,
                YearOfManufacture = carFromDb.YearOfManufacture,
                Price = carFromDb.Price
            }).ToList();

            return View(cars);
        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            
            Car item = _carService.GetCarById(id);
            if (item == null)
            {
                return NotFound();
            }
            CarDetailsViewModel car = new CarDetailsViewModel()
            {
                Id = item.Id,
                RegNumber = item.RegNumber,
                Manufacturer = item.Manufacturer,
                Model = item.Model,
                Picture = item.Picture,
                YearOfManufacture = item.YearOfManufacture,
                Price = item.Price
            };
            return this.View(car);
        }

        // GET: CarController/Create
        public IActionResult Create()
        {
            var car = new CarCreateViewModel();
            car.Models = _modelService.GetModels()
                .Select(c => new ModelPairViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
            return View(car);
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                var created = _carService.Create(bindingModel.RegNumber, bindingModel.Manufacturer, bindingModel.ModelId, bindingModel.Picture, bindingModel.YearOfManufacture, bindingModel.Price);
                if (created)
                {
                    return this.RedirectToAction(nameof(Index));
                }
            }
            return this.View();
        }

        public IActionResult Success()
        {
            return this.View();
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            Car item = _carService.GetCarById(id);
            if (item == null)
            {
                return NotFound();
            }
            CarEditViewModel car = new CarEditViewModel()
            {
                Id = item.Id,
                RegNumber = item.RegNumber,
                Manufacturer = item.Manufacturer,
                ModelId = item.ModelId,
                Picture = item.Picture,
                YearOfManufacture = item.YearOfManufacture,
                Price = item.Price
            };

            car.Models = _carService.GetModels()
                .Select(c => new ModelPairViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
            return this.View(car);
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CarEditViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                var updated = _carService.UpdateCar(id, bindingModel.RegNumber, bindingModel.Manufacturer, bindingModel.Model, bindingModel.Picture, bindingModel.YearOfManufacture, bindingModel.Price);
                if (updated)
                {
                    return this.RedirectToAction("Index");
                }
            }
            return View(bindingModel);
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {
            Car item = _carService.GetCarById(id);
            if (item == null)
            {
                return NotFound();
            }
            CarEditViewModel car = new CarEditViewModel()
            {
                Id = item.Id,
                RegNumber = item.RegNumber,
                Manufacturer = item.Manufacturer,
                Model = item.Model,
                Picture = item.Picture,
                YearOfManufacture = item.YearOfManufacture,
                Price = item.Price
            };
            return this.View(car);
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _carService.RemoveById(id);
            if (deleted)
            {
                return this.RedirectToAction("Index", "Car");
            }
            else
            {
                return View();
            }
        }

    }
}