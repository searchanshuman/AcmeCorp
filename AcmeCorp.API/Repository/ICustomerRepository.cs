using AcmeCorp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeCorp.API.Repository
{
    public interface ICustomerRepository
    {
        List<Customers> GetCustomers();

        Customers GetCustomer(int customerId);

        Response AddUpdateCustomer(Customers customer);

        Response DeleteCustomer(int customerId);
    }
}
