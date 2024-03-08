using EsewaPractice.Model;
using System.ComponentModel.DataAnnotations;

namespace EsewaPractice.DTO
{
    public class PaymentDetailsResponseDTO
    {
        [Required]
        public KhaltiDetailsDTO Khalti { get; set; }

        [Required]
        public EsewaDetailsDTO Esewa { get; set; }

        static public PaymentDetailsResponseDTO Map(ProductMerchantDetails details) {
            return new () {
                Khalti = new() { 
                    PublicKey=details.KhaltiPublicKey,
                    AmountPaisa=details.AmountRs*100,
                    ProductName=details.Name,
                    ProductUrl= "None",
                },
                Esewa = new() {
                    ClientId=details.EsewaClientId,
                    ClientSecret=details.EsewaClientSecret,
                    AmountRs=details.AmountRs,
                    ProductName=details.Name,
                }
            };
        }


    }

    public class EsewaDetailsDTO {
        [Required]
        public string ClientId { get; set; } = string.Empty;

        [Required]
        public string ClientSecret { get; set; } = string.Empty;

        [Required]
        public int AmountRs { get; set; }

        [Required]
        public string ProductName { get; set; } = string.Empty;
    }

    public class KhaltiDetailsDTO {

        [Required]
        public string PublicKey { get; set; } = string.Empty;

        [Required]
        public int AmountPaisa { get; set; }

        [Required]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        public string ProductUrl { get; set; } = string.Empty;


    }
}


