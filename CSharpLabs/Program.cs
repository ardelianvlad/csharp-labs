using System;
using System.Collections.Generic;

namespace CSharpLabs
{
    public class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("Foo", "Bar", new DateTime(1997, 10, 05), Education.Bachelor, 401);
            Student student2 = new Student("Baz", "Qux", new DateTime(1998, 10, 06), Education.Bachelor, 402);
            Student student3 = new Student("John", "Doe", new DateTime(1953, 11, 05), Education.Master, 403);

            StudentCollection studentCollection1 = new StudentCollection();
            StudentCollection studentCollection2 = new StudentCollection();
            studentCollection1.Name = "Collection 1";
            studentCollection2.Name = "Collection 2";

            Journal journal1 = new Journal();
            Journal journal2 = new Journal();

            studentCollection1.StudentCountChanged += journal1.Handler;
            studentCollection1.StudentReferenceChanged += journal1.Handler;

            studentCollection2.StudentCountChanged += journal2.Handler;
            studentCollection2.StudentReferenceChanged += journal2.Handler;

            studentCollection1.AddStudents(student1, student2);
            studentCollection1[0] = student3;

            studentCollection2.AddStudents(student1, student2, student3);
            studentCollection2.Remove(0);

            Console.WriteLine(journal1.ToString());
            Console.WriteLine(journal2.ToString());

            Console.ReadKey();
        }
    }
}