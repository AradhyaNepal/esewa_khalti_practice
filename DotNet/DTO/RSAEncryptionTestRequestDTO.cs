using System.ComponentModel.DataAnnotations;

namespace EsewaPractice.DTO
{
    public class RSAEncryptionTestRequestDTO
    {
        [Required]
        public required string EncryptedDetails { get; set; }=string.Empty;
    }
}
