using System.ComponentModel.DataAnnotations;

namespace EsewaPractice.DTO
{
    public class HybridEncryptionTestRequestDTO
    {
        [Required]
        static public required string EncryptedData { get; set; }=string.Empty;

        [Required]
        static public required string EncryptedDecryptionData { get; set; }=string.Empty;

    }
}
