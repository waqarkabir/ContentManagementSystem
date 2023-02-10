﻿using System.Collections.Generic;
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
                new Employee(){ Id =1, Name ="Waqar Kabir", Email = "waqarkabir10@gmail.com", Department = "Software Development"},
                new Employee(){ Id =2, Name ="Ahmed Qureshi", Email = "ahmedqureshi@gmail.com", Department = "Software Development"},
                new Employee(){ Id =3, Name ="Imran", Email = "imran@gmail.com", Department = "Software Development"}
            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeList;
        }

        public Employee GetEmployee(int id)
        {
            Employee employee = employeeList.FirstOrDefault(p=>p.Id == id);
            return employee;
        }
    }
}
