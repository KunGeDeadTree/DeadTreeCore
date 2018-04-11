namespace DeadTree.Models.DBClass
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class ResultsMappingModel
    {
        [Key]
        [DisplayName("故障原因与元件映射ID")]
        public int RMId { get; set; }

        [Required]
        public int FRId { get; set; }
        public virtual FaultResultsModel FaultResults { get; set; }

        [Required]
        public int CId { get; set; }
        public virtual ComponentModel Component { get; set; }

        [Required]
        [DisplayName("概率")]
        [Range(0,1,ErrorMessage ="概率必须为0~1之间的小数")]
        public double Probability { get; set; }

        public int QId { get; set; }
        public virtual QuestionsModel Questions { get; set; }
    }
}
