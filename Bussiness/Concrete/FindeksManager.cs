using Bussiness.Abstract;
using Bussiness.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
    public class FindeksManager : IFindeksService
    {
        IFindeksOfCarDal _findeksOfCarDal;
        IFindeksOfUserDal _findeksOfUserDal;
        IUserService _userService;

        public FindeksManager(IFindeksOfCarDal findeksOfCarDal, IFindeksOfUserDal findeksOfUserDal,IUserService userService)
        {
            _findeksOfCarDal = findeksOfCarDal;
            _findeksOfUserDal = findeksOfUserDal;
            _userService = userService;
        }

        public IResult Check(string userEmail, int carId)
        {
            var userId = _userService.GetByMail(userEmail).Id;
            int carFindeks = _findeksOfCarDal.Get(c => c.CarId == carId).CarFindeks;
            int userFindeks = _findeksOfUserDal.Get(c => c.UserId == userId).UserFindeks;
            if (userFindeks>=carFindeks)
            {
                return new SuccessResult(Messages.FindeksIsEnough);
            }
            return new ErrorResult(Messages.FindeksIsNotEnough);

        }
    }
}
