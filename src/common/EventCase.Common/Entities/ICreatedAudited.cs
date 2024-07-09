namespace EventCase.Common.Entities
{
    public interface ICreatedAudited<T>
    {
        public DateTime CreateTime { get; set; }
        public T CreatorUser { get; set; }
    }
}
