using System.Collections.Generic;

namespace CSharpLabs
{
    class TestCollection
    {
        private readonly List<Person> persons;
        private readonly List<string> keys;
        private readonly Dictionary<Person, Student> typeDictionary;
        private readonly Dictionary<string, Student> stringDictionary;
        public TestCollection(int count)
        {
            persons = new List<Person>(count);
            keys = new List<string>(count);
            typeDictionary = new Dictionary<Person, Student>(count);
            stringDictionary = new Dictionary<string, Student>(count);
        }
        public static Student[] GenerateStudents(int count)
        {
            var result = new Student[count];
            for (var i = 0; i < count; i++)
            {
                result[i] = new Student();
            }
            return result;
        }
    }
}