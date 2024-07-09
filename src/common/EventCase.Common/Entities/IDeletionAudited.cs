namespace EventCase.Common.Entities
{
    public interface IDeletionAudited<T>
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletionDatetime { get; set; }
        public T DeletorUser { get; set; }
    }
}
