namespace DeadTree.Models.DBClass
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class ApparatusModel
    {
        [Key]
        [DisplayName("设备ID")]
        public int AId { get; set; }

        [DisplayName("设备名称")]
        [Required]
        public string Name { get; set; }
    }
}
