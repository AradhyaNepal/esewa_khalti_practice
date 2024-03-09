using EsewaPractice.DTO;
using System.CodeDom;
using System.Security.Cryptography;

///THis entire encrypting need to refactor, lots of coupling happening here and code is not testable.
///This codes really needs unit tests.
namespace EsewaPractice.Encryption
{
 
    public class HybridEncryption
    {

        static public HybridEncryptedResponse HybridEncryptMobile(String data) {
            var symmetricKey = GenerateAESKey();
            var encryptedData = EncryptStringAES(data, symmetricKey);
            var encryptedDecryptionKey = RSAEncryption.EncryptMobile(Convert.ToBase64String(symmetricKey));
            return new(){
                EncryptedData=encryptedData,
                EncryptedDecryptionKey=encryptedDecryptionKey,
            };
        }

        // Generate a random AES key
        static byte[] GenerateAESKey()
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.GenerateKey();
                return aesAlg.Key;
            }
        }


        // Encrypt a string using AES
        static string EncryptStringAES(string plainText, byte[] key)
        {
            byte[] encrypted;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.Mode = CipherMode.CBC; // Cipher Block Chaining
                aesAlg.Padding = PaddingMode.PKCS7; // Padding for incomplete blocks

                // Create encryptor
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Encrypt the data
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
            return Convert.ToBase64String(encrypted);
        }
    }
}
