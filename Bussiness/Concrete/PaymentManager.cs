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
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.PaymentAdded);
        }

        public IResult Check(Payment payment)
        {
            var tempPayment = _paymentDal.Get(p => p.CardNumber == payment.CardNumber);
            if (tempPayment==null)
            {
                return new ErrorResult(Messages.PaymentIsNotValid);
            }
            if (tempPayment.Name==payment.Name && tempPayment.Cvv==payment.Cvv && tempPayment.Exp==payment.Exp)
            {
                return new SuccessResult(Messages.PaymentIsValid);
            }
            else
            {
                return new ErrorResult(Messages.PaymentIsNotValid);
            }

        }

        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult(Messages.PaymentDeleted);
        }

        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult(Messages.PaymentUpdated);
        }
    }
}
