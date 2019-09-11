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
            Property(a => a.AreaNo);
            Property(a => a.CageNo);
        }
    }
}
