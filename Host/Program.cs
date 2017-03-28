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

            AssemblyLoadContext.Default.Resolving += Default_Resolving;

            var type = Type.GetType("SomeDependency.Foo, SomeDependency");
            var foo = (IFoo)Activator.CreateInstance(type);

            Console.WriteLine(foo.DoSomething());
        }

        private static Assembly Default_Resolving(AssemblyLoadContext context, AssemblyName assemblyName)
        {
            // Should cache this:
            string programAssemblyPath = typeof(Program).GetTypeInfo().Assembly.Location;
            string baseAssemblyPath = Path.GetDirectoryName(programAssemblyPath);

            // no error handling ;-)
            return context.LoadFromAssemblyPath(Path.Combine(baseAssemblyPath, $"{assemblyName.Name}.dll")); // assume assembly file name ends in .dll
        }
    }
}