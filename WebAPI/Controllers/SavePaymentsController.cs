using Bussiness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavePaymentsController : ControllerBase
    {
        ISavePaymentService _savePaymentService;

        public SavePaymentsController(ISavePaymentService savePaymentService)
        {
            _savePaymentService = savePaymentService;
        }

        [HttpPost("add")]
        public IActionResult Add(SavePayment savePayment)
        {
            var result = _savePaymentService.Add(savePayment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(SavePayment savePayment)
        {
            var result = _savePaymentService.Delete(savePayment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(SavePayment savePayment)
        {
            var result = _savePaymentService.Update(savePayment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _savePaymentService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
