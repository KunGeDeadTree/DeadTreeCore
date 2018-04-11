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
                context.GetApparatusModels.AddRange(
                    new ApparatusModel()
                    {
                        Name = "设备一号",
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

            if (!context.GetFaultFeaturesModels.Any())
            {
                context.GetFaultFeaturesModels.AddRange(
                    new FaultFeaturesModel()
                    {
                        Name = "特征一号"
                    }, new FaultFeaturesModel()
                    {
                        Name = "特征二号"
                    }, new FaultFeaturesModel()
                    {
                        Name = "特征三号"
                    }, new FaultFeaturesModel()
                    {
                        Name = "特征四号"
                    }, new FaultFeaturesModel()
                    {
                        Name = "特征五号"
                    }, new FaultFeaturesModel()
                    {
                        Name = "特征六号"
                    });

                context.SaveChanges();
            }
        }
    }
}
