using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLabs
{
    public class Person
    {

        #region Constants
        public const string DATE_FORMAT = "dd/M/yyyy";
        #endregion

        #region Private fields
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        #endregion

        #region Properties
        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set => dateOfBirth = value;
        }

        public int YearOfBirth
        {
            get => dateOfBirth.Year;
            set => dateOfBirth = new DateTime(value, dateOfBirth.Month, dateOfBirth.Day);
        }
        #endregion

        #region Constructors
        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public Person()
        {
            FirstName = "Noname";
            LastName = "Noname";
            DateOfBirth = DateTime.MinValue;
        }
        #endregion

        #region Public methods
        public override string ToString()
        {
            return "Person: " + firstName + " " + lastName + " " + dateOfBirth.ToString(DATE_FORMAT);
        }

        public virtual string ToShortString()
        {
            return firstName + " " + lastName;
        }
        #endregion

    }
}
