using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Salus.Test
{
    [TestClass]
    public class DriverTest
    {
        private string consoleOutput;

        [TestInitialize]
        public void Initialize()
        {
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Driver.Main(new string[0]);

            this.consoleOutput = stringWriter.GetStringBuilder().ToString().Trim();
        }

        [TestMethod]
        public void HelloWorldTest() 
        {
            Assert.AreEqual("Hello, World!", this.consoleOutput);

        }
    }
}

