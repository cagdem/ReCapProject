using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Abstract
{
    public interface IProductService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarsDetails();
        IDataResult<CarDetailDto> GetCarDetails(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int id); 
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int id);
    }
}
