namespace CharityManager.API.Entity
{
    public class Project : BaseModel, ISupportSoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Category { get; set; }
        public string? Coordinator { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
