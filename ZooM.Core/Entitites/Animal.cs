using System;
using ZooM.Core.Enums;

namespace ZooM.Core.Entitites
{
    public class Animal
    {
        public Guid Id { get; }
        public string Avatar { get; private set; }
        public string Name { get; }
        public AnimalType Type { get; }
        public decimal Weight { get; private set; }
        public int YearOfBirth { get; }
        public Guid AreaId { get; private set; }
        public AreaType AreaType { get; private set; }
        public int CageNo { get; private set; }

        public Animal(Guid id, string avatar, string name, AnimalType type, decimal weight, int yearOfBirth, Guid areaId, AreaType areaType, int cageNo)
        {
            Id = id;
            Avatar = avatar;
            Name = name;
            Type = type;
            Weight = weight;
            YearOfBirth = yearOfBirth;
            AreaId = areaId;
            AreaType = areaType;
            CageNo = cageNo;
        }

        public void ChangeWeight(decimal weight)
            => Weight = weight;

        public void ChangeAvatar(string avatar)
            => Avatar = avatar;

        public void ChangeCage(Guid areaId, AreaType areaType, int cageNo)
        {
            AreaId = areaId;
            AreaType = areaType;
            CageNo = cageNo;
        }
    }
}
