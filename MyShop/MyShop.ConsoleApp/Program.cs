using System;
using Shop.Core.Utilities.Security;

namespace MyShop.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SecurityService security = new SecurityService();
            
            var hashPass = security.HashPassword("1234");
            Console.WriteLine(hashPass);
            var isOk = security.VerifyHashedPassword(hashPass, "1234");
            Console.WriteLine(isOk);
        }
    }
}
