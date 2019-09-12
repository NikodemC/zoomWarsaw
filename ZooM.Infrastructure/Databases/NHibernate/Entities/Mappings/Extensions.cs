using NHibernate.Mapping.ByCode;

namespace ZooM.Infrastructure.Databases.NHibernate.Entities.Mappings
{
    internal static class Extensions
    {
        public static void AddZooMappings(this ModelMapper mapper)
        {
            mapper.AddMapping<AnimalEntityMapping>();
            mapper.AddMapping<AnimalActionEntityMapping>();
            mapper.AddMapping<EmployeeEntityMapping>();
            mapper.AddMapping<AreaEntityMapping>();
        }
    }
}
