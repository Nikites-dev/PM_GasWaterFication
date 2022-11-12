using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PM_GasWaterFication.Models.Users
{
    public class User
    {
        
        public User()
        {
            
        }

        public User(String fName, String lName, String login, String password, String role, String email)
        {
            FName = fName;
            LName = lName;
            Login = login;
            Password = password;
            Role = role;
            Email = email;
        }
        
        public virtual void PersonalInfo()
        {
            
        }
        [BsonIgnoreIfDefault]
        public ObjectId _id;
        
        [BsonIgnoreIfDefault]
        public String FName { get; set; }
        
        [BsonIgnoreIfDefault]
        public String LName { get; set; }
        
        [BsonIgnoreIfDefault]
        public String Login { get; set; }
        [BsonIgnoreIfDefault]
        public String Password { get; set; }
        [BsonIgnoreIfDefault]
        public String Role { get; set; }
        [BsonIgnoreIfDefault]
        public String Email { get; set; }
    }
}