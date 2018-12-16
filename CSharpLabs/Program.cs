using System;
using System.IO;

namespace CSharpLabs
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Foo", "Bar", new DateTime(1997, 5, 21));
            Student student = new Student(person, Education.Bachelor, 401);
            Exam ex1 = new Exam("Dot Net", 5, new DateTime(2018, 11, 19));
            Exam ex2 = new Exam("Python", 5, new DateTime(2018, 11, 20));
            Exam ex3 = new Exam("Java", 4, new DateTime(2018, 11, 21));

            student.AddExams(ex1, ex2, ex3);

            Student studCopy = student.DeepCopy();

            Console.WriteLine("Real object");
            Console.WriteLine(student.ToString());
            Console.WriteLine("Copy");
            Console.WriteLine(studCopy.ToString());

            Console.WriteLine("Write file name: ");
            string filename = Console.ReadLine() + ".dat";
            try
            {
                FileStream fileOpen = new FileStream(filename, FileMode.Open, FileAccess.Write, FileShare.Write);
                fileOpen.Close();
                Console.WriteLine(student.Load(filename));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                FileStream file = new FileStream(filename, FileMode.Create);
                file.Close();
            }

            Console.WriteLine("After save");
            Console.WriteLine(student.ToString());

            Console.WriteLine(student.AddFromConsole());
            Console.WriteLine(student.Save(filename));
            Console.WriteLine("Add from console");
            Console.WriteLine(student.ToString());

            Student test = new Student();
            Console.WriteLine(Student.Load(filename, student));
            Console.WriteLine(student.AddFromConsole());
            Console.WriteLine("Add from console and save");
            Console.WriteLine(Student.Save(filename, student));

            Console.WriteLine("After save");
            Console.WriteLine(student.ToString());


            Console.ReadKey();
        }
    }
}