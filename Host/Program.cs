using Contracts;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string programAssemblyPath = typeof(Program).GetTypeInfo().Assembly.Location;
            string baseAssemblyPath = Path.GetDirectoryName(programAssemblyPath);
            string pathToAssemblyToLoad = Path.Combine(baseAssemblyPath, "SomeDependency.dll");
            AssemblyLoadContext.Default.LoadFromAssemblyPath(pathToAssemblyToLoad);

            var type = Type.GetType("SomeDependency.Foo, SomeDependency");

            var foo = (IFoo)Activator.CreateInstance(type);

            Console.WriteLine(foo.DoSomething());
        }
    }
}