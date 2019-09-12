using System;
using System.Collections.Generic;
using System.Text;
using ZooM.Core.Enums;

namespace ZooM.Infrastructure.Databases.NHibernate.Entities
{
    internal class AreaEntity : SoftDeletableDbModel<Guid>
    {
        public virtual AreaType AreaType { get; set; }
        public virtual IEnumerable<int> Cages { get; set; } = new List<int>();
    }
}
