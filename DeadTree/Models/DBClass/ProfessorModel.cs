namespace DeadTree.Models.DBClass
{
    using DeadTree.Models.EnumClass;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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


        [DisplayName("用户密码")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "密码长度必须在8到32之间", MinimumLength = 8)]
        [Required]
        public string Password { get; set; }

        [DisplayName("密码确认")]
        [NotMapped]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "密码长度必须在8到32之间", MinimumLength = 8)]
        public string ConfirmPassword { get; set; }

        [DisplayName("混淆盐")]
        public string Salt { get; set; }

        [Required]
        [DisplayName("专家类别")]
        public EnumAccountType Type { get; set; }
    }
}
