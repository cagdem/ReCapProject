using Bussiness.Abstract;
using Bussiness.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;

        }

        public IResult Add(Car car)
        {
            if (car.DailyPrice>0)
            {
                _productDal.Add(car);
                return new SuccessResult(Messages.ProductAdded);
            }
            return new ErrorResult(Messages.DailyPriceInvalid);
        }

        public IResult Delete(Car car)
        {
            _productDal.Delete(car);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<Car>GetById(int id)
        {
            return new SuccessDataResult<Car>(_productDal.Get(c => c.Id == id),Messages.ProductListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_productDal.GetProductDetails(),Messages.ProductListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_productDal.GetAll(c => c.BrandId == id),Messages.ProductListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_productDal.GetAll(c=>c.ColorId == id),Messages.ProductListed);
        }

        public IResult Update(Car car)
        {
            _productDal.Update(car);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
