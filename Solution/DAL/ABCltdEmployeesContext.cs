using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class ABCltdEmployeesContext: DbContext
    {
        public ABCltdEmployeesContext()
            : base("name=ABCltdEmployeesEntities")
        {
        }
        public DbSet<HrDepartment> Departments { get; set; }
        public DbSet<HrEmployee> Employee { get; set; }
    }
}
