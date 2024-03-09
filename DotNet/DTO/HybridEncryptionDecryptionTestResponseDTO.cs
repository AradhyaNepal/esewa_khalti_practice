namespace EsewaPractice.DTO
{
    public class HybridEncryptionDecryptionTestResponseDTO
    {
        public string OriginalData { get; set; } = string.Empty;
        public string EncryptedData { get; set; } = string.Empty;
        public string DecryptedData { get; set; } = string.Empty;

        public string OriginalKey { get; set; } = string.Empty;
        public string EncryptedKey { get; set; } = string.Empty;
        public string DecryptedKey { get; set; } = string.Empty;

    }
}
