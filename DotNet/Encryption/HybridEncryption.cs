using System.CodeDom;
using System.Security.Cryptography;

namespace EsewaPractice.Encryption
{
    public class HybridEncryption
    {
        static public string EncryptForMobile(string data) {
    
            using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
            {
                aesProvider.KeySize = 256;

                // Generate a new AES key
                aesProvider.GenerateKey();

                // Get the generated key
                byte[] aesKey = aesProvider.Key;

            
            }

        }
    }
}
