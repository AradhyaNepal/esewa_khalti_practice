

using EsewaPractice.Model;
using Microsoft.EntityFrameworkCore;

namespace EsewaPractice
{
    public class PaymentDbContext: DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options)
          : base(options)
        {
        }

        public DbSet<ProductMerchantDetails> ProductMerchantDetails { get; set; }

        public DbSet<TransactionStatus> TransactionStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TransactionStatus>()
                .HasOne(b => b.ProductMerchantDetails)
                .WithMany(a => a.TransactionStatuses)
                .HasForeignKey(b => b.ProductId);
        }
 
    }
}
