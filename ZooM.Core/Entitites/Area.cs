using System;
using System.Collections.Generic;
using System.Linq;
using ZooM.Core.Enums;
using ZooM.Core.Exceptions;

namespace ZooM.Core.Entitites
{
    public class Area
    {
        private readonly List<int> _cages;

        public Area(Guid id, AreaType areaType, IEnumerable<int> cages)
        {
            Id = id;
            AreaType = areaType;
            _cages = cages?.ToList() ?? new List<int>();
        }

        public Guid Id { get; }
        public AreaType AreaType { get; }
        public IEnumerable<int> Cages => _cages;

        public void AddCage(int cageNo)
        {
            if (_cages.Contains(cageNo)) throw new DomainException("Klatka z takim numerem już istnieje");
            _cages.Add(cageNo);
        }

        public void RemoveCage(int cageNo)
        {
            if (!_cages.Contains(cageNo)) throw new DomainException("Klatka z takim numerem nie istnieje");
            _cages.Add(cageNo);
        }
    }
}