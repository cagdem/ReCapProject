using Bussiness.Abstract;
using Bussiness.BusinessAspects;
using Bussiness.BusinessAspects.Autofac;
using Bussiness.Constants;
using Bussiness.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bussiness.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        IBrandService _brandService;
        IColorService _colorService;

        public ProductManager(IProductDal productDal, IBrandService brandService, IColorService colorService)
        {
            _productDal = productDal;
            _brandService = brandService;
            _colorService = colorService;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Car car)
        {
            _productDal.Add(car);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Car car)
        {
            _productDal.Delete(car);
            return new SuccessResult(Messages.ProductDeleted);
        }

        [SecuredOperation("product.add,admin")]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_productDal.Get(c => c.Id == id), Messages.ProductListed);
        }

        public IDataResult<CarDetailDto> GetCarDetails(int id)
        {
            return new SuccessDataResult<CarDetailDto>(_productDal.GetProductDetails(c=>c.CarId==id).SingleOrDefault(), Messages.ProductListed);
        }
        public IDataResult<List<CarDetailDto>> GetCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_productDal.GetProductDetails(), Messages.ProductListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int id)
        {
            var result = _brandService.GetById(id);
            return new SuccessDataResult<List<CarDetailDto>>(_productDal.GetProductDetails(c=>c.BrandName==result.Data.BrandName), Messages.ProductListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int id)
        {
            var result = _colorService.GetById(id);
            return new SuccessDataResult<List<CarDetailDto>>(_productDal.GetProductDetails(c => c.ColorName == result.Data.ColorName), Messages.ProductListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_productDal.GetAll(c => c.BrandId == id), Messages.ProductListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_productDal.GetAll(c => c.ColorId == id), Messages.ProductListed);
        }

        [ValidationAspect(typeof(ProductValidator))]

        public IResult Update(Car car)
        {
            _productDal.Update(car);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
