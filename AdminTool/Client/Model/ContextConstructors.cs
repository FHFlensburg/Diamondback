using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTool.Client.Model
{
    public partial class DiamondbackModelContainer : DbContext
    {
        public DiamondbackModelContainer(string DBModelContainerNameOrConnectionString)
            : base(DBModelContainerNameOrConnectionString)
        {
        }
    }
}
