using System;

namespace CSharpLabs
{
    public delegate void StudentListHandler(object source, StudentListHandlerEventArgs args);

    public class StudentListHandlerEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public int Index { get; set; }

        public StudentListHandlerEventArgs()
        {
            Name = string.Empty;
            Info = string.Empty;
            Index = -1;
        }

        public StudentListHandlerEventArgs(string name, string info, int index)
        {
            Name = name;
            Info = info;
            Index = index;
        }

        public override string ToString()
        {
            return "StudentListHandlerEventArgs : { name: " + Name + ", Info: " + Info + ", Info:" + Info + " }";
        }
    }
}
