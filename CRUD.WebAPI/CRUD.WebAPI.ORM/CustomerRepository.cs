using CRUD.WebAPI.DAL;
using CRUD.WebAPI.Entities;
using CRUD.WebAPI.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace CRUD.WebAPI.ORM
{
    /// <summary>
    /// Class Library responsable for basic CRUD functionalities
    /// </summary>
    public class CustomerRepository : IDisposable, ICustomerRepository
    {
        private string[] _keyNames;
        DefaultContext defaultContext = new DefaultContext();

        public Customers GetCustomers(int id)
        {
            Customers customer =
                defaultContext.Set<Customers>().Find(id);
            if (customer == null)
            {
                throw new Exception(
                    "Foi informado um Id de cliente inválido.");
            }
            return customer;
        }

        public void InsertCustomer(Customers customer)
        {
            defaultContext.Set<Customers>().Add(customer);
            defaultContext.SaveChanges();
        }

        public List<Customers> ListCustomers()
        {
            List<Customers> customers =
                defaultContext.Set<Customers>().OrderBy(c => c.Name).ToList();

            return customers;
        }

        public void UpdateCustomer(Customers customer)
        {
            object[] keyValues = this.GetPrimaryKeyValues(customer);
            Customers currentEntity = defaultContext.Set<Customers>()
                .Find(keyValues);
            if (currentEntity == null)
            {
                throw new Exception(String.Format(
                    $"Erro durante a atualização de uma instância do tipo {typeof(Customers).Name}." +
                    " Verifique se o registro correspondente existe na base de dados."
                    ));
            }

            var entry = defaultContext.Entry(currentEntity);
            entry.CurrentValues.SetValues(customer);
            entry.State = System.Data.Entity.EntityState.Modified;

            defaultContext.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            Customers customer = defaultContext.Set<Customers>()
                .Find(id);
            defaultContext.Set<Customers>().Remove(customer);
            defaultContext.SaveChanges();
        }

        private object[] GetPrimaryKeyValues(Customers item)
        {
            var keyNames = GetKeyNames();
            Type type = typeof(Customers);

            object[] keys = new object[keyNames.Length];
            for (int i = 0; i < keyNames.Length; i++)
            {
                keys[i] = type.GetProperty(keyNames[i])
                    .GetValue(item, null);
            }

            return keys;
        }

        private string[] GetKeyNames()
        {
            if (_keyNames == null)
            {
                ObjectSet<Customers> objectSet = ((IObjectContextAdapter)defaultContext)
                                        .ObjectContext.CreateObjectSet<Customers>();
                _keyNames = objectSet.EntitySet.ElementType.
                    KeyMembers.Select(k => k.Name).ToArray();
            }

            return _keyNames;
        }

        public bool CPFAlreadyExists(int id, string cpf)
        {
            var foundCustomers =
                defaultContext.Set<Customers>()
                    .Where(p => p.Id != id &&
                                p.CPF == cpf);
            return (foundCustomers.Count() > 0);
        }

        public bool ValidateCustomer(Customers customer, out string InconsistentField, out string InconsistentDescription)
        {
            InconsistentField = null;
            InconsistentDescription = null;

            if (!Validations.ValidateCPF(customer.CPF))
            {
                InconsistentField = "CPF";
                InconsistentDescription = "CPF inválido.";
                return false;
            }

            if (this.CPFAlreadyExists(customer.Id.HasValue ?
                     customer.Id.Value : 0,
                     customer.CPF))
            {
                InconsistentField = "CPF";
                InconsistentDescription =
                    "CPF já cadastrado anteriormente.";
                return false;
            }

            return true;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
