using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Abstract
{
    public interface IColorService
    {
        void Add(Color color);
        void Update(Color color);
        void Delete(Color color);
        List<Color> GetAll();
        Color GetById(int id);
    }
}
