using System;
using System.Diagnostics;
using Blue.Data.Controllers;
using Blue.Data.Infra;

using NUnit.Framework;

namespace Blue.TestSuite.Data
{
    [TestFixture]
    public sealed class DataLockTests
    {
        [Test]
        public void LockObjectTest()
        {
            try
            {
                var pc = new ControllerContainer.PartController();
                var part = pc.Select(1);

                var dl = new DataLocker("deadbeef", 1);
                dl.Add(part);

                part.Amount = 4040.00f;
                part.LastUpdate = DateTime.Now; 

                var same = dl.Validate(part);

                Assert.AreNotEqual(same,false);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(0,1);
                Debug.Write(ex);
            }

        }
    }
}
