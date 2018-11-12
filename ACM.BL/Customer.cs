using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    interface ICustomer
    {
        string LastName { get; set; }
        string FirstName { get; set; }
        string EmailAddress { get; set; }
        int CustomerId { get; set; }
        string Fullname { get; }

        bool Validate();
        Customer Retrieve();
        bool Save();
    }

    public class Customer
    {
        public Customer()
        {
            // default constructor (use ctor tab tab)
            // Don't actually need
        }

        public Customer(int customerId)
        {
            this.CustomerId = customerId;
        }

        // can have static members to class rather than instance
        public static int InstanceCount { get; set; }

        private string _lastname;

        public string LastName
        {
            get
            {
                // any code here
                return _lastname;
            }
            set
            {
                // any code here
                _lastname = value;
            }
        }

        public string FirstName { get; set; }

        public string EmailAddress { get; set; }

        public int CustomerId { get; private set; }

        public string GetFullName()
        {
            string fullname = LastName;
            if (!string.IsNullOrWhiteSpace(FirstName))
            {
                if (!string.IsNullOrWhiteSpace(fullname))
                {
                    fullname += ", ";
                }
                fullname += FirstName;
            }
            return fullname;
        }

        public List<Customer> Retrieve()
        {
            return new List<Customer>();
        }

        public Customer Retrieve(int customerId)
        {
            return new Customer();
        }

        public bool Save()
        {
            return true;
        }

        public bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace(FirstName)) isValid = false;

            return isValid;
        }
    }
}
