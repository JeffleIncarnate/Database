using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Database.src
{
    internal class User : IUser
    {
        public int userID { get; set; } = 0;
        public string userName { get; set; } = "";
        public string firstName { get; set; } = "";
        public string lastName { get; set; } = "";
        public string email { get; set; } = "";
        public string password { get; set; } = "";
        public string role { get; set; } = "BASIC";

        private string filePath { get; set; } = @"/home/dhruv/Documents/Code Files/C#/Database/data.csdb";

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

        public void Delete(string itemToDelete)
        {
            string[] text = File.ReadAllLines(filePath).Skip(1).ToArray();
            List<string[]> records = new List<string[]>();
            string[] tempConvertList = { };
            int count = 1;
            
            for (int i = 0; i < text.Length; i++)
            {
                tempConvertList = text[i].Split(" | ");
                records.Add(tempConvertList);
            }

            foreach (string[] items in records)
            {
                foreach (string item in items)
                {
                    if (item == itemToDelete)
                    {
                        var file = new List<string>(File.ReadAllLines(filePath));
                        file.RemoveAt(count);
                        File.WriteAllLines(filePath, file.ToArray());
                    }
                }
                ++count;
            }
        }

        public void Insert(Dictionary<string, string> values)
        {

            List<KeyValuePair<string, string>> list = values.ToList();
            var last = values.Values.Last();

            int count = -1;

            using (TextWriter tsw = new StreamWriter(filePath, true))
            {
                foreach (KeyValuePair<string, string> pair in list)
                {
                    ++count;
                    if (pair.Value == last)
                    {
                        tsw.Write("{0}", last);
                    }
                    else
                    {
                        if (count == 0)
                        {
                            tsw.WriteLine("");
                            tsw.Write("{0} | ", pair.Value);
                        }
                        else tsw.Write("{0} | ", pair.Value);
                    }
                }
            }
        }

        public string[] Select(string rowToGet)
        {
            string[] text = File.ReadAllLines(filePath).Skip(1).ToArray();
            List<string[]> records = new List<string[]>();
            string[] tempConvertList = { };

            for (int i = 0; i < text.Length; i++)
            {
                tempConvertList = text[i].Split(" | ");
                records.Add(tempConvertList);
            }

            foreach (string[] items in records)
            {
                foreach (string item in items)
                {
                    if (item == rowToGet)
                    {
                        return items;
                    }
                }
            }
            return new string[]{"Could not find item"};
        }

        public void Update()
        {

        }
    }
}