using System.Collections.Generic;

namespace CSharpLabs
{
    public class Journal
    {
        private List<JournalEntry> entryList;

        public Journal()
        {
            entryList = new List<JournalEntry>();
        }

        public void Handler(object source, StudentListHandlerEventArgs args)
        {
            JournalEntry entry = new JournalEntry
            {
                CollectionName = args.Name,
                Type = args.Info,
                StudentInfo = (source as Student).ToShortString()
            };
            entryList.Add(entry);
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (JournalEntry entry in entryList)
            {
                result += "\n" + entry.ToString();
            }
            return "Journal:\n{ " + result + " \n}\n";
        }
    }
}
