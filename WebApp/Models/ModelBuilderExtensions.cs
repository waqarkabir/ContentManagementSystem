using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 1,
                    Name = "Waqar Kabir",
                    Email = "waqarkabir@hotmail.com",
                    Department = Dept.IT
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Ahmed Qureshi",
                    Email = "mrincognito@gmail.com",
                    Department = Dept.IT
                }
            );
        }
    }
}
