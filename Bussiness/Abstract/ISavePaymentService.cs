using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Abstract
{
    public interface ISavePaymentService
    {
        IResult Add(SavePayment savePayment);
        IResult Update(SavePayment savePayment);
        IResult Delete(SavePayment savePayment);
        IDataResult<SavePayment> GetByUserId(int userId);

    }
}
