using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
using ZooM.Core.Enums;

namespace ZooM.Infrastructure.Databases.NHibernate.Entities.Mappings
{
    internal class AreaEntityMapping : ClassMapping<AreaEntity>
    {
        public AreaEntityMapping()
        {
            Id(a => a.Id);
            Property(a => a.AreaType, a => a.Type<EnumStringType<AreaType>>());
            Property(a => a.IsDeleted, map => {
                map.NotNullable(true);
                map.Type<YesNoType>();
            });
            Bag(x => x.Cages, map =>
            {
                map.Key(k => k.Column("AreaId"));
            });
        }
    }
}
