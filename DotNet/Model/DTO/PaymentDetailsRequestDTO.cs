using System.ComponentModel.DataAnnotations;

namespace EsewaPractice.Model.DTO
{
    public class PaymentDetailsRequestDTO
    {
        [Required]
        public string ProductId { get; set; } = string.Empty;
    }
}
