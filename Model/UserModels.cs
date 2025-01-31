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
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string Role { get; set; }
        public Guid Guid { get; set; }
        public string? Description { get; set; }
    }

    public class UserCreateRequest : AddressModel
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

    public class AddressModel
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
    }

    public class UserCreateResponse
    {
        public int Id { get; set; }
    }

    public class UserUpdateRequest : UserCreateRequest
    {
    }
}
