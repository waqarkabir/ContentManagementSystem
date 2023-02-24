using System.Collections.Generic;

namespace WebApp.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAllEmployees();

        Employee AddEmployee(Employee employee);

        Employee UpdateEmployee(Employee employeeChanges);

        Employee DeleteEmployee(int id);
    }
}
