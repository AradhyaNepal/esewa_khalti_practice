using EsewaPractice.Migrations;
using EsewaPractice.Model;
using EsewaPractice.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

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

            ///Todo: In future also do proper exception handling here,
            ///once you refactor this DTO logic into separate layer.
            return Ok(PaymentDetailsResponseDTO.MapAndEncrypt(data));
        }

        [HttpPost("initiateTransaction")]
        public IActionResult InitiateTransaction([FromBody] PaymentInitiateRequestDTO request)
        {
            var data = _db.ProductMerchantDetails.AsNoTracking().FirstOrDefault(e => e.Id.ToString() == request.ProductId);
            if (data == null)
            {
                return Conflict("Item Not Found");
            }

            var transaction=_db.TransactionStatus.Add(new() {
                ProductId=data.Id,
                Status= StatusType.Initiated,
                PaymentInitiatedAt=DateTime.Now,
                PaymentType=request.PaymentType,
            });
            _db.SaveChanges();

            return Ok(new PaymentInitiateResponseDTO() { TransactionId =transaction.Entity.Id});
        }



    }
}
