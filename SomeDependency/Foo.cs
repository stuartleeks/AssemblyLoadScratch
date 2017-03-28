using ChildDependency;
using Contracts;
using System;

namespace SomeDependency
{
    public class Foo : IFoo
    {
        public string DoSomething()
        {
            var bar = new Bar();
            return "Hello from Foo and "  + bar.DoSomething();
        }
    }
}
