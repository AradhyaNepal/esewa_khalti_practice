using System.ComponentModel.DataAnnotations;

namespace EsewaPractice.Model.DTO
{
    public class RSAEncryptionTestResponseDTO
    {
        [Required]
        public required KhaltiDetailsDTO? KhaltiDetails { get; set; }
    }
}
