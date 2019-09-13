using System.Collections.Generic;
using System.Linq;
using ZooM.Application.DTO;
using ZooM.Core.Entitites;

namespace ZooM.Infrastructure.Databases.NHibernate.Entities.Extensions
{
    internal static class AreaExtensions
    {
        public static AreaEntity AsEntity(this Area area)
        {
            return new AreaEntity
            {
                Id = area.Id,
                AreaType = area.AreaType,
                Cages = area.Cages
            };
        }

        public static Area AsArea(this AreaEntity entity)
        {
            return new Area(entity.Id, entity.AreaType, entity.Cages);
        }

        public static AreaDto AsDto(this AreaEntity entity)
        {
            return new AreaDto
            {
                Id = entity.Id,
                AreaType = entity.AreaType,
                Cages = entity.Cages
            };
        }

        public static IEnumerable<AreaDto> AsDtos(this IEnumerable<AreaEntity> areas)
        {
            return areas.Select(a => a.AsDto());
        }
    }
}