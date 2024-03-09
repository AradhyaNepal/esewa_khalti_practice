using EsewaPractice.DTO;
using EsewaPractice.Encryption;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace EsewaPractice.Controller
{
    [Route("api/v1/testings")]
    [ApiController]


    
    public class ControllerForTesting : ControllerBase
    {

        [HttpPost("testEncryptionChunking")]
        public IActionResult TestEncryption()
        {

  

            // Generate RSA key pair
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportFromPem(KeysConfigurations.publicKey);
                // Simulate a large string to encrypt
                string plaintext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiuectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiusectetur adipiscing elit. Sed do eiussmod tempor incididunt ut labore et dolore magna aliqua.";

                // Encrypt the string
                byte[] encryptedBytes = RSAEncryption.Encrypt(plaintext, rsa);

                // Decrypt the encrypted bytes
                string decryptedText = RSAEncryption.Decrypt(encryptedBytes, rsa);

                return Ok(new TestEncryptionResponse()
                {
                    Original = plaintext,
                    Encrypted = Convert.ToBase64String(encryptedBytes),
                    Decrypted = decryptedText,
                });
                // Display results

            }
        }
    }
}
