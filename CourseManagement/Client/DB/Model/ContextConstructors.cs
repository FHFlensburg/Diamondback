using System.Data.Entity;

namespace CourseManagement.Client.DB.Model
{
    public partial class DiamondbackModelContainer : DbContext
    {
        public DiamondbackModelContainer(string DBModelContainerNameOrConnectionString)
            : base(DBModelContainerNameOrConnectionString)
        {
        }
    }
}
