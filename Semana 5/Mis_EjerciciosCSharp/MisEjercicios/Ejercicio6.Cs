using System;
using System.Collections.Generic;
using System.Linq;

public class Course
{
    public string Name { get; set; }
    public double Grade { get; set; }
    public bool Approved => Grade >= 7.0; // Suponemos 7.0 como nota mínima para aprobar
}

public class CourseManager
{
    private List<Course> courses;

    public CourseManager()
    {
        courses = new List<Course>
        {
            new Course { Name = "Matemáticas" },
            new Course { Name = "Física" },
            new Course { Name = "Química" },
            new Course { Name = "Historia" },
            new Course { Name = "Lengua" }
        };
    }

    public void InputGrades()
    {
        foreach (var course in courses)
        {
            double grade;
            bool isValidInput;
            do
            {
                Console.Write($"Ingrese la nota de {course.Name}: ");
                isValidInput = double.TryParse(Console.ReadLine(), out grade);
                if (!isValidInput || grade < 0 || grade > 10) // Validación de nota entre 0 y 10
                {
                    Console.WriteLine("Por favor, ingrese una nota válida (entre 0 y 10).");
                }
            } while (!isValidInput || grade < 0 || grade > 10);
            course.Grade = grade;
        }
    }

    public void DisplayCoursesToRepeat()
    {
        List<Course> coursesToRepeat = courses.Where(c => !c.Approved).ToList();

        if (coursesToRepeat.Any())
        {
            Console.WriteLine("\nAsignaturas que debe repetir:");
            foreach (var course in coursesToRepeat)
            {
                Console.WriteLine($"- {course.Name} (Nota: {course.Grade})");
            }
        }
        else
        {
            Console.WriteLine("\n¡Felicidades! Ha aprobado todas las asignaturas.");
        }
    }
}

public class Exercise6
{
    public static void Run()
    {
        Console.WriteLine("--- Ejercicio 6: Asignaturas a repetir ---");
        CourseManager manager = new CourseManager();
        manager.InputGrades();
        manager.DisplayCoursesToRepeat();
        Console.WriteLine();
    }
}