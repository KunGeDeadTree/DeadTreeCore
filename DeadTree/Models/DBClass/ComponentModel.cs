namespace DeadTree.Models.DBClass
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class ComponentModel
    {
        [Key]
        [DisplayName("元件ID")]
        public int CId { get; set; }

        [DisplayName("元件名称")]
        [Required]
        public string Name { get; set; }

        [DisplayName("元件规格")]
        [Required]
        public string Specification { get; set; }

        [DisplayName("故障特征映射信息")]
        public virtual ICollection<FeaturesMappingModel> FeaturesMappings { get; set; }

        [DisplayName("故障原因映射信息")]
        public virtual ICollection<ResultsMappingModel> ResultsMappings { get; set; }

        public int AId { get; set; }
        public virtual ApparatusModel Apparatus { get; set; }
    }
}
