using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
using ZooM.Core.Enums;

namespace ZooM.Infrastructure.Databases.NHibernate.Entities.Mappings
{
    internal class AnimalActionEntityMapping : ClassMapping<AnimalActionEntity>
    {
        public AnimalActionEntityMapping()
        {
            Id(aa => aa.Id);
            Property(aa => aa.Action, aa => aa.Type<EnumStringType<ActionType>>());
            Property(aa => aa.TimeOfAction, map => map.Type<DateTimeType>());
            Property(aa => aa.AnimalId);
            Property(aa => aa.EmployeeId);
            Property(aa => aa.IsDeleted, map =>
            {
                map.NotNullable(true);
                map.Type<YesNoType>();
            });
        }
    }
}
