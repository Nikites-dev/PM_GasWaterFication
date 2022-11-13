using System;
using MongoDB.Driver;
using PM_GasWaterFication.Models.Users;

namespace PM_GasWaterFication.MongoDB
{
    public class MongoDBAction
    {
        public Client? isLoginClient { get; set; }
        public Designer? isLoginDesigner { get; set; }
        public Builder? isLoginBuilder { get; set; }
        
        public static void AddToDatabase(User user)
        {
            var mongoClient = new MongoClient("mongodb://localhost");
            var database = mongoClient.GetDatabase("Fication");

            if (user is Client client)
            {
                var collection = database.GetCollection<Client>("UsersData");
                collection.InsertOne(client);
            }
            else if (user is Designer designer)
            {
                var collection = database.GetCollection<Designer>("UsersData");
                collection.InsertOne(designer);
            }
            else if (user is Builder builder)
            {
                var collection = database.GetCollection<Builder>("UsersData");
                collection.InsertOne(builder);
            }
        }

        public static User FindByName(String login, String password)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Fication");

            User user;

            try
            {
                var collection = database.GetCollection<Client>("UsersData");
                user = collection.Find(x => x.Login == login).FirstOrDefault();
            }
            catch (Exception e1)
            {
                try
                {
                    var collection = database.GetCollection<Designer>("UsersData");
                    user = collection.Find(x => x.Login == login).FirstOrDefault();
                }
                catch (Exception e2)
                {
                    try
                    {
                        var collection = database.GetCollection<Builder>("UsersData");
                        user = collection.Find(x => x.Login == login).FirstOrDefault();
                    }
                    catch (Exception e3)
                    {
                        Console.WriteLine(e3);
                        throw;
                    }
                }
            }

            if (user == null)
            {
                return null;
            }

            if (user.Password == password)
            {
                return user;
            }

            return null;
        }

//
        // public static String DeleteByName(String name)
        // {
        //     var client = new MongoClient("mongodb://localhost");
        //     var database = client.GetDatabase("Warcraft");
        //     var collection = database.GetCollection<Unit>("HeroCollection");
        //     var unit = collection.DeleteOne(x => x.Name == name);
        //     return $"Unit {unit.GetType().Name} is remove!";
        // }
        //
        // public static void ClearDB()
        // {
        //     var client = new MongoClient("mongodb://localhost");
        //     client.GetDatabase("Warcraft").DropCollectionAsync("HeroCollection");
        // }
        //
        // public static List<String> AddListHeroes()
        // {
        //     var client = new MongoClient("mongodb://localhost");
        //     var database = client.GetDatabase("Warcraft");
        //     var collection = database.GetCollection<CharacterDb>("HeroCollection");
        //     var strNames = collection.Find<CharacterDb>(x => x.Name != null && x.Name != "")
        //         .ToEnumerable<CharacterDb>();
        //     return strNames.Select(x => x.Name).ToList<String>();
        // }
        //
        // public static void UpdateByName(String name, Unit unit)
        // {
        //     var client = new MongoClient("mongodb://localhost");
        //     var database = client.GetDatabase("Warcraft");
        //     var collection = database.GetCollection<CharacterDb>("HeroCollection");
        //     var b = collection.ReplaceOne(x => x.Name == name, UnitToCharacter(name, unit)).ModifiedCount > 0;
        // }
    }
}