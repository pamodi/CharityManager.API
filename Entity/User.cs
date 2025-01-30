using System.ComponentModel.DataAnnotations;

namespace CharityManager.API.Entity
{
    public class User : BaseModel, ISupportSoftDelete
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }
        [MaxLength(50)]
        public string Role { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(100)]
        public string? PhoneNumber { get; set; }
        [MaxLength(100)]
        public string? WhatsApp { get; set; }
        [MaxLength(200)]
        public string? Address { get; set; }
        public Guid Guid { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
