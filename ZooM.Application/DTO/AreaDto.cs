using System.Collections.Generic;

namespace ZooM.Application.DTO
{
    public class AreaDto
    {
        public int AreaNo { get; set; }
        public IEnumerable<int> Cages { get; set; }
    }
}
