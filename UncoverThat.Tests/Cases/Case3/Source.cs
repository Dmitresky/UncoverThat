using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncoverThat.Tests.Cases.Case3
{
    public class Source
    {
        public void Main()
        {
            MethodA();
            MethodC();
        }

        public void MethodA()
        {
            MethodB();
        }

        public void MethodB() { }
        
        public void MethodC() { }
    }
}
