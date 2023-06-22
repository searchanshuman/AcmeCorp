using AcmeCorp.API.Controllers;
using AcmeCorp.API.Models;
using AcmeCorp.API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AcmeCorp.Test
{
    public class CustomerControllerUnitTest
    {
        CustomerController _customerController;
        ICustomerRepository _customerRepository;
        AcmeCorpDBContext _dbContext;

        public CustomerControllerUnitTest()
        {
            var dbOption = new DbContextOptionsBuilder<AcmeCorpDBContext>()
                                .UseSqlServer("Data Source=LAPTOP-7PEKSHB4\\SQLEXPRESS; Initial Catalog=AcmeCorpDB; Trusted_Connection=True; Integrated Security=SSPI")
                                .Options;

            _dbContext = new AcmeCorpDBContext(dbOption);
            _customerRepository = new CustomerRepository(_dbContext);
            _customerController = new CustomerController(_customerRepository);
        }


        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _customerController.GetAllCustomers();
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}
