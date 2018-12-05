using System;
using System.Collections.Generic;

namespace CSharpLabs
{
    public class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("Ffff_A", "Iaaa_A", DateTime.Now, Education.Bachelor, 401, new List<Exam>()
            {
                new Exam("Math", 5, DateTime.Now),
                new Exam("Phisics", 4, DateTime.Now)
            });
            Student student2 = new Student("Ybdsv_B", "Ohghv_B", DateTime.Now, Education.Master, 501, new List<Exam>()
            {
                new Exam("Math", 3, DateTime.Now),
                new Exam("Phisics", 4, DateTime.Now)
            });

            StudentCollection studentCollection = new StudentCollection();
            studentCollection.AddStudents(student1, student2);

            Console.WriteLine("Unsorted\n" + studentCollection.ToString());
            studentCollection.SortByLastName();
            Console.WriteLine("Sorted by name\n" + studentCollection.ToString());
            studentCollection.SortByDateOfBirth();
            Console.WriteLine("Sorted by date\n" + studentCollection.ToString());
            studentCollection.SortByAvgGrade();
            Console.WriteLine("Sorted by avg grade" + studentCollection.ToString());

            Console.WriteLine("Max\n" + studentCollection.MaxAveGrade());
            Console.WriteLine("Education master\n" + studentCollection.MasterStudents().ToString());

            Console.ReadKey();
        }
    }
}