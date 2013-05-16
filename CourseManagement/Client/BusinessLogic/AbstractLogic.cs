﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Client.BusinessLogic
{
    public abstract class AbstractLogic
    {
        public abstract DataTable getAll();
        public abstract DataTable search(string search);
        public abstract DataTable getById(int id);
        public abstract void delete(int id);
        //public int create(mit unterschiedlichen Parametern je nach Entity) --- return ist die jeweilige id
        //public void changeProperties()
        
        //private DataTable getNewTable()
        //private DataRow getNewRow()
    }
}
