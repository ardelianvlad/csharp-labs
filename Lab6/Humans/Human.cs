﻿namespace Lab6.Humans
{
    public class Human : IHasName
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string GetName()
        {
            return Name;
        }
    }
}
