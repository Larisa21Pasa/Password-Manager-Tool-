using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaDeDate.Option
{
    /// <summary>
    /// Options for a delete query. 
    /// </summary>
    public class DeleteOptions
    {
        public string User { get; set; }
        public string Email { get; set; }
        public string Domain { get; set; }
        public string Password { get; set; }

        public DeleteOptions(string user, string email, string domain, string password)
        {
            User = user;
            Email = email;
            Domain = domain;
            Password = password;
        }

    }
}
