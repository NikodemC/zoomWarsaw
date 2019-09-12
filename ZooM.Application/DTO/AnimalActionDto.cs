using System;
using ZooM.Core.Enums;

namespace ZooM.Application.DTO
{
    public class AnimalActionDto
    {
        public Guid Id { get; set; }
        public DateTime TimeOfAction { get; set; }
        public Guid EmployeeId { get; set; }
        public ActionType Action { get; set; }
        public Guid AnimalId { get; set; }
    }
}
