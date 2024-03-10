using System.ComponentModel.DataAnnotations;

namespace EsewaPractice.Model.DTO
{
    public class RSAEncryptionTestRequestDTO
    {
        [Required]
        public required string EncryptedDetails { get; set; } = string.Empty;
    }
}
