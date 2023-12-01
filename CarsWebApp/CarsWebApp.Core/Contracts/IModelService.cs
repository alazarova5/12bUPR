using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarsWebApp.Infrastructure.Data.Domain;

namespace CarsWebApp.Core.Contracts
{
    public interface IModelService
    {
        List<Model> GetModles();
        Model GetModelById(int modelId);
        List<Car> GetCarsByModel(int modelId);

    }
}
