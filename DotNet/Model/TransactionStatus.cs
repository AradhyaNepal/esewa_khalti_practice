using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EsewaPractice.Model
{
    public enum StatusType
    {
        Initiated,
        Completed,
    }

    public enum PaymentType
    {
        Esewa,
        Khalti,
    }
    public class TransactionStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public required int ProductId { get; set; }

        public ProductMerchantDetails ProductMerchantDetails { get; set; }

        public required StatusType Status { get; set; }

        public required DateTime PaymentInitiatedAt { get; set; }
        public DateTime? PaymentCompletedAt {get;set;}
        
        public required PaymentType PaymentType { get; set; }

        public string? VerificationLog { get; set; }


        public string? ConfirmationLog { get; set; }

    }
}
