namespace DeadTree.Models.DBClass
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class ComponentModel
    {
        [Key]
        [DisplayName("元件ID")]
        public int CId { get; set; }
    }
}
