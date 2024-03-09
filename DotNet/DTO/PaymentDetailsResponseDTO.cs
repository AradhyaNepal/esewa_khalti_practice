using EsewaPractice.Encryption;
using EsewaPractice.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace EsewaPractice.DTO
{
    /// <summary>
    /// I am putting all of the logic in this DTO layer, 
    /// which might be bad practice to do in .Net, in Flutter its very bad practice.
    /// 
    /// But forgive me, i will refactor it later.
    /// </summary>
    public class PaymentDetailsResponseDTO
    {
        [Required]
        public required string KhaltiEncryptedUsingRSA { get; set; } = string.Empty;

        [Required]
        public required EsewaEncyptedHybridDTO EsewaEncryptedUsingHybrid { get; set; }

        static public PaymentDetailsResponseDTO MapAndEncrypt(ProductMerchantDetails details) {
            //return new () {

            //    EsewaEncrypted = new() {
            //        ClientId=details.EsewaClientId,
            //        ClientSecret=details.EsewaClientSecret,
            //        AmountRs=details.AmountRs,
            //        ProductName=details.Name,
            //    }
            //};

            var khaltiDetails=JsonSerializer.Serialize(new KhaltiDetailsDTO
            {
                PublicKey = details.KhaltiPublicKey,
                AmountPaisa = details.AmountRs * 100,
                ProductName = details.Name,
                ProductUrl = "None",
            });


            return new()
            {
                KhaltiEncryptedUsingRSA = RSAEncryption.EncryptMobile(khaltiDetails),
                EsewaEncryptedUsingHybrid = new()
                {
                    EncryptedValue = "",
                    EncryptionKey = "",
                },
            };
        }


    }

    public class EsewaEncyptedHybridDTO {
        [Required]
        public string EncryptedValue { get; set;} =string.Empty;

        [Required]
        public string EncryptionKey { get;set;} =string.Empty;
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


