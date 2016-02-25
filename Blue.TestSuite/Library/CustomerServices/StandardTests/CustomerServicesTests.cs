using System;
using System.Diagnostics;
using System.Linq;
using Blue.Data.Constants;
using Blue.Data.Models;
using Blue.Library.Exceptions;
using NUnit.Framework;

namespace Blue.TestSuite.Library.CustomerServices.StandardTests
{
    [TestFixture]
    public sealed class CustomerServicesTests
    {
        private Blue.Library.Services.CustomerServices svc; 

        [SetUp]
        public void Setup()
        {
            svc = new Blue.Library.Services.CustomerServices("deadbeef1234");
        }

        [Test]
        public void CustomerServiceAllTest()
        {
            try
            {
                var result = svc.All();
                
                Assert.AreNotEqual(result.Results, null);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("CustomerServiceAllTest: "  +ex.Message);
                Assert.AreEqual(true,false);
            }
        }

        [Test]
        public void CustomerServiceGetTest()
        {
            try
            {
                var result = svc.Get(1);

                Assert.AreNotEqual(result.Results, null);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("CustomerServiceGetTest: " + ex.Message);
                Assert.AreEqual(true, false);
            }
        }

        [Test]
        public void CustomerServicePutTest()
        {
            try
            {
                // Always pass ID to do update, no ID = new record. 

                var id = new Random().Next(1, 99);
                var customer = svc.Get(id).Results?.FirstOrDefault();
                Assert.AreNotEqual(customer, null);

                ((Customer) customer).LastUpdate = BlueConstants.BlueCurrentDate;

                var result = svc.Save(customer);

                Assert.AreEqual(result.Success, true);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("CustomerServicePutTest: " + ex.Message);
                Assert.AreEqual(true, false);
            }
        }


        [Test]
        public void CustomerServicePostTest()
        {
            try
            {
                // Always pass ID to do update, no ID = new record. 
                var result = svc.Save(new Customer
                {
                    Firstname = "John" + new Random().Next(5),
                    Lastname = "Doe" + new Random().Next(5),
                    Address1 = new Random().Next(5,1000) + " Main Street",
                    City = "Anytown",
                    State = "FL", 
                    Email = "john_doe@gmail.com",
                    Phone = "305-555-1212",
                    Zip = "33185",
                    LastUpdate = BlueConstants.BlueCurrentDate
                });

                Assert.AreEqual(result.Success, true);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("CustomerServicePostTest: " + ex.Message);
                Assert.AreEqual(true, false);
            }
        }

        [Test]
        public void CustomerServiceDeleteTest()
        {
            try
            {
                var id = new Random().Next(1, 99);
                var customer = svc.Get(id).Results?.FirstOrDefault();
                Assert.AreNotEqual(customer, null);

                var delete = svc.Delete(id);
                Assert.AreEqual(delete.Success, true);

                customer.ID = 0; // remove ID so it will DAL will create new record. 

                var save = svc.Save(customer);
                Assert.AreEqual(save.Success, true);
            }
            catch (ValidationException vx)
            {
                Debug.WriteLine("CustomerServiceDeleteTest: " + vx.Message);
                Assert.AreEqual(1,1);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("CustomerServiceDeleteTest: " + ex.Message);
                Assert.AreEqual(true, false);
            }
        }
    }
}
