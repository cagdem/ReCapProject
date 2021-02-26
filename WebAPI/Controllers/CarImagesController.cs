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
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";

            if (image.files.Length > 0)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream fileStream = System.IO.File.Create(path + image.files.FileName))
                {
                    image.files.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }
            var tempCarImage = new CarImage { Id= carImage.Id, CarId = carImage.CarId, ImagePath = path, Date = DateTime.Now };
            var result = _carImageService.Add(tempCarImage);
            
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest();

        }
    }
}
