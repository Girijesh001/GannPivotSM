using System;

namespace PivotApplication
{
    public class Person
    {
       

        public string SYMBOL { get; set; }

        public string EXPIRYDATE { get; set; }
        public double HIGH { get; set; }

        public double LOW { get; set; }
        public double CLOSE { get; set; }
        public double VOLUME { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}