using System.ComponentModel.DataAnnotations;

namespace EsewaPractice.Model
{
    public class ProductMerchantDetails
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required int AmountRs { get; set; }

        [Required]
        public required string EsewaClientId { get; set; }

        [Required]
        public required string EsewaClientSecret { get; set; }

        [Required]
        public required string EsewaSecretKey { get; set; }

        [Required]
        public required string KhaltiPublicKey { get; set; }

        [Required]
        public required string KhaltiPrivateKey { get; set; }

    }
}
