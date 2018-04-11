namespace DeadTree.Models.DBClass
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class FaultResultsModel
    {
        [Key]
        [DisplayName("故障原因ID")]
        public int FRId { get; set; }

        [DisplayName("故障原因")]
        public string Result { get; set; }

        [DisplayName("故障原因映射信息")]
        public virtual ICollection<ResultsMappingModel> ResultsMappings { get; set; }
    }
}
