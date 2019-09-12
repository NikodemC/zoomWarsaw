namespace ZooM.Infrastructure.Databases
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; }
        void SoftDelete();
    }
}
