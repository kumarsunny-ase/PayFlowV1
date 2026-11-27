using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayFlow.Api.Domain
{
    public class Payment
    {
        public Guid Id { get; private set; }
        public string Reference { get; private set; } = string.Empty;
        public string PayerName { get; private set; } = string.Empty;
        public decimal Amount { get; private set; }
        public string Currency { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public PaymentStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        private Payment() {}

        public Payment(string payerName, decimal amount, string currency, string? description)
        {
            Id = Guid.NewGuid();
            Reference = $"PAY--{DateTime.UtcNow:yyyMMdd}--{Guid.NewGuid().ToString("N")[..6].ToUpper()}";
            PayerName = payerName;
            Amount = amount;
            Currency = currency.ToUpperInvariant();
            Description = description;
            Status = PaymentStatus.Pending; // every new payment starts as Pending
            CreatedAt = DateTime.UtcNow;
        }
    }
}