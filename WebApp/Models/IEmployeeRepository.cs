using System.Collections.Generic;

namespace WebApp.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAllEmployees();
    }
}
