namespace DeadTree.Models.DBClass
{
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
    }
}
