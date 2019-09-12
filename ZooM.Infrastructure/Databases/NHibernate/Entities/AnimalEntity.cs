using System;
using ZooM.Core.Enums;

namespace ZooM.Infrastructure.Databases.NHibernate.Entities
{
    internal class AnimalEntity : SoftDeletableDbModel<Guid>
    {
        public virtual string Avatar { get; set; }
        public virtual string Name { get; set; }
        public virtual AnimalType Type { get; set; }
        public virtual decimal Weight { get; set; }
        public virtual int YearOfBirth { get; set; }
        public virtual Guid AreaId { get; set; }
        public virtual AreaType AreaType { get; set; }
        public virtual int CageNo { get; set; }
    }
}
