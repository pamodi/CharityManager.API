namespace CharityManager.API.Entity
{
    public interface ISupportSoftDelete
    {
        DateTimeOffset? DeletedAt { get; set; }
    }
}
