using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Models
{
    public class PaymentDetailsDBContext :DbContext
    {
        public PaymentDetailsDBContext(DbContextOptions<PaymentDetailsDBContext> options)
        : base(options)
        {
                
        }

        public DbSet<PaymentDetails> PaymentDetails { get; set; }
    }
}
