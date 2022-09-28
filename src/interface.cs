using System;
using System.Collections.Generic;
using Database.src;

namespace Database.src
{
    internal interface IUser
    {
        public void Delete();
        public void Insert(Dictionary<string, string> values);
        public void Select();
        public void Update();
    }
}