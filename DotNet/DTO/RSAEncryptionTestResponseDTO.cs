using System.ComponentModel.DataAnnotations;

namespace EsewaPractice.DTO
{
    public class RSAEncryptionTestResponseDTO
    {
        [Required]
        public required KhaltiDetailsDTO? KhaltiDetails { get; set; }
    }
}
