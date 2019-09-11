using System.Collections.Generic;
using System.Linq;
using ZooM.Application.DTO;
using ZooM.Core.Entitites;

namespace ZooM.Infrastructure.Databases.NHibernate.Entities.Extensions
{
    internal static class AreaExtensions
    {
        public static AreaEntity AsEntity(this Area area)
            => new AreaEntity
            {
                AreaNo = area.AreaNo,
                Cages = area.Cages
            };

        public static Area AsArea(this AreaEntity entity)
            => new Area(entity.AreaNo, entity.Cages);

        public static AreaDto AsDto(this AreaEntity entity)
            => new AreaDto
            {
                AreaNo = entity.AreaNo,
                Cages = entity.Cages
            };

        public static IEnumerable<AreaDto> AsDtos(this IEnumerable<AreaEntity> areas)
            => areas.Select(a => a.AsDto());
    }
}
