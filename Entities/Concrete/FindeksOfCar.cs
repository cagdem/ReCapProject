using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class FindeksOfCar:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CarFindeks { get; set; }

    }
}
