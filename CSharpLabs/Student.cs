using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSharpLabs
{
    [Serializable]
    public class Student : Person, IDateAndCopy<Student>
    {
        #region Fields
        private int group;
        #endregion

        #region Properties
        public Person Person
        {
            get => new Person(firstName, lastName, dateOfBirth);
            set
            {
                FirstName = value.FirstName;
                LastName = value.LastName;
                DateOfBirth = value.DateOfBirth;
            }
        }

        public Education Education{ get; set; }

        public int Group
        {
            get => group;
            set
            {
                if (value <= 100 || value > 699)
                {
                    throw new ArgumentException("Number of group must be between 101 and 699, included.");
                }
                else
                {
                    group = value;
                }
            }
        }

        public List<Exam> Exams { get; set; }

        public List<Test> Tests { get; set; }

        public double AvgGrade
        {
            get => Exams != null
                ? Exams.Cast<Exam>().Average(exam => exam.Grade)
                : 0;
        }

        public IEnumerable ExamsAndTests
        {
            get
            {
                ArrayList examsAndTests = new ArrayList { Exams };
                examsAndTests.AddRange(Tests);
                return examsAndTests.Cast<object>();
            }
        }

        public bool this[Education toCompare]
        {
            get => Education == toCompare;
        }
        #endregion

        #region Constructors

        public Student() : base()
        {
            Group = 101;
        }

        public Student(string firstName, string lastName, DateTime dateOfBirth,
            Education education, int group)
            : base(firstName, lastName, dateOfBirth)
        {
            Education = education;
            Group = group;
        }

        public Student(Person person, Education education, int group)
            : base(person.FirstName, person.LastName, person.DateOfBirth)
        {
            Education = education;
            Group = group;
        }
        #endregion

        #region Public methods
        public void AddExams(params Exam[] newExams)
        {
            if (Exams != null && Exams.Count != 0)
            {
                Exams.AddRange(newExams);
            }
            else
            {
                Exams = new List<Exam>(newExams);
            }
        }

        public void AddTests(params Test[] tests)
        {
            if (Tests == null)
            {
                Tests = new List<Test>(tests);
            }
            else
            {
                Tests.AddRange(tests);
            }
        }

        public override string ToString()
        {
            string result = "Person: " + base.ToString() + "\n"
                + Education.ToString() + ", " + Group.ToString() + " group\nExams: ";
            if (Exams != null)
            {
                result += string.Join<Exam>("\n", Exams.Cast<Exam>());
            }
            else
            {
                result += "none";
            }
            result += "\n, Tests:";
            if (Tests != null)
            {
                result += string.Join<Test>("\n", Tests.Cast<Test>());
            }
            else
            {
                result += "none";
            }
            return result;
        }

        public override string ToShortString()
        {
            return "Student: " + base.ToShortString() + ", "
                + Education.ToString() + ", " + Group.ToString() + " group, "
                + "average grade: " + AvgGrade.ToString();
        }

        public Student DeepCopy()
        {
            Student result;
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Position = 0;
                result = formatter.Deserialize(stream) as Student;
            }
            return result;
        }

        public IEnumerable GetExamsGraterThan(double compare)
        {
            return Exams.Cast<Exam>().Where(exam => exam.Grade > compare);
        }

        public IEnumerable<Exam> GetExamsByName(string name)
        {
            foreach (var o in Exams)
            {
                var article = o as Exam;
                if (article == null || !article.SubjectName.Contains(name))
                {
                    continue;
                }
                yield return article;
            }
        }

        public bool Save(string fileName)
        {
            using (var stream = File.Open(fileName, FileMode.Create))
            {
                try
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Load(string fileName)
        {
            using (var stream = File.Open(fileName, FileMode.Open))
            {
                try
                {
                    var formatter = new BinaryFormatter();
                    var result = formatter.Deserialize(stream) as Student;
                    if (result == null)
                    {
                        return false;
                    }
                    Person = result.Person;
                    Education = result.Education;
                    Group = result.Group;
                    Exams = result.Exams;
                    Tests = result.Tests;
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool AddFromConsole()
        {
            try
            {
                Console.WriteLine($"String format:{Environment.NewLine}" +
                    "<string:subject_name>;<int:grade>;<dd.mm.yyyy:date>");
                var input = Console.ReadLine().Split(';');
                if (input.Length != 3)
                {
                    return false;
                }
                var date = DateTime.ParseExact(input[2], "dd.mm.yyyy", CultureInfo.InvariantCulture);
                var grade = int.Parse(input[1], CultureInfo.InvariantCulture);
                var exam = new Exam(input[0], grade, date);
                Exams.Add(exam);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Save(string fileName, Student magazine)
        {
            return magazine.Save(fileName);
        }

        public static bool Load(string fileName, Student magazine)
        {
            return magazine.Load(fileName);
        }
        #endregion

    }
}
