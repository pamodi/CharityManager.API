namespace CharityManager.API.Entity
{
    public class User : BaseModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? WhatsApp { get; set; }
        public string? Address { get; set; }
        public Guid Guid { get; set; }
        public string? Description { get; set; }
    }
}
