using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Client.DB.Model;
using System.Data;


namespace CourseManagement.Client.DB
{
    public static class DBConfiguration
    {

        private static DiamondbackModelContainer context = null;

        
        public static DiamondbackModelContainer getContext(string dbModelNameOrConnectionString)
        {
            try
            {
                if (context == null) context = new DiamondbackModelContainer(dbModelNameOrConnectionString);
                return context;
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static DiamondbackModelContainer getContext()
        {
            try
            {
                return DBConfiguration.getContext("name=DiamondbackModelContainer");
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void closeContext()
        {
            try
            {
                context.Dispose();
                context = null;
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
       
     
    }
}
