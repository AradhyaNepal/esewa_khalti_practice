using EsewaPractice.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace EsewaPractice.Controller
{
    [Route("api/v1/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentDbContext _db;
        public PaymentController(PaymentDbContext db)
        {
            _db = db;
        }

        [HttpPost("getPaymentDetailsAndKeys")]
        public IActionResult GetPaymentDetailsAndKeys([FromBody] PaymentDetailsRequestDTO request) {
            var data=_db.ProductMerchantDetails.AsNoTracking().FirstOrDefault(e=>e.Id.ToString()==request.ProductId);
            if (data == null) {
                return Conflict("Item Not Found");
            }
            return Ok(PaymentDetailsResponseDTO.Map(data));
        }

    }
}
