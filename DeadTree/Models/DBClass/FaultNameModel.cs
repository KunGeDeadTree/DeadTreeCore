namespace DeadTree.Models.DBClass
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class FaultNameModel
    {
        [Key]
        [DisplayName("故障名称ID")]
        public int FNId { get; set; }

        [DisplayName("故障名称")]
        [Required]
        public string Name { get; set; }
    }
}
