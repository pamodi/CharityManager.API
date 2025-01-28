using CharityManager.API.Entity;
using System.ComponentModel.DataAnnotations;

namespace CharityManager.API.Model
{
    public class UserModel : BaseModel
    {
        public int Id { get; set; }
        public string? DisplayName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? WhatsApp { get; set; }
        public string? Address { get; set; }
        public string Role { get; set; }
        public Guid Guid { get; set; }
        public string? Description { get; set; }
    }

    public class UserCreateRequest
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? WhatsApp { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
    }

    public class UserCreateResponse
    {
        public int Id { get; set; }
    }

    public class UserUpdateRequest : UserCreateRequest
    {
    }
}
