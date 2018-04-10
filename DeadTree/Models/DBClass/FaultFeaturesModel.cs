using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeadTree.Models.DBClass
{
    public class FaultFeaturesModel
    {
        [Key]
        [DisplayName("故障特征ID")]
        public int FFId { get; set; }

        [DisplayName("故障特征名称")]
        [Required]
        public string Name { get; set; }
    }
}
