namespace CSharpLabs
{
    public class Test
    {
        #region Properties
        public string Name
        {
            get;
            set;
        }

        public bool IsPassed
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public Test(string name, bool isPassed)
        {
            Name = name;
            IsPassed = isPassed;
        }

        public Test()
        {
            Name = "Default";
        }
        #endregion

        #region Public methods
        public override string ToString()
        {
            return $"Test: {Name}, passed {IsPassed}.";
        }
        #endregion

    }
}
