namespace DeadTree.Models.DBClass
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class ProfessorModel
    {
        [Key]
        [DisplayName("专家ID")]
        public int PId { get; set; }

        [DisplayName("专家姓名")]
        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("证件号码")]
        public string PaperworkNumber { get; set; }

        [Required]
        [DisplayName("所属单位")]
        public string Unit { get; set; }

        [Required]
        [DisplayName("专长")]
        public string Major { get; set; }

        [DisplayName("联系电话")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("联系邮件")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("联系微信")]
        public string WeChat { get; set; }

        [Required]
        [DisplayName("银行账号")]
        public string CardNumber { get; set; }

        [Required]
        [DisplayName("开户行")]
        public string BankName { get; set; }

        [DisplayName("回答过的问题")]
        public virtual ICollection<QuestionsModel> Questions { get; set; }
    }
}
