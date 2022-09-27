using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Database.src
{
    internal class User
    {
        public int userID { get; set; } = 0;
        public string userName { get; set; } = "";
        public string firstName { get; set; } = "";
        public string lastName { get; set; } = "";
        public string email { get; set; } = "";
        public string password { get; set; } = "";
        public string role { get; set; } = "BASIC";

        public User createObject(int uuid, string[] args)
        {
            foreach (string item in args) if (item == "") throw new InvalidDataException("Item can not ne null.");

            try
            {
                User u1 = new User()
                {
                    userID = uuid,
                    userName = args[0],
                    firstName = args[1],
                    lastName = args[2],
                    email = args[3],
                    password = args[4],
                    role = args[5]
                };

                return u1;
            }
            catch (System.IndexOutOfRangeException ex)
            {
                Console.WriteLine("Get better at coding you suck.");
                Console.WriteLine("{0}", ex);
            }

            User badCoder = new User()
            {
                userID = 0,
                userName = "Never",
                firstName = "Gonna",
                lastName = "Give",
                email = "You",
                password = "Up",
                role = "Get good"
            };
            return badCoder;
        }

        public dynamic ReturnAllData()
        {
            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                {"UserID", Convert.ToString(userID)},
                {"Username", userName},
                {"Firstname", firstName},
                {"Lastname", lastName},
                {"Email", email},
                {"Password", password},
                {"Role", role}
            };

            return values;
        }
    }
}