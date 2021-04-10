using Bussiness.Abstract;
using Bussiness.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
    public class SavePaymentManager : ISavePaymentService
    {
        ISavePaymentDal _savePaymentDal;

        public SavePaymentManager(ISavePaymentDal savePaymentDal)
        {
            _savePaymentDal = savePaymentDal;
        }

        public IResult Add(SavePayment savePayment)
        {
            _savePaymentDal.Add(savePayment);
            return new SuccessResult(Messages.PaymentSaved);
        }

        public IResult Delete(SavePayment savePayment)
        {
            _savePaymentDal.Delete(savePayment);
            return new SuccessResult(Messages.PaymentDeleted);
        }

        public IDataResult<SavePayment> GetByUserId(int userId)
        {
            return new SuccessDataResult<SavePayment>(_savePaymentDal.Get(p => p.UserId == userId));
        }

        public IResult Update(SavePayment savePayment)
        {
            _savePaymentDal.Update(savePayment);
            return new SuccessResult(Messages.PaymentUpdated);
        }
    }
}
