using System;
using MongoDB.Bson.Serialization.Attributes;

namespace PM_GasWaterFication.Models.Users
{
    public class Client : User
    {
        public Client()
        {
            
        }
        
        public Client(String login, String password, String fullName, String email, int numPhone, String department, String position)
        {
            Login = login;
            Password = password;
            FullName = fullName;
            Email = email;
            NumPhone = numPhone;
            Department = department;
            Position = position;
        }
        
        public String Fication { get; set; }
        
        public String FullName { get; set; }
        public int NumPhone { get; set; }
        public String Department { get; set; } // отдел, должность
        public String Position { get; set; } // должность
    }
}