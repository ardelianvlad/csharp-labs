using System;

namespace CSharpLabs
{
    public interface IDateAndCopy
    {
        object DeepCopy();
        DateTime Date { get; set; } 
    }
}
