using System.Linq;

namespace DeadTree.Models.DBClass
{
    public class DbInitializer
    {
        public static void Initialize(DeadTreeContext context)
        {
            context.Database.EnsureCreated();

            if (!context.GetApparatusModels.Any())
            {
                context.AddRange(
                    new ApparatusModel()
                    {
                        Name = "立式水轮发电机",
                        Pattern = "型号A",
                        Type = "类别A"
                    }, new ApparatusModel()
                    {
                        Name = "设备二号",
                        Pattern = "型号B",
                        Type = "类别B"
                    }, new ApparatusModel()
                    {
                        Name = "设备三号",
                        Pattern = "型号C",
                        Type = "类别C"
                    }, new ApparatusModel()
                    {
                        Name = "设备四号",
                        Pattern = "型号D",
                        Type = "类别D"
                    });
                context.SaveChanges();
            }

            if (!context.GetProfessorModels.Any())
            {
                context.AddRange(
                    new ProfessorModel()
                    {
                        Name = "专家A",
                        Type = EnumClass.EnumAccountType.专家,

                        PaperworkNumber = "1231546",
                        Password = "12345678",
                        ConfirmPassword = "12345678",
                        Unit = "HIT",
                        Major = "修电脑",
                        Email = "pro1@qq.com",
                        CardNumber = "1554884668",
                        BankName = "建设银行"
                    }, new ProfessorModel()
                    {
                        Name = "专家B",
                        Type = EnumClass.EnumAccountType.专家,

                        PaperworkNumber = "1231546",
                        Password = "12345678",
                        ConfirmPassword = "12345678",
                        Unit = "HIT",
                        Major = "修电脑",
                        Email = "pro2@qq.com",
                        CardNumber = "1554884668",
                        BankName = "建设银行"
                    }, new ProfessorModel()
                    {
                        Name = "专家C",
                        Type = EnumClass.EnumAccountType.专家,

                        PaperworkNumber = "1231546",
                        Password = "12345678",
                        ConfirmPassword = "12345678",
                        Unit = "HIT",
                        Major = "修电脑",
                        Email = "pro3@qq.com",
                        CardNumber = "1554884668",
                        BankName = "建设银行"
                    }, new ProfessorModel()
                    {
                        Name = "专家D",
                        Type = EnumClass.EnumAccountType.专家,
                        PaperworkNumber = "1231546",
                        Password = "12345678",
                        ConfirmPassword = "12345678",
                        Unit = "HIT",
                        Major = "修电脑",
                        Email = "pro4@qq.com",
                        CardNumber = "1554884668",
                        BankName = "建设银行"
                    }, new ProfessorModel()
                    {
                        Name = "管理员",
                        Type = EnumClass.EnumAccountType.超级管理员,
                        PaperworkNumber = "1231546",
                        Password = "12345678",
                        ConfirmPassword = "12345678",
                        Unit = "HIT",
                        Major = "修电脑",
                        Email = "admin@qq.com",
                        CardNumber = "1554884668",
                        BankName = "建设银行"
                    });

                context.SaveChanges();
            }

            if (!context.GetFaultNameModels.Any())
            {
                context.AddRange(
                    new FaultNameModel()
                    {
                        Name = "集电环、电刷高温故障"
                    },
                    new FaultNameModel()
                    {
                        Name = "轮胎漏气"
                    },
                    new FaultNameModel()
                    {
                        Name = "电线短路"
                    });

                context.SaveChanges();
            }

            if (!context.GetComponentModels.Any())
            {
                var app = context.GetApparatusModels.FirstOrDefault(x => x.Name == "立式水轮发电机");
                context.AddRange(
                    new ComponentModel()
                    {
                        Name = "导轴承",
                        Specification = "规格A",
                        Apparatus = app
                    }, new ComponentModel()
                    {
                        Name = "转子",
                        Specification = "规格A",
                        Apparatus = app
                    }, new ComponentModel()
                    {
                        Name = "轴心",
                        Specification = "规格A",
                        Apparatus = app
                    }, new ComponentModel()
                    {
                        Name = "上机架",
                        Specification = "规格A",
                        Apparatus = app
                    });

                context.SaveChanges();
            }

            if (!context.GetFaultFeaturesModels.Any())
            {
                context.AddRange(
                    new FaultFeaturesModel()
                    {
                        Name = "温度"
                    }, new FaultFeaturesModel()
                    {
                        Name = "压力"
                    }, new FaultFeaturesModel()
                    {
                        Name = "功率"
                    }, new FaultFeaturesModel()
                    {
                        Name = "转速"
                    });

                context.SaveChanges();
            }

            if (!context.GetFaultResultsModels.Any())
            {
                context.AddRange(
                    new FaultResultsModel()
                    {
                        Result = "轴线摆度超标"
                    }, new FaultResultsModel()
                    {
                        Result = "接触不良"
                    }, new FaultResultsModel()
                    {
                        Result = "堵塞"
                    }, new FaultResultsModel()
                    {
                        Result = "出现裂纹"
                    });

                context.SaveChanges();
            }
        }
    }
}
