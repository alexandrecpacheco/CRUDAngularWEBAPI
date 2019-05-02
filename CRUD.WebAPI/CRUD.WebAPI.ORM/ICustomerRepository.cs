using CRUD.WebAPI.Entities;
using System.Collections.Generic;

namespace CRUD.WebAPI.ORM
{
    public interface ICustomerRepository
    {
        List<Customers> ListCustomers();
        Customers GetCustomers(int id);
        void InsertCustomer(Customers customer);
        void UpdateCustomer(Customers customer);
        void DeleteCustomer(int id);
        bool ValidateCustomer(Customers customer, out string InconsistentField, out string InconsistentDescription);
    }
}
