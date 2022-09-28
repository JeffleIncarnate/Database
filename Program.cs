using System;
using Database;
using System.Linq;
using System.Collections.Generic;
using Database.src;

namespace Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User u1 = new User();
            string[] values = { "dRayat", "Dhruv", "Rayat", "dhruv@gmail.com", "Dhruv123", "GOD" };
            var dhruv = u1.createObject(1, values);

            Dictionary<string, string> dhruvVals = new Dictionary<string, string>(dhruv.ReturnAllData());

            List<KeyValuePair<string, string>> list = dhruvVals.ToList();

            foreach (KeyValuePair<string, string> pair in list)
                Console.WriteLine("{0}, ", pair.Value);

            dhruv.Insert(dhruv.ReturnAllData());
        }
    }
}