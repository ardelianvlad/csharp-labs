using System;

namespace CSharpLabs
{
    [Serializable]
    public class Exam : IDateAndCopy<Exam>
    {

        #region Properties
        public string SubjectName
        {
            get;
            set;
        }

        public int Grade
        {
            get;
            set;
        }

        public DateTime DateOfPassing
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        private Exam() { }

        public Exam(string subjectName, int grade, DateTime dateOfPassing)
        {
            SubjectName = subjectName;
            Grade = grade;
            DateOfPassing = dateOfPassing;
        }
        #endregion

        #region Public methods
        public override string ToString()
        {
            return $"SubjectName: {SubjectName}, grade: {Grade}, date: {DateOfPassing.ToString(Person.DATE_FORMAT)}";
        }

        public bool Equals(Exam other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return SubjectName.Equals(other.SubjectName)
                && Grade.Equals(other.Grade)
                && DateOfPassing.Equals(other.DateOfPassing);
        }

        public override bool Equals(object obj)
        {
            Exam other = obj as Exam;
            if (other is null)
            {
                return false;
            }
            return Equals(other);
        }

        public override int GetHashCode()
        {
            return SubjectName.GetHashCode()
                ^ Grade.GetHashCode()
                ^ DateOfPassing.GetHashCode();
        }

        public Exam DeepCopy()
        {
            return new Exam
            {
                SubjectName = this.SubjectName,
                Grade = this.Grade,
                DateOfPassing = this.DateOfPassing
            };
        }
        #endregion

        #region Operators
        public static bool operator ==(Exam self, Exam other)
        {
            if (self is null)
            {
                return other is null;
            }
            return self.Equals(other);
        }

        public static bool operator !=(Exam self, Exam other)
        {
            return !(self == other);
        }
        #endregion

    }
}
