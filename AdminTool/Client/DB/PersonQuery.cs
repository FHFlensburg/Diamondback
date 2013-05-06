using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminTool.Client.DB.Model_EF;


namespace AdminTool.Client.DB
{
    public static class PersonQuery
    {
        /// <summary>
        /// 
        /// Returns a list of all persons in the database.
        /// </summary>
        /// <returns></returns>
        public static List<Person> getAll()
        {
            return DBConfiguration.getContext().Persons.ToList();
        }

        public static Person getById(int personNr)
        {
            return DBConfiguration.getContext().Persons.Find(personNr);
        }

        
        
    }
}
