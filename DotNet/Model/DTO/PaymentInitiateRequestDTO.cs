using System.ComponentModel.DataAnnotations;

namespace EsewaPractice.Model.DTO
{
    public class PaymentInitiateRequestDTO
    {
        [Required]
        public required string ProductId { get; set; }

        [Required]
        public required PaymentType PaymentType { get; set; }
    }
}
