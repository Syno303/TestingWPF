using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Models {
    public class EmployeeService {
        private static ObservableCollection<Employee> employeesList;
        private EFContext context = new EFContext();

        public EmployeeService() {
            employeesList = new ObservableCollection<Employee>();
        }

        public ObservableCollection<Employee> GetAll() {
            employeesList = new ObservableCollection<Employee>();

                foreach (var item in context.Employees.OrderBy(e=>e.Id).ToList()) {
                    employeesList.Add(item);
                }
                return employeesList;
            
        }

        public bool Add(Employee employee) {
            employee.Id = context.Employees.Select(x => x.Id).DefaultIfEmpty(0).Max() + 1;
            context.Employees.Add(employee);
            context.SaveChanges();
            return true;
        }

        public bool Update(Employee employee) {
            Employee toModify = context.Employees.FirstOrDefault(e => e.Id == employee.Id);
            if (toModify!=null) {
                toModify.Name = employee.Name;
                toModify.Age = employee.Age;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id) {
            context.Employees.Remove(employeesList.FirstOrDefault(e => e.Id == id));
            context.SaveChanges();
            return true;
        }

        public Employee Search(int id) {
            return context.Employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
