using System;
using ZooM.Core.Enums;

namespace ZooM.Infrastructure.Databases.NHibernate.Entities
{
    internal class EmployeeEntity :SoftDeletableDbModel<Guid>
    {
        public virtual string Avatar { get; set; }
        public virtual string Name { get; set; }
        public virtual Position Position { get; set; }
        public virtual int YearOfBirth { get; set; }
    }
}
