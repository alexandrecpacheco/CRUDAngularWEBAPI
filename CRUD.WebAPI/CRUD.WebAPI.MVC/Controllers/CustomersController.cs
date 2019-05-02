using CRUD.WebAPI.Entities;
using CRUD.WebAPI.ORM;
using CRUD.WebAPI.Utils;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace CRUD.WebAPI.MVC.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        #region Repository
        ICustomerRepository _repository;

        public CustomersController(ICustomerRepository repository)
        {
            _repository = repository;
        }
        #endregion

        /// <summary>
        /// Get all customer details
        /// </summary>
        /// <returns>Returns all customer details</returns>
        [HttpGet]
        [Route("GetCustomersDetails")]
        public List<Customers> GetCustomersDetails()
        {
            try
            {
                return _repository.ListCustomers();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get specific customer detail by id
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <returns>Returns object customer by id</returns>
        [HttpGet]
        [Route("GetCustomerDetailsById/{customerId}")]
        public IHttpActionResult GetCustomerDetailsById(int customerId)
        {
            Customers customers = new Customers();

            int ID = Convert.ToInt32(customerId);
            try
            {
                customers = _repository.GetCustomers(customerId);
                if (customers == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                throw;
            }

            return Ok(customers);
        }

        /// <summary>
        /// Insert the customer in the database
        /// </summary>
        /// <param name="customer">Customer object</param>
        /// <returns>Returns object Customer</returns>
        [HttpPost]
        [Route("InsertCustomerDetails")]
        public IHttpActionResult PostCustomerDetails(Customers customer)
        {
            string CampoInconsistente = null;
            string DescricaoInconsistencia = null;

            if (!ModelState.IsValid && !_repository.ValidateCustomer(customer, out CampoInconsistente, out DescricaoInconsistencia))
            {
                ModelState.AddModelError(CampoInconsistente,
                    DescricaoInconsistencia);

                return BadRequest(ModelState);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (customer.Birthday != null)
                        customer.Age = CalculateAGe.CalculateAge(customer.Birthday);

                    _repository.InsertCustomer(customer);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return Ok(customer);
        }

        /// <summary>
        /// Update Customer Details by object
        /// </summary>
        /// <param name="customer">Customer object</param>
        /// <returns>Returns customer object</returns>
        [HttpPut]
        [Route("UpdateCustomerDetails")]
        public IHttpActionResult PutCustomerDetails(Customers customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                customer.Age = CalculateAGe.CalculateAge(customer.Birthday);
                _repository.UpdateCustomer(customer);
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(customer);
        }

        /// <summary>
        /// Delete the specific customer by id
        /// </summary>
        /// <param name="id">Customer id</param>
        /// <returns>Customer object</returns>
        [HttpDelete]
        [Route("DeleteCustomerDetails")]
        public IHttpActionResult DeleteCustomerDetails(int id)
        {
            Customers customers = new Customers();

            if (customers == null)
            {
                return NotFound();
            }

            _repository.DeleteCustomer(id);

            return Ok(customers);
        }

    }
}
