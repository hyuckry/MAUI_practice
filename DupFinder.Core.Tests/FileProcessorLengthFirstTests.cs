using Microsoft.VisualStudio.TestTools.UnitTesting;
using DupFinder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DupFinder.Core.Tests
{
    [TestClass()]
    public class FileProcessorLengthFirstTests
    {
        [TestMethod()]
        public void InitializeTest()
        {
            FileProcessorLengthFirst testLengthFirst = new FileProcessorLengthFirst();
            testLengthFirst.Initialize();

            testLengthFirst.Initialize(null);
            Assert.IsTrue(File.Exists(testLengthFirst.databaseFile));
            testLengthFirst.Dispose();
        }
    }
}