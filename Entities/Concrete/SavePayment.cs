using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class SavePayment : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Details { get; set; }
    }
}
