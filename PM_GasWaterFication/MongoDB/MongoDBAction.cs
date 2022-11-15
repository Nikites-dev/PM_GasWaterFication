using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using PM_GasWaterFication.Models.Documents;
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
                var collection = database.GetCollection<Client>("ClientData");
                collection.InsertOne(client);
            }
            else if (user is Designer designer)
            {
                var collection = database.GetCollection<Designer>("DesignerData");
                collection.InsertOne(designer);
            }
            else if (user is Builder builder)
            {
                var collection = database.GetCollection<Builder>("BuilderData");
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
                var collection = database.GetCollection<Client>("ClientData");
                user = collection.Find(x => x.Login == login).FirstOrDefault();
            }
            catch (Exception e1)
            {
                try
                {
                    var collection = database.GetCollection<Designer>("DesignerData");
                    user = collection.Find(x => x.Login == login).FirstOrDefault();
                }
                catch (Exception e2)
                {
                    try
                    {
                        var collection = database.GetCollection<Builder>("BuilderData");
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
        
        public static List<Client> GetListClients()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Fication");
            var collection = database.GetCollection<Client>("ClientData");
            List<Client> strNames = collection.Find<Client>(x => x.Login != null && x.Login != "").ToList();
            return strNames;
        }
        
        public static List<Designer> GetListDesigners()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Fication");
            var collection = database.GetCollection<Designer>("DesignerData");
            List<Designer> strNames = collection.Find<Designer>(x => x.Login != null && x.Login != "").ToList();
            return strNames;
        }
        
        public static List<Builder> GetListBuilders()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Fication");
            var collection = database.GetCollection<Builder>("BuilderData");
            List<Builder> strNames = collection.Find<Builder>(x => x.Login != null && x.Login != "").ToList();
            return strNames;
        }
        
        public static void UpdateByName(String name, Client unit)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Fication");
            var collection = database.GetCollection<Client>("ClientData");
            var b = collection.ReplaceOne(x => x.Login == name, unit).ModifiedCount > 0;
        }
        
        public static void UpdateByName(String name, Designer unit)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Fication");
            var collection = database.GetCollection<Designer>("DesignerData");
            var b = collection.ReplaceOne(x => x.Login == name, unit).ModifiedCount > 0;
        }
        
        public static void UpdateByName(String name, Builder unit)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Fication");
            var collection = database.GetCollection<Builder>("BuilderData");
            var b = collection.ReplaceOne(x => x.Login == name, unit).ModifiedCount > 0;
        }
        
        
        
        // ---------- Project -----------
        
        public static void AddProject(ProjectData project)
        {
            var mongoClient = new MongoClient("mongodb://localhost");
            var database = mongoClient.GetDatabase("Fication");
            var collection = database.GetCollection<ProjectData>("ProjectsData");
            collection.InsertOne(project);
        }

        public static List<ProjectData> GetListProjects(String partner)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Fication");
            var collection = database.GetCollection<ProjectData>("ProjectsData");
            List<ProjectData> listProjects =
                collection.Find<ProjectData>(x => x.ClientPartner != null &&
                                                  (x.BuilderPartner == partner ||
                                                   x.ClientPartner == partner ||
                                                   x.DesignerPartner == partner)).ToList();
            return listProjects;
        }
        
        
        public static void UpdateByDate(String date, ProjectData projectData)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Fication");
            var collection = database.GetCollection<ProjectData>("ProjectsData");
            var b = collection.ReplaceOne(x => x.DataCreate == date, projectData).ModifiedCount > 0;
        }
    }
}