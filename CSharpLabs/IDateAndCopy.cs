using System;

namespace CSharpLabs
{
    public interface IDateAndCopy<T>
    {
        T DeepCopy();
        DateTime Date { get; set; } 
    }
}
