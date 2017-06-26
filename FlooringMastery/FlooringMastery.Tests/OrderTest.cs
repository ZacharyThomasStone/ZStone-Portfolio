using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringMaster.BLL;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Tests
{
    [TestFixture]
    public class OrderTest
    {
        [Test]
        public void CanLoadOrderTestData()
        {
            OrderManager manager = OrderManagerFactory.Create();

            OrderLookupResponse response = manager.LookupOrder(12345,new DateTime(2017, 1, 18));

            Assert.IsNotNull(response.Order);

            Assert.IsTrue(response.Success);

            Assert.AreEqual(12345, response.Order.OrderNumber);
        }
    }
}
