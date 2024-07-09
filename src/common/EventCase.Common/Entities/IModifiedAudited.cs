namespace EventCase.Common.Entities
{
    public interface IModifiedAudited<T>
    {
        public T LastModifiedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
