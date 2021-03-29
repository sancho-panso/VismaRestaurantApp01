using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Entities;
using Restaurant.Service;
using System;
using System.Collections.Generic;
using System.IO;

namespace Restaurant.Test.App
{
    [TestClass]
    public class ValidationServiceTest
    {
       
        [TestMethod]
        public void checkInputValidInt()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader("45");
            Console.SetIn(input);

            var expectedOutput = "Please enter number";

            int result = ValidationService.InputValidInt("Please enter number");

            Assert.AreEqual(expectedOutput, output.ToString());
            Assert.IsInstanceOfType(result, typeof(Int32));
        } 
        [TestMethod]
        public void checkInputValidDouble()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader("45.849");
            Console.SetIn(input);

            var expectedOutput = "It is not expected output";

            double result = ValidationService.InputValidDouble("Please enter number");

            Assert.AreNotEqual(expectedOutput, output.ToString());
            Assert.IsInstanceOfType(result, typeof(Double));
        }
    }
}

