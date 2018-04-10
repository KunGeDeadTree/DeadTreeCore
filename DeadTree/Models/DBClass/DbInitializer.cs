using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeadTree.Models.DBClass
{
    public class DbInitializer
    {
        public static void Initialize(DeadTreeContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
