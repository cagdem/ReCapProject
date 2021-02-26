using Bussiness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        ICarImageService _carImageService;

        public CarImagesController(IWebHostEnvironment webHostEnvironment, ICarImageService carImageService)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpPost("add")]
        public IActionResult Add([FromForm] FileUpload image, [FromForm] CarImage carImage)
        {
            var path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            string imagePath = null;
            if (image.files != null)
            {
                string ext = System.IO.Path.GetExtension(image.files.FileName);
                string name = Guid.NewGuid().ToString();
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream fileStream = System.IO.File.Create(path + name + ext))
                {
                    image.files.CopyTo(fileStream);
                    fileStream.Flush();
                }

                imagePath = path + name + ext;
            }

            var tempCarImage = new CarImage { Id = carImage.Id, CarId = carImage.CarId, ImagePath = imagePath, Date = DateTime.Now };
            var result = _carImageService.Add(tempCarImage);

            if (result.Success)
            {
                return Ok();
            }

            return BadRequest();

        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CarImage carImage)
        {
            var result = _carImageService.Update(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("list")]
        public IActionResult List(int id)
        {
            var result = _carImageService.GetById(id);
            foreach (var image in result.Data)
            {
                if (image.ImagePath == null)
                {
                    image.ImagePath = _webHostEnvironment.WebRootPath + "\\uploads\\default.jpg";
                }
            }
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
