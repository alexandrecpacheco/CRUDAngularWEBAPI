using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.WebAPI.Entities;
using CRUD.WebAPI.MVC.Controllers;
using CRUD.WebAPI.ORM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRUD.WebAPI.MVC.Tests.Controllers
{
    [TestClass]
    public class CustomersControllerTest
    {
        ICustomerRepository _repository;

        [TestMethod]
        public void Get()
        {
            // Arrange
            CustomersController controller = new CustomersController(_repository);

            //// Act
            List<Customers> result = controller.GetCustomersDetails();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            CustomersController controller = new CustomersController(_repository);
            
            // Act
            var result = controller.GetCustomerDetailsById(2);

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            CustomersController customers = new CustomersController(_repository);
            Customers c = new Customers();
            // Act
            customers.PostCustomerDetails(c);

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            CustomersController customers = new CustomersController(_repository);
            Customers c = new Customers();

            // Act
            customers.PutCustomerDetails(c);

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            CustomersController customers = new CustomersController(_repository);
            
            // Act
            customers.DeleteCustomerDetails(2);

            // Assert
        }

    }
}
