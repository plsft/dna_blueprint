
using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace Blue.TestSuite.Library.Requests.Parts
{
    [TestFixture]
    public class PartAdvancedSearchRequestTests
    {
        [Test]
        public void PartAdvancedSearchRequestTest()
        {
            try
            {
                var pasr = new Blue.Library.Requests.PartAdvancedSearchRequest(0, "s", 1, 1500.0f);
                var view = new Blue.Data.ViewModels.PartsAdvancedSearchView(pasr.Sql);

                Assert.AreNotEqual(pasr.Sql, "");
                Assert.AreNotEqual(view.Results, null);
                Assert.AreNotEqual(view.Results.Count(), 0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("PartAdvancedSearchRequestTest:" + ex.Message);
                Assert.AreEqual(true, false);
            }
        }
    }
}
