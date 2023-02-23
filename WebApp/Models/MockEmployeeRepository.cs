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
            return  employeeList;
        }

        public Employee GetEmployee(int id)
        {
            Employee employee = employeeList.FirstOrDefault(p=>p.Id == id);
            return employee;
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = employeeList.Max(p => p.Id) + 1;
            employeeList.Add(employee);
            return employee;
        }
    }
}
