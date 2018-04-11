namespace DeadTree.Models.DBClass
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class QuestionsModel
    {
        [Key]
        [DisplayName("问题ID")]
        public int QId { get; set; }

        [DisplayName("包含的故障特征映射")]
        public virtual ICollection<FeaturesMappingModel> FeaturesMappings { get; set; }

        [DisplayName("包含的故障原因映射")]
        public virtual ICollection<ResultsMappingModel> ResultsMappings { get; set; }

        [Required]
        [DisplayName("应对措施")]
        [DataType(DataType.MultilineText)]
        public string Answer { get; set; }

        public int PId { get; set; }
        public virtual ProfessorModel Professor { get; set; }

        public int FNId { get; set; }
        public virtual FaultNameModel FaultName { get; set; }
    }
}
