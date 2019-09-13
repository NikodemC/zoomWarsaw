using System;
using ZooM.Core.Enums;

namespace ZooM.Core.Entitites
{
    public class Employee
    {
        public Guid Id { get; }
        public string Avatar { get; private set; }
        public string Name { get; }
        public Position Position { get; private set; }
        public int YearOfBirth { get; }

        public Employee(Guid id, string avatar, string name, Position position, int yearOfBirth)
        {
            Id = id;
            Avatar = avatar;
            Name = name;
            Position = position;
            YearOfBirth = yearOfBirth;
        }

        public void ChangePosition(Position position)
         => Position = position;


        public void ChangeAvatar(string avatar)
            => Avatar = avatar;
    }
}
