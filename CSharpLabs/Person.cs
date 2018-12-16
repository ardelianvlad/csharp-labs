using System;
using System.Collections.Generic;

namespace CSharpLabs
{
    [Serializable]
    public class Person : IComparable, IComparer<Person>
    {

        #region Constants
        public const string DATE_FORMAT = "dd/M/yyyy";
        #endregion

        #region Private fields
        protected string firstName;
        protected string lastName;
        protected DateTime dateOfBirth;
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

        public DateTime Date
        {
            get;
            set;
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
            return $"Person: {firstName} {lastName}, {dateOfBirth.ToString(DATE_FORMAT)}";
        }

        public virtual string ToShortString()
        {
            return $"{firstName} {lastName}";
        }

        public bool Equals(Person other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return firstName.Equals(other.firstName)
                && lastName.Equals(other.lastName)
                && dateOfBirth.Equals(other.dateOfBirth);
        }

        public override bool Equals(object obj)
        {
            Person other = obj as Person;
            if (other is null)
            {
                return false;
            }
            return Equals(other);
        }

        public override int GetHashCode()
        {
            return firstName.GetHashCode()
                ^ lastName.GetHashCode()
                ^ dateOfBirth.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            return lastName.CompareTo((obj as Person).LastName);
        }

        public int Compare(Person x, Person y)
        {
            return x.dateOfBirth.CompareTo(y.dateOfBirth);
        }
        #endregion

        #region Operators
        public static bool operator ==(Person self, Person other)
        {
            if (self is null)
            {
                return other is null;
            }
            return self.Equals(other);
        }

        public static bool operator !=(Person self, Person other)
        {
            return !(self == other);
        }
        #endregion

    }
}
