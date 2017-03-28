using Contracts;
using System;

namespace SomeDependency
{
    public class Foo : IFoo
    {
        public string DoSomething()
        {
            return "Hello from Foo";
        }
    }
}
