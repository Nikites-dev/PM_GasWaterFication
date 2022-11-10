using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PM_GasWaterFication.Models.Users
{
    public class User
    {
        private String login = "";
        private String password = "";
        private String role = "";
        private String email = "";
        
        public User()
        {
            
        }

        public User(String login, String password, String role, String email)
        {
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
        public String Login { get; set; }
        [BsonIgnoreIfDefault]
        public String Password { get; set; }
        [BsonIgnoreIfDefault]
        public String Role { get; set; }
        [BsonIgnoreIfDefault]
        public String Email { get; set; }
    }
}