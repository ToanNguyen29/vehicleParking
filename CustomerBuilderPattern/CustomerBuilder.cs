using FinalWindow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWindow.CustomerBuilderPattern
{
    class CustomerBuilder : IBuilder
    {
        private Customer _customer = new Customer();

        public IBuilder SetUsername(string username)
        {
            _customer.username = username;
            return this;
        }

        public IBuilder SetPassword(string password)
        {
            _customer.password = password;
            return this;
        }

        public IBuilder SetFirstName(string firstName)
        {
            _customer.firstName = firstName;
            return this;
        }

        public IBuilder SetLastName(string lastName)
        {
            _customer.lastName = lastName;
            return this;
        }

        public IBuilder SetGender(string gender)
        {
            _customer.gender = gender;
            return this;
        }

        public IBuilder SetPhone(string phone)
        {
            _customer.phone = phone;
            return this;
        }

        public IBuilder SetEmail(string email)
        {
            _customer.email = email;
            return this;
        }
        public IBuilder SetAddress(string address)
        {
            _customer.address = address;
            return this;
        }

        public IBuilder SetPicture(byte[] picture)
        {
            _customer.picture = picture;
            return this;
        }

        public IBuilder SetActive(bool active)
        {
            _customer.active = active;
            return this;
        }

        public Customer Build()
        {
            return _customer;
        }


       
    }
}
