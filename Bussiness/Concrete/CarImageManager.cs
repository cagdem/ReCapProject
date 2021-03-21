using Bussiness.Abstract;
using Bussiness.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bussiness.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            if (carImage.ImagePath == null)
            {
                IResult result1 = BusinessRules.Run(CheckIfImageExists(carImage.CarId));

                if (result1 != null)
                {
                    return result1;
                }
            }

            IResult result = BusinessRules.Run(CheckIfImageLimitExceded(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Add(carImage);
            return new SuccessResult();
        }


        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> List(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetById(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));
        }

        private IResult CheckIfImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(c=>c.CarId == carId);
            if (result.Count > 5)
            {
                return new ErrorResult(Messages.ImageLimitExceded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfImageExists(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Any())
            {
                return new ErrorResult(Messages.ImageAlreadyNull);
            }
            return new SuccessResult();
        }

        public IDataResult<int> GetCountById(int id)
        {
            return new SuccessDataResult<int>(_carImageDal.GetAll(c => c.CarId == id).Count);
        }


    }
}
