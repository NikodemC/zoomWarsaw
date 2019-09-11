using NHibernate.Mapping.ByCode.Conformist;

namespace ZooM.Infrastructure.Databases.NHibernate.Entities.Mappings
{
    internal class AreaEntityMapping : ClassMapping<AreaEntity>
    {
        public AreaEntityMapping()
        {
            Id(a => a.AreaNo);
            Bag(x => x.Cages, map =>
            {
                map.Key(k => k.Column("AreaNo"));
            });
        }
    }
}
