using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*Complete every task using Method OR Query syntax.
            HINT: Use the List of Methods defined in the Lecture Material Google Doc
            You may find that Method syntax is easier to use since it is most like C#
            Every one of these can be completed using Linq and then printing with a foreach loop.
            Push to your github when completed!*/  

            //Print the Sum and Average of numbers
            var sum = numbers.Sum();
            Console.WriteLine($"The sum of numbers is: {sum}");

            var average = numbers.Average();
            Console.WriteLine($"The average of numbers is: {average}");

            //Order numbers in ascending order and decsending order. Print each to console.
            var orderNumbers = numbers.OrderBy(num => num);
            Console.WriteLine("\nNumbers in ascending order: ");
            foreach (var num in orderNumbers)
            {
                Console.WriteLine(num);
            }
            orderNumbers = numbers.OrderByDescending(num => num);
            Console.WriteLine("\nNumbers in descending order: ");
            foreach (var num in orderNumbers)
            {
                Console.WriteLine(num);
            }

            //Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(num => num > 6);
            Console.WriteLine("\nNumbers greater than 6: ");
            foreach ( var num in greaterThanSix)
            {
                Console.WriteLine(num);
            }
 
            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var onlyFour = numbers.OrderByDescending(num => num).Take(4);
            Console.WriteLine("\nFour numbers in descending order: ");
            foreach (int num in onlyFour)
            {
                Console.WriteLine(num);
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[3] = 28;
            var age = numbers.OrderByDescending(num => num);
            Console.WriteLine("\nNumbers in descending order with my age: ");
            foreach (var num in age)
            {   
                Console.WriteLine(num);
            }

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var filteredEmployeeNames = employees
                .Where(employee => employee.FirstName.ToLower().StartsWith("c") || employee.FirstName.ToLower().StartsWith("s"))
                .OrderBy(employee => employee.FirstName)
                .Select(employee => employee.FullName);
            Console.WriteLine("\nEmployees in ascending order by first name, whose first name starts with C or S: ");
            foreach ( var FullName in filteredEmployeeNames)
            {
                Console.WriteLine(FullName);
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            var filteredEmployeeAges = employees
                .Where(employee => employee.Age >= 26)
                .OrderBy(employee => employee.Age);
            Console.WriteLine("\nEmployees full name and age who are over age 26: ");
            foreach (var employee in filteredEmployeeAges)
            { 
                Console.WriteLine(employee.FullName + " " + employee.Age);     
            }
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("\nEmployees ordered by age then first name: ");
            foreach (var employee in filteredEmployeeAges)
                Console.WriteLine(employee.Age + " " + employee.FirstName);

            //Print the Sum and then the Average of the employees' YearsOfExperience
            var sumEmployeesYearsOfExperience = employees.Sum(employee => employee.YearsOfExperience);
            Console.WriteLine($"\nSum of employees years of experience: {sumEmployeesYearsOfExperience}");

            var averageEmployeesYearsOfExperience = employees.Average(employee => employee.YearsOfExperience);
            Console.WriteLine($"Average of employees years of experience: {averageEmployeesYearsOfExperience}");

            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var yearsOfExperienceSort = employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age > 35);
            Console.WriteLine();
            foreach (var employee in yearsOfExperienceSort)
            {
                Console.WriteLine($"{employee.FullName} has {employee.YearsOfExperience} years of experience and is {employee.Age} years old.");
            }

            //Add an employee to the end of the list without using employees.Add()
            var addEmployee = employees.Append(new Employee() { FirstName = "Bob", LastName = "Builder", Age = 48, YearsOfExperience = 3});
            Console.WriteLine("\nEmployees list with added new employee: \n");
            foreach (var employee in addEmployee)
            {
                Console.WriteLine($"{employee.FullName}: {employee.Age} years old, {employee.YearsOfExperience} years of experience");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
