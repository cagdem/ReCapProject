using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Abstract
{
    public interface IPaymentService
    {
        IResult Add(Payment payment);
        IResult Update(Payment payment);
        IResult Delete(Payment payment);
        IResult Check(Payment payment);
    }
}
