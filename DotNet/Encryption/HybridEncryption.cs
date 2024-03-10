using EsewaPractice.Model.DTO;
using System.CodeDom;
using System.Security.Cryptography;
using System.Text;

///THis entire encrypting need to refactor, lots of coupling happening here and code is not testable.
///This codes really needs unit tests.
namespace EsewaPractice.Encryption
{

    public class HybridEncryption
    {

        static public HybridEncryptedResponse HybridEncryptMobile(string data) {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportFromPem(KeysConfigurations.MobilePublicKey);
                var symmetricKey = GenerateAESKey();
                var encryptedData = EncryptString(symmetricKey, data);
                var encryptedDecryptionKey = RSAEncryption.EncryptBytes(symmetricKey,rsa);
                return new()
                {
                    EncryptedData = encryptedData,
                    EncryptedDecryptionKey = Convert.ToBase64String(encryptedDecryptionKey),
                };


            }
         
        }

        // Generate a random AES key
        static public byte[] GenerateAESKey()
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.KeySize = 256;
                aesAlg.GenerateKey();
                return aesAlg.Key;
            }
        }

        // Encrypt a string using AES
        public static string EncryptString(byte[] key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }


        public static string DecryptString(byte[] key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }

}
