using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using conservatoire.DAL;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLogin()
        {
            Assert.AreEqual(true, LoginDAO.verifLogin("franck.admin", "Udaza777!", LoginDAO.recupJson()));
        }
    }
}
