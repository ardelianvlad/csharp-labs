using System;

namespace CSharpLabs
{
    class Exam
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
        #endregion

        #region Constructors
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
            return SubjectName + ", grade: " + Grade + ", date: " + DateOfPassing.ToString(Person.DATE_FORMAT);
        }
        #endregion

    }
}
