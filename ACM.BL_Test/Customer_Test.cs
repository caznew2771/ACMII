using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;

namespace ACM.BL_Test
{
    [TestClass]
    public class Customer_Test
    {
        [TestMethod]
        public void FullName_Test_Valid()
        {
            // -- Arrange
            Customer customer = new Customer();

            customer.FirstName = "Bilbo";
            customer.LastName = "Baggins";

            string expected = "Baggins, Bilbo";

            // -- Act
            string actual = customer.GetFullName();

            // -- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullName_Test_FirstName_Empty()
        {
            // -- Arrange
            Customer customer = new Customer();

            customer.LastName = "Baggins";

            string expected = "Baggins";

            // -- Act
            string actual = customer.GetFullName();

            // -- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullName_Test_LastName_Empty()
        {
            // -- Arrange
            Customer customer = new Customer();

            customer.FirstName = "Bilbo";

            string expected = "Bilbo";

            // -- Act
            string actual = customer.GetFullName();

            // -- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullName_Test_Both_Empty()
        {
            // -- Arrange
            Customer customer = new Customer();

            string expected = null;

            // -- Act
            string actual = customer.GetFullName();

            // -- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Static_Test()
        {
            // -- Arrange
            var c1 = new Customer();
            c1.FirstName = "Bilbo";
            Customer.InstanceCount += 1;

            var c2 = new Customer();
            c2.FirstName = "Frodo";
            Customer.InstanceCount += 1;

            var c3 = new Customer();
            c3.FirstName = "Rosie";
            Customer.InstanceCount += 1;

            var expected = 3;

            // -- Act
            var actual = Customer.InstanceCount;

            // -- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Validate_Valid_Values()
        {
            // -- Arrange
            var customer = new Customer();

            customer.FirstName = "Frodo";
            customer.LastName = "Baggins";
            customer.EmailAddress = "fbaggins@hobbiton.me";

            var expected = true;

            // -- Act
            var actual = customer.Validate();

            // -- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Validate_Invalid_No_FirstName()
        {
            // -- Arrange
            var customer = new Customer();
            customer.LastName = "Baggins";
            customer.EmailAddress = "fbaggins@hobbiton.me";

            var expected = false;

            // -- Act
            var actual = customer.Validate();

            // -- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Validate_Invalid_No_LastName()
        {
            // -- Arrange
            var customer = new Customer();

            customer.FirstName = "Frodo";
            customer.EmailAddress = "fbaggins@hobbiton.me";

            var expected = false;

            // -- Act
            var actual = customer.Validate();

            // -- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Validate_Invalid_No_Names()
        {
            // -- Arrange
            var customer = new Customer();
            customer.EmailAddress = "fbaggins@hobbiton.me";

            var expected = false;

            // -- Act
            var actual = customer.Validate();

            // -- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
