﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACP.Framework.Dox42Wrapper;

namespace UnitTests.Tests
{
    /// <summary>
    /// Summary description for Dox42ServerTest
    /// </summary>
    [TestClass]
    public class Dox42ServerTest
    {
        public Dox42ServerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [Ignore]
        [TestMethod]
        public void TestMethod1()
        {
            var server = new Dox42Server("http://sviefastboxtsk1:4242/Dox42Service.asmx");

            var outputStrategy = new ReturnOutputStrategy();
            outputStrategy.Format = ReturnOutputStrategy.Dox42ReturnFormat.docx;
            var request = new Dox42Request(outputStrategy, Dox42Request.Dox42Operation.GenerateDocument);
            request.DocTemplate = @"c:\templatepath\document.docx";
            request.AddInputParameters("parameter1", "Testparameter");
            var response = server.ExecuteReport(request);


        }
    }
}
