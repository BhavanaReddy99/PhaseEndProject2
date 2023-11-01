using System;
using System.Collections.Generic;
using System.IO;

namespace PhaseEndProject2
{
    

    public class Program
    {
        static void Main(string[] args)
        {
            List<Teacher> teachers = new List<Teacher>();
            Console.WriteLine("Teacher Data Management System ");
            while (true)
            {
               
                Console.Write("1.Add Teacher 2.List Teachers  3.Exit :");
                

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddTeacher(teachers);
                            break;
                        case 2:
                            ListTeachers(teachers);
                            break;
                        case 3:
                            SaveTeacherData(teachers);
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        static void AddTeacher(List<Teacher> teachers)
        {
            Console.Write("Enter ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Class: ");
                string cls = Console.ReadLine();
                Console.Write("Enter Section: ");
                string section = Console.ReadLine();

                Teacher newTeacher = new Teacher
                {
                    ID = id,
                    Name = name,
                    Class = cls,
                    Section = section
                };

                teachers.Add(newTeacher);
                Console.WriteLine("Teacher added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid ID.");
            }
        }

        static void ListTeachers(List<Teacher> teachers)
        {
            if (teachers.Count > 0)
            {
                Console.WriteLine("List of Teachers:");
                foreach (Teacher teacher in teachers)
                {
                    Console.WriteLine($"ID: {teacher.ID}, Name: {teacher.Name}, Class: {teacher.Class}, Section: {teacher.Section}");
                }
            }
            else
            {
                Console.WriteLine("No teacher data available.");
            }
        }

        static void SaveTeacherData(List<Teacher> teachers)
        {
            using (StreamWriter writer = new StreamWriter("teacherdata.txt"))
            {
                foreach (Teacher teacher in teachers)
                {
                    writer.WriteLine($"{teacher.ID},{teacher.Name},{teacher.Class},{teacher.Section}");
                }
            }
            Console.WriteLine("Teacher data saved to teacherdata.txt.");
        }
    } 

}
