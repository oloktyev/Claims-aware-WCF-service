using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Valid credentials
            var client = new ServiceReference1.ServiceClient();
            client.ClientCredentials.UserName.UserName = "admin";
            client.ClientCredentials.UserName.Password = "pass";
                       
            var result = client.GetData(1);

            // Invalid credentials
            client = new ServiceReference1.ServiceClient();
            client.ClientCredentials.UserName.UserName = "invalid";
            client.ClientCredentials.UserName.Password = "invalid";

            result = client.GetData(1);
        }
    }
}
