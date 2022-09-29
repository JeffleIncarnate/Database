using System;
using System.Collections.Generic;
using Database.src;

namespace Database.src
{
    internal interface IUser
    {
        public void Delete(string itemToDelete);
        public void Insert(Dictionary<string, string> values);
        public string[] Select(string rowToGet);
        public void Update(string itemTopdate, string updateItemTo);
    }
}