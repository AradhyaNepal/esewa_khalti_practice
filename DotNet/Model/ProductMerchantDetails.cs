using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsewaPractice.Model
{
    public class ProductMerchantDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
