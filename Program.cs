using System.IO.Pipelines;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Security.AccessControl;

public class Employee
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public string Position { get; set; }

    public Employee(string name, string id, string department, string position)
    {
        Id = id;
        Name = name;
        Department = department;
        Position = position;
    }
}


public class Employees
{
    public Employees(List<Employee> listEmployees)
    {
        _listEmployees = listEmployees;
    }

    private List<Employee> _listEmployees;
    
    public Employee FindEmployeeById(string id)
    {
        foreach (Employee person in _listEmployees)
        {   
            if (person.Id==id)
                {
                    return person;
                } 
        }
        return null;
    }
    
    public void AddEmployee(Employee employee)
    {
        _listEmployees.Add(employee);
    }
    
    public void UpdateEmployee(Employee employee)
    {
        var employeeToUpdate = _listEmployees.FirstOrDefault(e => e.Id == employee.Id);
        employeeToUpdate.Name = employee.Name;
        employeeToUpdate.Department = employee.Department;
        employeeToUpdate.Position = employee.Position;
    }
    
    public void RemoveEmployee(string id)
    {
        var employeeToUpdate = _listEmployees.FirstOrDefault(e => e.Id == id);
        
        if (employeeToUpdate != null)
        {
            _listEmployees.Remove(employeeToUpdate);
        }
    }
}

public class Program
{   
    public static void Main()
    {    
        Employee employee1 = new Employee("Сьюзан Майерс","47899","Бухгалтерия","Вице-президент");
        Employee employee2 = new Employee("Боб","12345","Офис","Работник");

        var employees = new List<Employee> {employee1, employee2};

        Console.WriteLine("1. Найти сотрудника по идентификационному номеру");
        Console.WriteLine("2. Добавить нового сотрудника");
        Console.WriteLine("3. Изменить имя, отдел и должность существующего сотрудника");
        Console.WriteLine("4. Удалить сотрудника");
        Console.WriteLine("0. Выйти из программы");


var emploeesList = new Employees(employees);
        var flag = true;
        while (flag)
        {
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Введите идентификационный номер сотрудника");
                    var id = Console.ReadLine();
                    var employee = emploeesList.FindEmployeeById(id);
                    if (employee != null)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}", employee.Name, employee1.Id, employee.Department, employee.Position);
                    }
                    else
                    {
                        Console.WriteLine("Сотрудник не найден");
                    }
                    break;
                case "2":
                    Console.WriteLine("Введите идентификационный номер сотрудника");
                    var idNewEmployee = Console.ReadLine();
                    Console.WriteLine("Введите имя сотрудника");
                    var nameNewEmplyee = Console.ReadLine();
                    Console.WriteLine("Введите отдел сотрудника");
                    var departmentNewEmplyee = Console.ReadLine();
                    Console.WriteLine("Введите должность сотрудника");
                    var positionNewEmplyee = Console.ReadLine();
                    
                    var newEmployee = new Employee(nameNewEmplyee, idNewEmployee, departmentNewEmplyee, positionNewEmplyee);
                    emploeesList.AddEmployee(newEmployee);
                    Console.WriteLine("Сотрудник успешно добавлен");
                    break;
                case "3":
                    Console.WriteLine("Введите идентификационный номер сотрудника");
                    var idUpdateEmployee = Console.ReadLine();
                    
                    var employeeUpdate = emploeesList.FindEmployeeById(idUpdateEmployee);
                    
                    if(employeeUpdate != null)
                    {
                        Console.WriteLine("Введите имя сотрудника");
                        var nameUpdateEmplyee = Console.ReadLine();
                        Console.WriteLine("Введите отдел сотрудника");
                        var departmentUpdateEmplyee = Console.ReadLine();
                        Console.WriteLine("Введите должность сотрудника");
                        var positionUpdateEmplyee = Console.ReadLine();
                        
                        employeeUpdate.Name = nameUpdateEmplyee;
                        employeeUpdate.Department = departmentUpdateEmplyee;
                        employeeUpdate.Position = positionUpdateEmplyee;
                        
                        emploeesList.UpdateEmployee(employeeUpdate);
                    }
                    else
                    {
                        Console.WriteLine("Сотрудник не найден");
                    }
                    break;
                case "4":
                    Console.WriteLine("Введите идентификационный номер сотрудника");
                    var idRemoveEmployee = Console.ReadLine();
                    
                    var employeeRemove = emploeesList.FindEmployeeById(idRemoveEmployee);
                    
                    if(employeeRemove != null)
                    {
                        emploeesList.RemoveEmployee(idRemoveEmployee);
                    }
                    else
                    {
                        Console.WriteLine("Сотрудник не найден");
                    }
                    
                    break;
                case "0":
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Неверное значение");
                    break;
            
            }
        }
    }
}
