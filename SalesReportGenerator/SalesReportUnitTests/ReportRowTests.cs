using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesReportGenerator;

namespace SalesReportTests
{
    [TestClass]
    public class ReportRowTests
    {
        [TestMethod]
        public void GetColumnHeaders()
        {
            var t = new TestClass();

            var expectedColumns = new[] { "MyObject", "ONE", "TWO" };

            var actualColumns = new ReportRow<TestClass>(t).ColumnHeaders.ToArray();

            CollectionAssert.AreEqual(expectedColumns, actualColumns);
        }

        public class TestClass
        {
            [Column("ONE", 1)]
            public string Mystring { get; set; }

            [Column ("TWO")]
            public int MyInt { get; set; }

            [Column(0)]
            public TestClass MyObject { get; set; }

            public int NoColumnHeader { get; set; }

        }
    }
}
