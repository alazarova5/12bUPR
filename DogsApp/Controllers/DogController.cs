using System.Net.Cache;

using DogsApp.Infrastucture.Data;
using DogsApp.Infrastucture.Data.Domain;
using DogsApp.Models.Dog;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogsApp.Controllers
{
    public class DogController : Controller
    {
        // GET: DogController
        private readonly ApplicationDbContext _context;
        public DogController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            List<DogAllViewModel> dogs = _context.Dogs.Select(dogFromDb => new DogAllViewModel
            {
                Id = dogFromDb.Id,
                Name = dogFromDb.Name,
                Age = dogFromDb.Age,
                Breed = dogFromDb.Breed,
                Picture = dogFromDb.Picture
            }).ToList();
            return View(dogs);
        }

        // GET: DogController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DogController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DogCreateVeiwModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Dog dogFormDb = new Dog
                {
                    Name = bindingModel.Name,
                    Age = bindingModel.Age,
                    Breed = bindingModel.Breed,
                    Picture = bindingModel.Picture,
                };

                _context.Dogs.Add(dogFormDb);
                _context.SaveChanges();

                return this.RedirectToAction("Success");
            }
                return this.View();
        }

        public IActionResult Success()
        {
            return this.View();
        }

        // GET: DogController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }

            Dog? item = _context.Dogs.Find(id);
            if (item==null)
            {
                return NotFound();
            }

            DogEditViewModel dog = new DogEditViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture = item.Picture
            };
            return View(dog);
        }

        // POST: DogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DogEditViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Dog dog = new Dog
                {
                    Id = id,
                    Name = bindingModel.Name,
                    Age = bindingModel.Age,
                    Breed = bindingModel.Breed,
                    Picture = bindingModel.Picture
                };

                _context.Dogs.Update(dog);
                _context.SaveChanges();
                return this.RedirectToAction("Index");
            }
            return View(bindingModel);
        }

        // GET: DogController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
