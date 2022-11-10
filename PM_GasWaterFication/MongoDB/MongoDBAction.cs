using System;
using MongoDB.Driver;
using PM_GasWaterFication.Models.Users;

namespace PM_GasWaterFication.MongoDB
{
    public class MongoDBAction
    {
        public static void AddToDatabase(User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Fication");
            
            
            var collection = database.GetCollection<User>("UsersData");
            collection.InsertOne(user);
        }
        
        // public static CharacterDb UnitToCharacter(String name, Unit unit)
        // {
        //     var client = new MongoClient("mongodb://localhost");
        //     var database = client.GetDatabase("Warcraft");
        //     CharacterDb db = new CharacterDb(
        //         name,
        //         unit.GetType().Name,
        //         unit.CurrentStrensth, 
        //         unit.CurrentDesterity,
        //         unit.CurrentConstitution,
        //         unit.CurrentIntellisense,
        //         unit.Inventory,
        //         unit.Exp,
        //         unit.Equipments);
        //     
        //    return db;
        // }
        //
        public static User FindByName(String login, String password)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Fication");
            var collection = database.GetCollection<User>("UsersData");
            User user = collection.Find(x => x.Login  == login).FirstOrDefault();
            

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
        //     switch (unit.ClassName)
        //     {
        //         case "Warrior":
        //             return new Warrior(unit.Strength,
        //                 unit.Dexterity,
        //                 unit.Constitution,
        //                 unit.Intellisense,
        //                 unit.Items, 
        //                 unit.Exp, 
        //                 unit.Equipments)
        //             { Name = unit.Name};
        //         
        //         case "Wizard":
        //             return new Wizard(unit.Strength,
        //                     unit.Dexterity,
        //                     unit.Constitution,
        //                     unit.Intellisense,
        //                     unit.Items,
        //                     unit.Exp,
        //                     unit.Equipments)
        //                 {Name = unit.Name};
        //         
        //         case "Rogue":
        //             return new Rogue(unit.Strength,
        //                     unit.Dexterity,
        //                     unit.Constitution,
        //                     unit.Intellisense, 
        //                     unit.Items,
        //                     unit.Exp,
        //                     unit.Equipments)
        //                 {Name = unit.Name};
        //         default: return null;
        //     }
        //     return null;
        // }
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