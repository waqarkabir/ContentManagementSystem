using System.Collections.Generic;
using System.Linq;

namespace WebApp.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> employeeList;

        public MockEmployeeRepository()
        {
            employeeList = new List<Employee>()
            {
                new Employee(){ Id =1, Name ="Waqar Kabir", Email = "waqarkabir10@gmail.com", Department = Dept.IT},
                new Employee(){ Id =2, Name ="Ahmed Qureshi", Email = "ahmedqureshi@gmail.com", Department = Dept.Payroll},
                new Employee(){ Id =3, Name ="Imran", Email = "imran@gmail.com", Department = Dept.HR}
            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeList;
        }

        public Employee GetEmployee(int id)
        {
            Employee employee = employeeList.FirstOrDefault(p => p.Id == id);
            return employee;
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = employeeList.Max(p => p.Id) + 1;
            employeeList.Add(employee);
            return employee;
        }

        public Employee UpdateEmployee(Employee employeeChanges)
        {
            Employee employee = employeeList.Find(p => p.Id == employeeChanges.Id);

            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
            }

            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            Employee employee = employeeList.Find(p => p.Id == id);
            if (employee != null)
            {
                employeeList.Remove(employee);
            }

            return employee;
        }
    }
}
