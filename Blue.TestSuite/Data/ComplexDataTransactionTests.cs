using System;
using System.Collections.Generic;
using System.Diagnostics;
using Blue.Data.Controllers;
using Blue.Data.Models;
using Helix.Infra.Peta;
using NUnit.Framework;

namespace Blue.TestSuite.Data
{
    [TestFixture]
    public sealed class ComplexDataTransactionTests
    {
        [Test]
        public void OrderHeaderSqlTxTest()
        {
            try
            {
                var oh = new OrderHeader
                {
                    Details = new List<OrderDetail>
                    {
                        new OrderDetail
                        {
                            ID = 1,
                            HeaderID = 1,
                            OrderLine = 1,
                            Price = 144.9f
                        },
                        new OrderDetail
                        {
                            ID = 2,
                            HeaderID = 2,
                            OrderLine = 2,
                            Price = 456.9f
                        }
                    }, 
                   // ID = 1, 
                    LastUpdatedOn = DateTime.Now,
                    LastUserID = 4, 
                    TotalChanges = 1 
                };


                var oh2 = new OrderHeader
                {
                    Details = new List<OrderDetail>
                    {
                        new OrderDetail
                        {
                            ID = 1,
                            HeaderID = 1,
                            OrderLine = 1,
                            Price = 974.9f
                        },
                        new OrderDetail
                        {
                            ID = 2,
                            HeaderID = 2,
                            OrderLine = 2,
                            Price = 14.70f
                        }
                    },
                    ID = 1,
                    LastUpdatedOn = DateTime.Now,
                    LastUserID = 8,
                    TotalChanges = 2
                };

                var db = new Database(General.Config.DbConnectionStringName);
                var tx = new Transaction(db);

                try
                {
                    //this will throw an exception 
                    tx.Db.Insert(oh);
                    tx.Db.Insert(oh2);
                    tx.Commit();
                    tx.Complete();
                }
                catch (Exception ex)
                {
                    Debug.Write(ex);
                    Assert.AreEqual(0, 1);
                    tx.Rollback();
                }
                finally
                {
                    tx.Dispose();
                }

            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                Assert.AreEqual(0,1);
            }
        }

        [Test]
        public void GetCompositeObjectKeyTest()
        {
            try
            {
                var oh = new OrderHeader
                {
                    Details = new List<OrderDetail>
                    {
                        new OrderDetail
                        {
                            ID = 1,
                            HeaderID = 1,
                            OrderLine = 1,
                            Price = 144.9f
                        },
                        new OrderDetail
                        {
                            ID = 2,
                            HeaderID = 2,
                            OrderLine = 2,
                            Price = 456.9f
                        }
                    },
                    // ID = 1, 
                    LastUpdatedOn = DateTime.Now,
                    LastUserID = 4,
                    TotalChanges = 1
                };


                var ck = oh.CompositeModelKey;
                var dk = oh.UniqueObjectKey;
                var name = oh.ModelName;
                var pk = oh.PrimaryKeyValue;
                var rowver = oh.RowVer; 

                Assert.AreNotEqual(ck,null);
                Assert.AreNotEqual(name, "");
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                Assert.AreEqual(0, 1);
            }
        }

        [Test]
        public void GetRowVerFromObjectTest()
        {
            try
            {
                var part = new Part
                {
                    ID = 1,
                    ImagePath = "~/test/image.png",
                    Amount = 40053.04f,
                    Borrowed = true,
                    Description = "test descriptions",
                    Status = 1,
                    Title = "test title",
                    LastUpdate = DateTime.Now
                };

                var rowver = part.RowVer; 
                Assert.AreNotEqual(null, rowver);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                Assert.AreEqual(0, 1);
            }
        }

        [Test]
        public void SaveCompositeKeyObjectTest()
        {
            try
            {
                var controller = new ControllerContainer.OrderHeaderController();
                controller.Save(new OrderHeader {
                    ID = 1,
                    LastUpdatedOn = DateTime.Now,
                    LastUserID = 8,
                    TotalChanges = 2
                });
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                var msg = ex.Message;
                Assert.AreNotEqual(1,1);
            }
        }

    }
}
