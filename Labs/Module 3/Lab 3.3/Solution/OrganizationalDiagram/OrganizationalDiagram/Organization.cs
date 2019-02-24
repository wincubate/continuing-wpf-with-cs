using System.Collections.Generic;

namespace OrganizationalDiagram
{
    public class Organization
    {
        public string Name { get; }
        public IEnumerable<Department> Departments { get; }

        public Organization()
        {
            Name = "PEACE AND LOVE, INC.";
            Departments = new List<Department>
            {
                new Department("Sales",
                    new Manager("Chatty Charles", "Sales Manager",
                        new Employee("Sweet Sue"),
                        new Employee("Pushy Paul")
                    )
                ),
                new Department("Development",
                    new Manager("Bill Lumbergh", "Development Manager",
                        new Manager("Peter", "Head of Software",
                            new Employee("Samir"),
                            new Employee("Michael Bolton")
                        ),
                        new Employee("Milton ")
                    )
                )
            };
        }
    }

    public class Department
    {
        public string Name { get; }
        public IEnumerable<Manager> InCharge { get; }

        public Department(string name, params Manager[] inCharge) => (Name, InCharge) = (name, inCharge);
    }

    public class Employee
    {
        public string FullName { get; }

        public Employee(string fullName) => FullName = fullName;
    }

    public class Manager : Employee
    {
        public string Title { get; }
        public IEnumerable<Employee> Employees { get; }

        public Manager(string fullName, string title, params Employee[] employees) : base(fullName) => (Title, Employees) = (title, employees);
    }
}