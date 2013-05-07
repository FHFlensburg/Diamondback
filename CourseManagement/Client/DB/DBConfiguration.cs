﻿using System;
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

        
        private static DiamondbackModelContainer getContext(string dbModelName)
        {
            if (context == null) context = new DiamondbackModelContainer("name="+dbModelName);
            return context;
        }

        public static DiamondbackModelContainer getContext()
        {
           return DBConfiguration.getContext("DiamondbackModelContainer");
        }

        public static void closeContext()
        {
            context.Dispose();
            context = null;
        }
       
     
    }
}
