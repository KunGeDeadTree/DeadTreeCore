using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeadTree.Models.DBClass
{
    public class FaultMappingModel
    {
        [Key]
        [DisplayName("故障、元件、特征映射ID")]
        public int FMId { get; set; }
    }
}
