using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Abstract
{
    public interface IFindeksService
    {
        IResult Check(string userEmail, int carId);
    }
}
