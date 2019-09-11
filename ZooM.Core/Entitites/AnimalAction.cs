using System;
using ZooM.Core.Enums;

namespace ZooM.Core.Entitites
{
    public class AnimalAction
    {
        public Guid Id { get; }
        public DateTime TimeOfAction { get; }
        public Guid EmployeeId { get; }
        public ActionType Action { get; }
        public Guid AnimalId { get; }

        public AnimalAction(Guid id, DateTime timeOfAction, Guid employeeId, ActionType action, Guid animalId)
        {
            Id = id;
            TimeOfAction = timeOfAction;
            EmployeeId = employeeId;
            Action = action;
            AnimalId = animalId;
        }
    }
}
