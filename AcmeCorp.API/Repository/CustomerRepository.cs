using AcmeCorp.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeCorp.API.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        AcmeCorpDBContext _dbContext;

        public CustomerRepository(AcmeCorpDBContext acmeCorpDBContext)
        {
            _dbContext = acmeCorpDBContext;
        }

        public Response AddUpdateCustomer(Customers customer)
        {
            try
            {
                //Add New Contacts
                if (customer.Id == 0)
                {
                    Customers newCustomer = new Customers
                    {
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Email = customer.Email,
                        Phone = customer.Phone,
                        Address = customer.Address,
                        Status = customer.Status,
                    };

                    _dbContext.Customers.Add(newCustomer);
                    _dbContext.SaveChanges();

                    return new Response { Status = "Created", Message = "New customer added successfully" };
                }
                //Update Contacts
                else
                {
                    var curCustomer = _dbContext.Customers.Where(x => x.Id == customer.Id).FirstOrDefault();

                    if (curCustomer != null && curCustomer.Id > 0)
                    {
                        curCustomer.FirstName = customer.FirstName;
                        curCustomer.LastName = customer.LastName;
                        curCustomer.Email = customer.Email;
                        curCustomer.Phone = customer.Phone;
                        curCustomer.Address = customer.Address;
                        curCustomer.Status = customer.Status;

                        _dbContext.SaveChanges();
                        return new Response { Status = "Updated", Message = "Customer updated successfully" };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new Response { Status = "Error", Message = "DB Insert/Update Error" };
        }

        public Response DeleteCustomer(int customerId)
        {
            var curContact = _dbContext.Customers.Where(x => x.Id == customerId).FirstOrDefault();

            if (curContact != null)
            {
                _dbContext.Customers.Remove(curContact);
                _dbContext.SaveChanges();

                return new Response { Status = "Deleted", Message = "Deleted Customer Successfully" };
            }

            return new Response { Status = "Error", Message = "DB Delete Error" };
        }

        public Customers GetCustomer(int contactId)
        {
            var contact = _dbContext.Customers.Where(x => x.Id == contactId).FirstOrDefault();
            return contact;
        }

        public List<Customers> GetCustomers()
        {
            var customers = (
                from c in _dbContext.Customers
                join o in _dbContext.Orders on c.Id equals o.CustomerId into co
                from o in co.DefaultIfEmpty()

                select new Customers
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Phone = c.Phone,
                    Email = c.Email,
                    Address = c.Address,
                    Status = c.Status,
                    Orders = c.Orders
                }).ToList();

            return customers;
        }
    }
}
