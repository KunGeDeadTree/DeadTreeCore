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

        //可修改为枚举
        [DisplayName("设备类别")]
        [Required]
        public string Type { get; set; }

        //可修改为枚举
        [DisplayName("设备型号")]
        [Required]
        public string Pattern { get; set; }

    }
}
