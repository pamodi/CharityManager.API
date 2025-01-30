using System.ComponentModel.DataAnnotations;

namespace CharityManager.API.Entity
{
    public class Project : BaseModel, ISupportSoftDelete
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        [MaxLength(100)]
        public string? Status { get; set; }
        [MaxLength(100)]
        public string? Category { get; set; }
        [MaxLength(100)]
        public string? Coordinator { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
