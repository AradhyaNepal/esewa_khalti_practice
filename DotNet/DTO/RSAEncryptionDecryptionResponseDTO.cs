namespace EsewaPractice.DTO
{
    public class RSAEncryptionDecryptionResponseDTO
    {
        public string Original { get; set; } = string.Empty;
        public string Encrypted { get; set; } = string.Empty;
        public string Decrypted { get; set; } = string.Empty;
    }
}
