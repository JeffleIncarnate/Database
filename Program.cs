using System;
using Database;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Database.src;

namespace Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the user object, so we can access the class
            User u1 = new User();
            
            // Create a user with values
            string[] values = { "xNarayan", "Xavier", "Narayan", "xavier@gmail.com", "Xavier123", "ADMIN" };
            var user = u1.createObject(3, values); // Create the object
            Dictionary<string, string> vals = new Dictionary<string, string>(user.ReturnAllData()); // Get the value returned in a dictionary
            
            // INSERT
            // user.Insert(user.ReturnAllData());
            
            // DELETE
            // string rowToDelete = "Dhruv";
            // user.Delete(name);
            
            // SELECT
            // foreach (string item in user.Select("dRayat"))
            //     Console.Write(item + " ");
            
            // Update
            // user.Update("", "");
        }

        static void MethodPicker()
        {
            
        }
    }
}