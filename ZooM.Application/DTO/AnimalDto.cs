using System;
using ZooM.Core.Enums;

namespace ZooM.Application.DTO
{
    public class AnimalDto
    {
        public Guid Id { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public AnimalType Type { get; set; }
        public decimal Weight { get; set; }
        public int YearOfBirth { get; set; }
        public int AreaNo { get; set; }
        public int CageNo { get; set; }
    }
}
