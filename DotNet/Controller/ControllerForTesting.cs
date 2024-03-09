using EsewaPractice.DTO;
using EsewaPractice.Encryption;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
namespace EsewaPractice.Controller
{
    [Route("api/v1/testings")]
    [ApiController]

    //NOTES : WARNING : MUST READ
    // Do not use Controller for testing, create unit tests.
    //Also create seperate keys for testing, and make sure you are testing in isolation.
   
    
    public class ControllerForTesting : ControllerBase
    {

        [HttpPost("testRSAEncryptionDecryption")]
        public IActionResult TestRSAChunkingEncryptionDecryption()
        {

  

            // Generate RSA key pair
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportFromPem(KeysConfigurations.MobilePublicKey);
                // Simulate a large string to encrypt
                string plaintext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiuectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiussmod tempor incididunt ut labore et dolore magna aliqua.";

                // Encrypt the string
                byte[] encryptedBytes = RSAEncryption.Encrypt(plaintext, rsa);

                // Decrypt the encrypted bytes
                string decryptedText = RSAEncryption.Decrypt(encryptedBytes, KeysConfigurations.MobilePrivatekey);

                return Ok(new EncryptionDecryptionTestResponseDTO()
                {
                    Original = plaintext,
                    Encrypted = Convert.ToBase64String(encryptedBytes),
                    Decrypted = decryptedText,
                    IsSame=plaintext==decryptedText,
                });
                // Display results

            }
        }

        [HttpPost("testAESEncryptionDecryption")]
        public IActionResult TestAESEncryptionDecryption()
        {
            var data = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiuectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiussmod tempor incididunt ut labore et dolore magna aliqua.";
            var key = HybridEncryption.GenerateAESKey();
            var encryptedResponse = HybridEncryption.EncryptString(key,data);
            var decryptedResponse = HybridEncryption.DecryptString(key,encryptedResponse);
            return Ok(new EncryptionDecryptionTestResponseDTO()
            {
                Original = data,
                Encrypted = encryptedResponse,
                Decrypted = decryptedResponse,
                IsSame = data == decryptedResponse,
            });
        }


    


        [HttpPost("testHybridEncryptionDecryption")]
        public IActionResult TestHybridEncryptionDecryption()
        {
            //Server
            var data = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiuectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiussmod tempor incididunt ut labore et dolore magna aliqua.";
            var key = HybridEncryption.GenerateAESKey();
            var keyBase64 = Convert.ToBase64String(key);
            var encryptedResponse = HybridEncryption.EncryptString(key,data);
            var encryptedkey = RSAEncryption.EncryptMobile(keyBase64);

            //Client
            var decryptedKey = RSAEncryption.DecryptByte(Convert.FromBase64String(encryptedkey), KeysConfigurations.MobilePrivatekey);
            var decryptedResponse = HybridEncryption.DecryptString(decryptedKey,encryptedResponse);
            return Ok(new HybridEncryptionDecryptionTestResponseDTO()
            {
                OriginalData = data,
                EncryptedData = encryptedResponse,
                DecryptedData = decryptedResponse,
                OriginalKey= keyBase64,
                EncryptedKey=encryptedkey,
                DecryptedKey= Convert.ToBase64String(decryptedKey),


            });
        }

        [HttpPost("testActualRSAEncryption")]
        public IActionResult TestActualRSAEncryption([FromBody] RSAEncryptionTestRequestDTO request)
        {
            var encrptedValue = Convert.FromBase64String(request.EncryptedDetails);
            var decryptedValue = RSAEncryption.Decrypt(encrptedValue, KeysConfigurations.MobilePrivatekey);
            var decryptedValueJson = JsonSerializer.Deserialize<KhaltiDetailsDTO>(decryptedValue);
            return Ok(new RSAEncryptionTestResponseDTO() { KhaltiDetails = decryptedValueJson });

        }

        [HttpPost("testActualHybridEncryption")]
        public IActionResult TestActualHybridEncryption([FromBody] HybridEncryptedResponse request)
        {
            var encryptedDecryptionKey = Convert.FromBase64String(request.EncryptedDecryptionKey);
            var decryptionKey = RSAEncryption.DecryptByte(encryptedDecryptionKey, KeysConfigurations.MobilePrivatekey);
            Console.WriteLine(ToReadableByteArray(decryptionKey));
            var decryptedData = HybridEncryption.DecryptString(decryptionKey,request.EncryptedData);
            var decryptedValueJson = JsonSerializer.Deserialize<EsewaDetailsDTO>(decryptedData);
            return Ok(decryptedValueJson);

        }
        static public string ToReadableByteArray(byte[] bytes)
        {
            return string.Join(", ", bytes);
        }
    }
}
