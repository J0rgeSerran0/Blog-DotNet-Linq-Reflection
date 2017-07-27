namespace FooLibrary
{

    using System;

    public class MyClass
    {

        public string Name { get; set; }
        public int Age { get; set; }

        public MyClass(string name, int age)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("name");

            this.Name = name;
            this.Age = age;
        }

        public string GetMessage()
        {
            return $"Hello {this.Name}";
        }

        public string GetAge()
        {
            return $"{Name}, you are {this.Age} years old";
        }

    }

}