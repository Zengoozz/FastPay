using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d)
            );

            builder.Property(u => u.DateOfBirth)
                   .HasConversion(dateOnlyConverter);

            builder.OwnsOne(u => u.Balance, money =>
            {
                money.Property(m => m.Amount)
                     .HasColumnType("decimal(18,2)");
                money.Property(m => m.Currency)
                     .HasMaxLength(3)
                     .IsRequired();
            });
        }
    }
}
