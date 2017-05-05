using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACP.Framework.Dox42Wrapper;

namespace UnitTests.Tests
{
    [TestClass]
    public class ReturnDox42RequestTest
    {
        [TestMethod]
        public void ReturnOutputStrategy_Create()
        {
            var request = new ReturnOutputStrategy();
            request.Format = ReturnOutputStrategy.Dox42ReturnFormat.docx;

            var svcMsg = new Dox42.GeneratorServiceMsg();

            request.FillOutputRequestParmaeter(svcMsg);

            Assert.AreEqual(svcMsg.PostGenActions.Length, 1);
            Assert.AreEqual(svcMsg.PostGenActions[0].Params.Length, 1);
            Assert.AreEqual(svcMsg.PostGenActions[0].ActionName, "ReturnAction");
            Assert.AreEqual(svcMsg.PostGenActions[0].Params[0].ParamName, "Format");
            Assert.AreEqual(svcMsg.PostGenActions[0].Params[0].Value, "docx");


        }
    }
}
