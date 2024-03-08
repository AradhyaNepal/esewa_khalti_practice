using System.ComponentModel.DataAnnotations;

namespace EsewaPractice.DTO
{
    public class PaymentDetailsRequestDTO
    {
        [Required]
        public string ProductId { get; set; } = String.Empty;
    }
}
