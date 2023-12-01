using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarsWebApp.Core.Contracts;
using CarsWebApp.Infrastructure.Data;
using CarsWebApp.Infrastructure.Data.Domain;

namespace CarsWebApp.Core.Services
{
    public class ModelService:IModelService
    {
        private readonly ApplicationDbContext _context;
        public ModelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Model GetModelById(int modelId)
        {
            return _context.Models.Find(modelId);
        }


        public List<Model> GetModles()
        {
            List<Model> models = _context.Models.ToList();
            return models;
        }

        public List<Car> GetCarsByModel(int modelId)
        {
            return _context.Cars.Where(x => x.ModelId == modelId).ToList();
        }

    }
}
