namespace DeadTree.Models.DBClass
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class FaultFeaturesModel
    {
        [Key]
        [DisplayName("故障特征ID")]
        public int FFId { get; set; }

        [DisplayName("故障特征名称")]
        [Required]
        public string Name { get; set; }

        [DisplayName("映射信息")]
        public virtual ICollection<FaultMappingModel> FaultMappings { get; set; }
    }
}
