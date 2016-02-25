using System;
using System.Diagnostics;

using Blue.Data.Controllers;
using Blue.Data.Models;
using NUnit.Framework;

namespace Blue.TestSuite.Data
{
    [TestFixture]
    public sealed class DataAuditorTests
    {
        /*
        [Test]
        public void DataAuditorTest()
        {
            try
            {
                var action = new Blue.Data.Infra.Auditor.AuditAction
                {
                    Endpoint = "users/edit",
                    Operation = "update",
                    TransactionID = Guid.NewGuid().ToString(),
                    UserId = 1
                };

                var u1 = new ControllerContainer.UserController().Select(1);
                var u2 = new User
                {
                    ID = 1,
                    Password = u1.Password,
                    Email = "george_" + Helix.Utility.General.GenerateRandomCode(3) + "@plsft.com", 
                    Expires = DateTime.Now.AddMonths(new Random().Next(5,11)),
                    Username = "george"
                };

                var result = Blue.Data.Infra.Auditor.Add<User>(action, u1, u2, "created", "id");

                Assert.AreEqual(result, true);

            }
            catch (Exception ex)
            {
                Assert.AreNotEqual(0,1);
                Debug.Write(ex);
            }
        }
    */
    }
}
