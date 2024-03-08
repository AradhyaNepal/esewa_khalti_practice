

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
    }
}
