using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Models {
    public class EFContext:DbContext {
        public EFContext():base(nameOrConnectionString: "employeeConnection") {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
