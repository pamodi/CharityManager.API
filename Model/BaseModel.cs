
namespace CharityManager.API.Entity
{
    public class BaseModel
    {
        public DateTimeOffset CreatedAt { get; internal set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }

        public BaseModel()
        {
            this.CreatedAt = DateTimeOffset.UtcNow;
        }
    }
}
