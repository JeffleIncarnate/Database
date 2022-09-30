using System;
using System.Collections;
using Database;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection.Metadata;
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
            
            MethodPicker();
            
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

        private static void MethodPicker()
        {
            Console.Write("~> ");
            string userInput = Console.ReadLine();
            
            if (userInput == "help") 
                Help();

            string[] values = userInput.Split(" ");
            string[] valuesInsert = { "insert", "into", "users" };
            string[] valuesSelect = { "select", "*", "from", "users", "where", "item=" };
            string[] valuesUpdate= { "update", "users", "where=", "set="  };
            string[] valuesDelete = { "delete", "from", "users", "where=" };
            string itemOne = values[0];
            
            if (itemOne == "insert") VerifyInsert(valuesInsert, values);
            else if (itemOne == "select") VerifySelect(valuesSelect, values);
            else if (itemOne == "update") VerifyUpdate(valuesUpdate, values);
            else if (itemOne == "delete") VerifyDelete(valuesDelete, values);
            else
            {
                Console.WriteLine("Error: Incorrect format."); 
                MethodPicker();
            }
        }

        private static void Help()
        {
            Console.WriteLine("Here are the possible commands: insert, select, update and delete");
            Console.WriteLine("----------------------------");
            Console.WriteLine("[INSERT]");
            Console.WriteLine("insert into users [uuid], [username], [firstname], [lastname], [email], [password], [role]");
            Console.WriteLine("Example: insert into users '69420', 'RickAstleyMan', 'Rick', 'Astley', 'RickAstleyIsHot@gmail.com', 'ILoveRickAstleyNoHomo', 'GOD'");
            Console.WriteLine("----------------------------");
            Console.WriteLine("[SELECT]");
            Console.WriteLine("select * from users where item='[item]'");
            Console.WriteLine("Example: select * from users where item='RickAstleyMan'");
            Console.WriteLine("----------------------------");
            Console.WriteLine("[UPDATE]");
            Console.WriteLine("update users where='[item to update] set='[update item to]'");
            Console.WriteLine("Example: update users where='69420' set='42069'");
            Console.WriteLine("----------------------------");
            Console.WriteLine("[DELETE]");
            Console.WriteLine("delete from users where='[item to update]'");
            Console.WriteLine("Example: delete from users where='RickAstleyMan'");
            MethodPicker();
        }

        private static void VerifyInsert(string[] properFormat, string[] userInput)
        {
            bool isCorrect = true;

            for (int i = 0; i < 2; i++)
            {
                if (properFormat[i] != userInput[i]) isCorrect = false;
            }

            if (!isCorrect)
            {
                Console.WriteLine("Error: Incorrect format.");
                MethodPicker();
            }

            userInput = userInput.Skip(3).ToArray();

            for (int i = 0; i < userInput.Length; i++)
            {
                userInput[i] = userInput[i].Replace("'", "");
                userInput[i] = userInput[i].Replace(",", "");
            }
        }

        private static void VerifySelect(string[] properFormat, string[] userInput)
        {
            Console.WriteLine("verify select");
        }
        
        private static void VerifyUpdate(string[] properFormat, string[] userInput)
        {
            Console.WriteLine("verify update");
        }
        
        private static void VerifyDelete(string[] properFormat, string[] userInput)
        {
            Console.WriteLine("verify delete");
        }
    }
}