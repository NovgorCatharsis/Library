using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library_management_system
{
    internal class User
    {
        public string Name { get; }
        public int TitleID { get; }
        public int UserID { get; }

        public User(string name, int titleid, int userid)
        {
            Name = name;
            TitleID = titleid;
            UserID = userid;
        }
    }
}
