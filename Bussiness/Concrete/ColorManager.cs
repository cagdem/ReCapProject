﻿using Bussiness.Abstract;
using Bussiness.Constants;
using Bussiness.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            ValidationTool.Validate(new ColorValidator(), color);
            _colorDal.Add(color);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id));
        }

        public IResult Update(Color color)
        {
            ValidationTool.Validate(new ColorValidator(), color);
            _colorDal.Update(color);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
