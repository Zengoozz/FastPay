using Domain.Enums;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        [Required, MaxLength(14)]
        public string NationalId { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        public string MiddleName { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        public string LastName { get; set; } = string.Empty;
        public string FullName => string.Join(" ", new[] { FirstName, MiddleName, LastName }
                                        .Where(n => !string.IsNullOrWhiteSpace(n)));
        [Required, MaxLength(20)]
        public string Username { get; set; } = string.Empty;
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public string Address { get; set; } = string.Empty;
        public string IDCardFrontImageUrl { get; set; } = string.Empty;
        public string IDCardBackImageUrl { get; set; } = string.Empty;
        public string ProfileImageUrl { get; set; } = string.Empty;
        public Money Balance { get; set; } = new Money(0);
        public AccountStatus AccountStatus { get; set; } = AccountStatus.Active;
    }
}
