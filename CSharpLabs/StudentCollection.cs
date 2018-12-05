using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLabs
{
    public class StudentCollection
    {
        private readonly List<Student> students;

        public StudentCollection()
        {
            students = new List<Student>();
        }

        public StudentCollection(IEnumerable<Student> _students)
        {
            students = new List<Student>(_students);
        }

        public void AddDefaults(int n)
        {
            for (int i=0; i<n; i++)
            {
                students.Add(new Student());
            }
        }

        public void AddStudents(params Student[] _students)
        {
            foreach(Student student in _students)
            {
                students.Add(student);
            }
        }

        public override string ToString()
        {
            string result = "StudentCollection\n";
            foreach (Student student in students)
            {
                result += student.ToString() + "\n";
            }
            return result + "----------------\n";
        }

        public string ToShortString()
        {
            string result = "StudentCollection\n";
            foreach (Student student in students)
            {
                result += student.ToShortString() + "\n";
            }
            return result;
        }

        public void SortByLastName()
        {
            students.Sort();
        }

        public void SortByDateOfBirth()
        {
            students.Sort(new Person());
        }

        public void SortByAvgGrade()
        {
            students.Sort(new StudentComparer());
        }

        public double MaxAveGrade()
        {
            return students.DefaultIfEmpty(new Student()).Max(m => m.AvgGrade);
        }

        public StudentCollection MasterStudents()
        {
            return new StudentCollection( students
               .DefaultIfEmpty(new Student { Education = Education.Master })
               .Where(m => m.Education == Education.Master));
        }
    }
}
