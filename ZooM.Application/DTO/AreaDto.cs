using System;
using System.Collections.Generic;
using ZooM.Core.Enums;

namespace ZooM.Application.DTO
{
    public class AreaDto
    {
        public Guid Id { get; set; }
        public AreaType AreaType { get; set; }
        public IEnumerable<int> Cages { get; set; }
    }
}
