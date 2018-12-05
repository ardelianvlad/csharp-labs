namespace CSharpLabs
{
    public class JournalEntry
    {

        public string CollectionName { get; set; }
        public string Type { get; set; }
        public string StudentInfo { get; set; }


        public JournalEntry()
        {
            CollectionName = string.Empty;
            Type = string.Empty;
        }

        public override string ToString()
        {
            return $"[TeamsJournalEntry: CollectionName={CollectionName}, Type={Type}, StudentInfo={StudentInfo}]";
        }
    }
}
