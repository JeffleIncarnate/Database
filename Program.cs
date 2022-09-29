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
            string[] values = { "dRayat", "Dhruv", "Rayat", "dhruv@gmail.com", "Dhruv123", "GOD" };
            var user = u1.createObject(1, values); // Create the object
            Dictionary<string, string> vals = new Dictionary<string, string>(user.ReturnAllData()); // Get the value returned in a dictionary
            
            // INSERT
            // dhruv.Insert(siddhesh.ReturnAllData());
            
            // DELETE
            // string rowToDelete = "Dhruv";
            // dhruv.Delete(name);
            
            // SELECT
            // foreach (string item in user.Select(""))
            //     Console.Write(item + " ");
            
            // Update
            // user.Update("", "");
        }
    }
}