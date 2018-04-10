namespace DeadTree.Models.DBClass
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class FaultMappingModel
    {
        [Key]
        [DisplayName("故障、元件、特征映射ID")]
        public int FMId { get; set; }
    }
}
