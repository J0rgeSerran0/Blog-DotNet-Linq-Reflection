namespace Blog_DotNet_Linq_Reflection
{

    using System;
    using System.Linq;
    using System.Reflection;

    public class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Program started");
            Console.WriteLine();

            var assembly = Assembly.Load("FooLibrary");

            var assemblyConstructors = from type in assembly.GetTypes()
                                       from constructors in type.GetConstructors()
                                       group constructors.ToString()
                                       by type.ToString();

            var assemblyMethods = from type in assembly.GetTypes()
                                  from methods in type.GetMethods()
                                  group methods.ToString()
                                  by type.ToString();

            var consoleForegroundColor = Console.ForegroundColor;

            foreach (var constructors in assemblyConstructors)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Type: {0}", constructors.Key);
                Console.ForegroundColor = ConsoleColor.Yellow;

                foreach (var constructor in constructors)
                {
                    Console.WriteLine("\t{0}", constructor);
                }

                var methods = from assemblyMethod in assemblyMethods
                              where assemblyMethod.Key == constructors.Key
                              select assemblyMethod;

                Console.ForegroundColor = ConsoleColor.Cyan;

                foreach (var method in methods)
                {
                    foreach (var type in method)
                    {
                        Console.WriteLine("\t{0}", type);
                    }
                }

                Console.WriteLine();
            }

            Console.ForegroundColor = consoleForegroundColor;

            Console.WriteLine("Press any key to close the App");
            Console.ReadLine();
        }

    }

}