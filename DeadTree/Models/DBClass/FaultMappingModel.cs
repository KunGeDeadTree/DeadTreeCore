namespace DeadTree.Models.DBClass
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class FaultMappingModel
    {
        [Key]
        [DisplayName("故障、元件、特征映射ID")]
        public int FMId { get; set; }

        [Required]
        public int FNId { get; set; }
        public virtual FaultNameModel FaultName { get; set; }

        [Required]
        public int FFId { get; set; }
        public virtual FaultFeaturesModel FaultFeatures { get; set; }

        [Required]
        public int CId { get; set; }
        public virtual ComponentModel Component { get; set; }
    }
}
