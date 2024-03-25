using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncoverThat.Tests.Cases.MethodA_MethodB
{
    public class Source
    {
        public void Main()
        {
            MethodA();
            MethodB();
        }

        public void MethodA() { }

        public void MethodB() { }
    }
}
