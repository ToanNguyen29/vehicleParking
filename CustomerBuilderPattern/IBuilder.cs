using FinalWindow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWindow.CustomerBuilderPattern
{
    interface IBuilder
    {

        IBuilder SetUsername(string username);

        IBuilder SetPassword(string password);

        IBuilder SetFirstName(string firstName);

        IBuilder SetLastName(string lastName);

        IBuilder SetGender(string gender);

        IBuilder SetPhone(string phone);

        IBuilder SetEmail(string email);

        IBuilder SetAddress(string address);

        IBuilder SetPicture(byte[] picture);

        IBuilder SetActive(bool active);

        Customer Build();
        
    }
}
