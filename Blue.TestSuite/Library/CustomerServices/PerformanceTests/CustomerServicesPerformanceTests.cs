using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace Blue.TestSuite.Library.CustomerServices.PerformanceTests
{
    [TestFixture]
    public class CustomerServicesPerformanceTests
    {

        [Test]
        public void CustomerServiceSelectPerformanceTest_1()
        {
            try
            {
                var sw = Stopwatch.StartNew();
                var select = new Blue.Library.Services.CustomerServices("deadbeef1234").All();
                sw.Stop();

                Assert.AreNotEqual(select.Success,false);
                Assert.AreEqual((sw.ElapsedMilliseconds/1000f) < 4.0f, true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("CustomerServiceSelectPerformanceTest_1:"  + ex.Message);
                Assert.AreEqual(0,1);
            }
        }


        [Test]
        public void CustomerControllerSelectPerformanceTest_1()
        {
            try
            {
                var sw = Stopwatch.StartNew();
                var controller = new Blue.Data.Controllers.ControllerContainer.CustomerController();
                var s = controller.Select("where ID > 45 and ID < 96").Where(c => c.Firstname.Contains("r"));
                
                sw.Stop();

                Assert.AreEqual(s.Any(), true);
                Assert.AreEqual((sw.ElapsedMilliseconds / 1000f) < 4.0f, true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("CustomerServiceSelectPerformanceTest_1:" + ex.Message);
                Assert.AreEqual(0, 1);
            }
        }
    }
}
