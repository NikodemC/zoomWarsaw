using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
using ZooM.Core.Enums;

namespace ZooM.Infrastructure.Databases.NHibernate.Entities.Mappings
{
    internal class AnimalEntityMapping : ClassMapping<AnimalEntity>
    {
        public AnimalEntityMapping()
        {
            Id(a => a.Id);
            Property(a => a.Name);
            Property(a => a.Avatar);
            Property(a => a.Type, a => a.Type<EnumStringType<AnimalType>>());
            Property(a => a.Weight);
            Property(a => a.YearOfBirth);
            Property(a => a.AreaId);
            Property(a => a.AreaType, a => a.Type<EnumStringType<AreaType>>());
            Property(a => a.CageNo);
            Property(a => a.IsDeleted, map => {
                map.NotNullable(true);
                map.Type<YesNoType>();
            });
        }
    }
}
