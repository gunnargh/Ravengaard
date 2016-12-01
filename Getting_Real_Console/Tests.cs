using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Getting_Real_Console
{
    [TestClass]
    public class Tests
    {

        [TestMethod]
        public void DecodeTest()
        {
            Query SQL = new Query();
            SQL.decodeConnectionString();
            string res = SQL.connectionString;
            Assert.AreEqual("Server=ealdb1.eal.local; Database=ejl72_db; User Id=ejl72_usr; Password=Baz1nga72", res);
        }
        [TestMethod]
        public void TestQuery()
        {
            Query SQL = new Query();
            SQL.QueryMethod("ProductType_Name,ProductType_ID", "ProductType");
            Assert.AreEqual("Necklace", SQL.ProductName);
        }

        [TestMethod]
        public void TestQuery2()
        {
            Query SQL = new Query();
            SQL.QueryMethod("Rock_Name,Rock_ID", "Rock");
            Assert.AreEqual("Saphire", SQL.ProductName);
        }
    }
}
