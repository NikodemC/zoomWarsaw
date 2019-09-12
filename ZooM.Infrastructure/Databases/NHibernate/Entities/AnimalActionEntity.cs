using System;
using System.Collections.Generic;
using System.Text;
using ZooM.Core.Enums;

namespace ZooM.Infrastructure.Databases.NHibernate.Entities
{
    class AnimalActionEntity : SoftDeletableDbModel<Guid>
    {
        public virtual DateTime TimeOfAction { get; set; }
        public virtual Guid EmployeeId { get; set; }
        public virtual ActionType Action { get; set; }
        public virtual Guid AnimalId { get; set; }
    }
}
