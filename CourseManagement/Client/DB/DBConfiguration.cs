using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Client.DB.Model;


namespace CourseManagement.Client.DB
{
    public static class DBConfiguration
    {

        private static DiamondbackModelContainer context = null;

        
        public static DiamondbackModelContainer getContext(string dbModelNameOrConnectionString)
        {
            if (context == null) context = new DiamondbackModelContainer(dbModelNameOrConnectionString);
            return context;
        }

        public static DiamondbackModelContainer getContext()
        {
           return DBConfiguration.getContext("name=DiamondbackModelContainer");
        }

        public static void closeContext()
        {
            context.Dispose();
            context = null;
        }
       
     
    }
}
