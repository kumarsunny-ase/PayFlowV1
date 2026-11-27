using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayFlow.Api.Domain;

namespace PayFlow.Api.Data.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p=> p.Id);
            builder.Property(p=> p.Reference).IsRequired().HasMaxLength(30);
            builder.HasIndex(p=> p.Reference).IsUnique();

            builder.Property(p=> p.PayerName).IsRequired().HasMaxLength(100);
            builder.Property(p=> p.Amount).HasPrecision(18, 2);
            builder.Property(p=> p.Currency).IsRequired().HasMaxLength(3);
            builder.Property(p=> p.Description).HasMaxLength(250);

            builder.Property(p=> p.Status)
            .HasConversion<string>() // store "Pending" instead of 0 in the database
            .HasMaxLength(20);

            // Seed data: a few payments so the app isn't empty
            builder.HasData(
                new
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Reference = "PAY-20261101-SEED01",
                    PayerName = "Anna Schmidt",
                    Amount = 149.99m,
                    Currency = "EUR",
                    Description = "Invoice 1001",
                    Status = PaymentStatus.Completed,
                    CreatedAt = new DateTime(2026, 11, 1, 9, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = (DateTime?)new DateTime(2026, 11, 1, 9, 5, 0, DateTimeKind.Utc)
                },
                new
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Reference = "PAY-20261102-SEED02",
                    PayerName = "Max Müller",
                    Amount = 89.50m,
                    Currency = "EUR",
                    Description = "Subscription November",
                    Status = PaymentStatus.Pending,
                    CreatedAt = new DateTime(2026, 11, 2, 14, 30, 0, DateTimeKind.Utc),
                    UpdatedAt = (DateTime?)null
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Reference = "PAY-20261103-SEED03",
                    PayerName = "Lena Weber",
                    Amount = 1200.00m,
                    Currency = "EUR",
                    Description = "Laptop order",
                    Status = PaymentStatus.Failed,
                    CreatedAt = new DateTime(2026, 11, 3, 11, 15, 0, DateTimeKind.Utc),
                    UpdatedAt = (DateTime?)new DateTime(2026, 11, 3, 11, 16, 0, DateTimeKind.Utc)
                }
            );

        }
    }
}