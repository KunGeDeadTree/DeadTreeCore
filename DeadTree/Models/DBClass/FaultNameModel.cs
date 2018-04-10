using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeadTree.Models.DBClass
{
    public class FaultNameModel
    {
        [Key]
        [DisplayName("故障名称ID")]
        public int FNId { get; set; }

        DisplayName("故障名称")]
        [Required]
        public string Name { get; set; }
    }
}
