namespace DeadTree.Models.DBClass
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class FeaturesMappingModel
    {
        [Key]
        [DisplayName("故障特征与元件映射ID")]
        public int FMId { get; set; }

        [Required]
        public int FFId { get; set; }
        public virtual FaultFeaturesModel FaultFeatures { get; set; }

        [Required]
        public int CId { get; set; }
        public virtual ComponentModel Component { get; set; }

        [Required]
        [DisplayName("描述")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int QId { get; set; }
        public virtual QuestionsModel Questions { get; set; }
    }
}
