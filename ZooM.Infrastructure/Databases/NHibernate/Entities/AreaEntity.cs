using System;
using System.Collections.Generic;
using System.Text;

namespace ZooM.Infrastructure.Databases.NHibernate.Entities
{
    internal class AreaEntity
    {
        public virtual int AreaNo { get; set; }
        public virtual IEnumerable<int> Cages { get; set; } = new List<int>();
    }
}
