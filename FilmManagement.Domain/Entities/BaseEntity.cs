namespace FilmManagement.Domain.Entities
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsActive { get; set; } = true;

        public BaseEntity()
        {
            Id = default!;
        }

        public BaseEntity(TId id)
        {
            Id = id;
        }
    }
}
