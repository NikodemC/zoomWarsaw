using System.Collections.Generic;
using System.Linq;
using ZooM.Application.DTO;
using ZooM.Core.Entitites;

namespace ZooM.Infrastructure.Databases.NHibernate.Entities.Extensions
{
    internal static class AnimalActionExtensions
    {
        public static AnimalActionEntity AsEntity(this AnimalAction aa)
            => new AnimalActionEntity
            {
                Id = aa.Id,
                TimeOfAction = aa.TimeOfAction,
                EmployeeId = aa.EmployeeId,
                Action = aa.Action,
                AnimalId = aa.AnimalId
            };

        public static AnimalAction AsAnimalAction(this AnimalActionEntity entity)
            => new AnimalAction(entity.Id, entity.TimeOfAction, entity.EmployeeId, entity.Action, entity.AnimalId);

        public static AnimalActionDto AsDto(this AnimalActionEntity entity)
            => new AnimalActionDto
            {
                Id = entity.Id,
                TimeOfAction = entity.TimeOfAction,
                EmployeeId = entity.EmployeeId,
                Action = entity.Action,
                AnimalId = entity.AnimalId
            };

        public static IEnumerable<AnimalActionDto> AsDtos(this IEnumerable<AnimalActionEntity> aas)
            => aas.Select(a => a.AsDto());
    }
}
