using System;

namespace ZooM.Infrastructure.Databases
{
    internal abstract class DbModel
    {
        public virtual Guid Id { get; set; }
        public virtual bool IsDeleted { get; protected set; }
    }

    internal abstract class SoftDeletableDbModel<TKey> : DbModel, ISoftDeletable
    {
        void ISoftDeletable.SoftDelete()
            => IsDeleted = true;
    }
}
