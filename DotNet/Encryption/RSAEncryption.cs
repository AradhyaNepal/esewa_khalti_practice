using System.Security.Cryptography;
using System.Text;


namespace EsewaPractice.Encryption
{
    public class RSAEncryption
    {
        public static byte[] Encrypt(string plaintext, RSA rsa)
        {
            // Get the maximum length of data that can be encrypted with the RSA key
            int maxLength = rsa.KeySize / 8 - 11;

            // Convert the plaintext string to bytes
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);

            // Create a buffer to hold the encrypted chunks
            byte[] encryptedBytes = new byte[0];

            // Encrypt each chunk separately
            for (int i = 0; i < plaintextBytes.Length; i += maxLength)
            {
                int length = Math.Min(maxLength, plaintextBytes.Length - i);
                byte[] chunk = new byte[length];
                Array.Copy(plaintextBytes, i, chunk, 0, length);

                // Encrypt the chunk and append it to the encrypted bytes buffer
                byte[] encryptedChunk = rsa.Encrypt(chunk, RSAEncryptionPadding.Pkcs1);
                encryptedBytes = Combine(encryptedBytes, encryptedChunk);
            }

            return encryptedBytes;
        }


        public static string Decrypt(byte[] encryptedBytes, RSA rsa)
        {
            // Get the maximum length of data that can be decrypted with the RSA key
            int maxLength = rsa.KeySize / 8;

            // Create a buffer to hold the decrypted chunks
            byte[] decryptedBytes = new byte[0];

            // Decrypt each chunk separately
            for (int i = 0; i < encryptedBytes.Length; i += maxLength)
            {
                int length = Math.Min(maxLength, encryptedBytes.Length - i);
                byte[] chunk = new byte[length];
                Array.Copy(encryptedBytes, i, chunk, 0, length);

                // Decrypt the chunk and append it to the decrypted bytes buffer
                byte[] decryptedChunk = rsa.Decrypt(chunk, RSAEncryptionPadding.Pkcs1);
                decryptedBytes = Combine(decryptedBytes, decryptedChunk);
            }

            // Convert the decrypted bytes to a string
            return Encoding.UTF8.GetString(decryptedBytes);
        }

        private static byte[] Combine(byte[] a, byte[] b)
        {
            byte[] result = new byte[a.Length + b.Length];
            Buffer.BlockCopy(a, 0, result, 0, a.Length);
            Buffer.BlockCopy(b, 0, result, a.Length, b.Length);
            return result;
        }

      
    }


}
