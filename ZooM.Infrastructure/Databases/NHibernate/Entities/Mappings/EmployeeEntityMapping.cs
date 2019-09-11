using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
using ZooM.Core.Enums;

namespace ZooM.Infrastructure.Databases.NHibernate.Entities.Mappings
{
    internal class EmployeeEntityMapping : ClassMapping<EmployeeEntity>
    {
        public EmployeeEntityMapping()
        {
            Id(e => e.Id);
            Property(e => e.Name);
            Property(e => e.Position, e => e.Type<EnumStringType<Position>>());
            Property(e => e.Avatar);
            Property(e => e.YearOfBirth);
            Property(e => e.IsDeleted, map => {
                map.NotNullable(true);
                map.Type<YesNoType>();
            });
        }
    }
}
