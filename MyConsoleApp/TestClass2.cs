using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    internal class TestClass2
    {
        private readonly ILogger logger;

        public void Test()
        {
            logger?.Debug("In TestClass2/Test");
        }
        public TestClass2(ILogger logger)
        {
            this.logger = logger;
        }
    }
}
